using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp15.DTO;
using WpfApp15.Model;

namespace WpfApp15.ViewModels
{
   public class ViewDisciplineVM : BaseVM
    {

        private Prepods selectedPrepods;
        private List<discipline> disciplineBySelectedPrepods;

        public List<Prepods> Prepod { get; set; }
        public discipline SelectDisciplineRange { get; set; }

        public Prepods SelectedPrepods
        {
            get => selectedPrepods;
            set
            {
                selectedPrepods = value;
                DisciplinesBySelectedPrepods = SqlModel.GetInstance().SelectDisciplinesByPrepods(selectedPrepods);
                Signal();
            }
        }
        public List<discipline> DisciplinesBySelectedPrepods
        {
            get => disciplineBySelectedPrepods;
            set
            {
                disciplineBySelectedPrepods = value;
                Signal();
            }
        }
       

        public ViewDisciplineVM(Prepods selectedPrepods)
        {
            SqlModel sqlModel = SqlModel.GetInstance();
            Prepod = sqlModel.SelectPrepodsRange(0, 100);
            SelectedPrepods = Prepod.FirstOrDefault(s => s.ID == selectedPrepods?.ID);
        }

    }
}
