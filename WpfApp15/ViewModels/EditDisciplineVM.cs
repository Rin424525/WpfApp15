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
   public class EditDisciplineVM : BaseVM
    {
        public discipline EditDiscipline { get; }
        public CommandVM SaveDiscipline { get; set; }
        public Prepods DisciplinePrepods
        {
            get => disciplinePrepods;
            set
            {
                disciplinePrepods = value;
                Signal();
            }
        }

        public List<Prepods> Prepod { get; set; }
        private CurrentPageControl currentPageControl;
        private Prepods disciplinePrepods;

        public EditDisciplineVM(CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditDiscipline = new discipline();
            Init();
        }

        public EditDisciplineVM(discipline editDiscipline, CurrentPageControl currentPageControl)
        {
            EditDiscipline = editDiscipline;
            this.currentPageControl = currentPageControl;
            Init();
            DisciplinePrepods = Prepod.FirstOrDefault(s => s.ID == editDiscipline.ID);
        }

        private void Init()
        {
            Prepod = SqlModel.GetInstance().SelectPrepodsRange(0, 100);
            SaveDiscipline = new CommandVM(() => {
                if (DisciplinePrepods == null)
                {
                    System.Windows.MessageBox.Show("Нужно выбрать преподавателя для продолжения");
                    return;
                }
                var model = SqlModel.GetInstance();
                if (EditDiscipline.ID == 0)
                    model.Insert(EditDiscipline);
                else
                    model.Update(EditDiscipline);
                currentPageControl.SetPage(new ViewPrepodsPage(DisciplinePrepods));
            });
        }

    }
}
