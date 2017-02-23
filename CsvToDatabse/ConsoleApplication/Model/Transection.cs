using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Model
{
    public class Transection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public DateTime ValueDate { get; set; }
        public string TransectionParticular { get; set; }
        public double Withdraw { get; set; }
        public double Deposit { get; set; }
        public double Balance { get; set; }
        public string TransectionId { get; set; }
    }
}
