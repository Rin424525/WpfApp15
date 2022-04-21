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
    public class EditPrepodsVM : BaseVM
    {


        public Prepods EditPrepods { get; set; }
        public CommandVM SavePrepods { get; set; }

        private CurrentPageControl currentPageControl;
        public EditPrepodsVM(CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditPrepods = new Prepods();
            InitCommand();
        }
        public EditPrepodsVM(Prepods editPrepods, CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditPrepods = editPrepods;
            InitCommand();
        }

        private void InitCommand()
        {
            SavePrepods = new CommandVM(() => {
                var model = SqlModel.GetInstance();
                if (EditPrepods.ID == 0)
                    model.Insert(EditPrepods);
                else
                    model.Update(EditPrepods);
                currentPageControl.Back();
            });
        }
    }
}