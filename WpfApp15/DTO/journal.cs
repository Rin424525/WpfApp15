using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp15.Tools;

namespace WpfApp15.DTO
{
    [Table("journal")]
    public class journal : BaseDTO
    {
        [Column("discipline_id")]
        public int disciplineID { get; set; }
        [Column("student_id")]
        public int studentID { get; set; }
        [Column("day")]
        public DateTime Day { get; set; }
        [Column("value")]
        public int Value { get; set; }
    }
}
