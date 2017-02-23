using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication.Mapper;
using ConsoleApplication.Model;
using CsvHelper;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Transection> transections = ReadCsv();
            Console.WriteLine(transections.Count);

            bool save = StoreInDatabase(transections);

            Console.ReadLine();
        }

        private static bool StoreInDatabase(List<Transection> transections)
        {
            AppContext context = new AppContext();
            context.Transections.AddRange(transections);
            return context.SaveChanges() > 0;
        }

        private static List<Transection> ReadCsv()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory + @"\";

            string resource = baseDirectory + @"Resource\Resource.csv";

            TextReader textReader = File.OpenText(resource);

            var csv = new CsvReader(textReader);

            List<TransectionMap> transectionMaps = null;
            try
            {
                transectionMaps = csv.GetRecords<TransectionMap>().ToList();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            List<Transection> transections = null;
            if (transectionMaps != null)
            {
                transections = transectionMaps.ConvertAll(
                    x =>
                        new Transection()
                        {
                            ValueDate = x.VALUE_DATE,
                            TransectionParticular = x.TRAN_PARTICULAR,
                            Withdraw = x.WITHDRAW,
                            Deposit = x.DEPOSIT,
                            Balance = x.BALANCE,
                            TransectionId = x.TRAN_ID
                        });


                //transections = new List<Transection>();
                //while (csv.Read())
                //{                
                //    //var valueDate = csv.GetField<DateTime>(0);
                //    //var transectionParticular = csv.GetField<string>(1);
                //    //var withdraw = csv.GetField<double>("WITHDRAW");
                //    //var deposit = csv.GetField<double>("DEPOSIT");
                //    //var balance = csv.GetField<double>(4);
                //    //var transectionId = csv.GetField<string>(5);

                //    Transection transection = new Transection
                //    {
                //        ValueDate = csv.GetField<DateTime>(0),
                //        TransectionParticular = csv.GetField<string>(1),
                //        Withdraw = csv.GetField<double>("WITHDRAW"),
                //        Deposit = csv.GetField<double>("DEPOSIT"),
                //        Balance = csv.GetField<double>(4),
                //        TransectionId = csv.GetField<string>(5)
                //    };

                //    transections.Add(transection);
                //}                
            }

            return transections;
        }
    }
}
