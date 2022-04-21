using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp15.DTO;
using WpfApp15.Model;
using WpfApp15.Pages;
using WpfApp15.Tools;

namespace WpfApp15.ViewModels
{
    public class EditJournalVM : BaseVM
    {
        public journal EditJournal { get; }
        public CommandVM SaveJournal { get; set; }
        private discipline journalDiscipline { get; set; }
        public discipline JournalDiscipline
        {
            get => journalDiscipline;
            set
            {
                journalDiscipline = value;
                Signal();
            }
        }
        public Student journalStudent { get; set; }
        public Student JournalStudent
        {
            get => journalStudent;
            set
            {
                journalStudent = value;
                Signal();
            }
        }
        public List<discipline> disciplines { get; set; }
        public List<Student> Students { get; set; }
        private CurrentPageControl currentPageControl;

        public EditJournalVM(CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditJournal = new journal();
            Init();
        }

        public EditJournalVM(journal editJournal, CurrentPageControl currentPageControl)
        {
            EditJournal = editJournal;
            this.currentPageControl = currentPageControl;
            Init();
            JournalDiscipline = disciplines.FirstOrDefault(s => s.ID == EditJournal.ID);
            JournalStudent = Students.FirstOrDefault(s => s.ID == EditJournal.ID);
        }
        private void Init()
        {
            disciplines = SqlModel.GetInstance().SelectDisciplineRange(0, 100);
            Students = SqlModel.GetInstance().SelectStudentsRange(0, 100);
            SaveJournal = new CommandVM(() => {
                if (JournalStudent == null)
                {
                    System.Windows.MessageBox.Show("Нужно выбрать студента для продолжения");
                    return;
                }
                if (JournalDiscipline == null)
                {
                    System.Windows.MessageBox.Show("Нужно выбрать дисциплину для продолжения");
                    return;
                }
                var model1 = SqlModel.GetInstance();
                EditJournal.disciplineID = JournalDiscipline.ID;
                EditJournal.studentID = JournalStudent.ID;
                if (EditJournal.ID == 0)
                    model1.Insert(EditJournal);
                else
                    model1.Update(EditJournal);
                currentPageControl.SetPage(new ViewJournalPage(JournalStudent ,JournalDiscipline));


            });
        }

    }
}
