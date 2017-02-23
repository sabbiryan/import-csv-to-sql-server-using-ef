using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication.Model;
using CsvHelper.Configuration;

namespace ConsoleApplication.Mapper
{
    public sealed class TransectionMap : CsvClassMap<Transection>
    {
        public TransectionMap()
        {
            Map(m => m.ValueDate).Index(0);
            Map(m => m.TransectionParticular).Index(1);
            Map(m => m.Withdraw).Index(2);
            Map(m => m.Deposit).Index(3);
            Map(m => m.Balance).Index(4);
            Map(m => m.TransectionId).Index(5);
        }

        public DateTime VALUE_DATE { get; set; }
        public string TRAN_PARTICULAR { get; set; }
        public double WITHDRAW { get; set; }
        public double DEPOSIT { get; set; }
        public double BALANCE { get; set; }
        public string TRAN_ID { get; set; }
    }
}
