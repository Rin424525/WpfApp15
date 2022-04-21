using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp15.DTO;
using WpfApp15.Model;

namespace WpfApp15.ViewModels
{
    public class ViewJournalVM : BaseVM
    {

        private Student selectedStudent;
        private discipline selectedDiscipline;
        private List<journal> journalBySelectedStudent;
        private List<journal> journalBySelectedDiscipline;
        public List<discipline> disciplines { get; set; }
        public List<Student> Students { get; set; }
        public discipline SelectedDiscipline
        {
            get => selectedDiscipline;
            set
            {
                selectedDiscipline = value;
                JournalBySelectedDiscipline = SqlModel.GetInstance().JournalBySelectedStudentDiscipline(selectedStudent, selectedDiscipline);
                Signal();
            }
        }

        public Student SelectedStudent
        {
            get => selectedStudent;
            set
            {
                selectedStudent = value;
                JournalBySelectedStudent = SqlModel.GetInstance().JournalBySelectedStudentDiscipline(selectedStudent, selectedDiscipline);
                Signal();
            }
        }

        public List<journal> JournalBySelectedDiscipline
        {
            get => journalBySelectedDiscipline;
            set
            {
                journalBySelectedDiscipline = value;
                Signal();
            }
        }

        public List<journal> JournalBySelectedStudent
        {
            get => journalBySelectedStudent;
            set
            {
                journalBySelectedStudent = value;
                Signal();
            }
        }
        

        public ViewJournalVM(Student selectedStudent, discipline selectedDiscipline)
        {
            SqlModel sqlModel = SqlModel.GetInstance();
            disciplines = sqlModel.SelectDisciplineRange(0, 100);
            SelectedDiscipline = disciplines.FirstOrDefault(s => s.ID == selectedDiscipline?.ID);
            Students = sqlModel.SelectStudentsRange(0, 100);
            SelectedStudent = Students.FirstOrDefault(s => s.ID == selectedStudent?.ID);
        }

    }

}

