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
    public class EditSpecialVM : BaseVM
    {
        public Special EditSpecial { get; set; }
        public CommandVM SaveSpecial { get; set; }

        private CurrentPageControl currentPageControl;
        public EditSpecialVM(CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditSpecial = new Special();
            InitCommand();
        }
        public EditSpecialVM(Special editSpecial, CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditSpecial = editSpecial;
            InitCommand();
        }

        private void InitCommand()
        {
            SaveSpecial = new CommandVM(() => {
                var model = SqlModel.GetInstance();
                if (EditSpecial.ID == 0)
                    model.Insert(EditSpecial);
                else
                    model.Update(EditSpecial);
                currentPageControl.Back();
            });
        }
    }
}
