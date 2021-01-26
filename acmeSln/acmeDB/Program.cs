using System;
using acmeDB.methods;
namespace acmeDB
{
    class Program
    {
        static void Main(string[] args)
        {
            ManageACMEData objAcmeData= new ManageACMEData();            
            Console.WriteLine(objAcmeData.insertDataACMEAsync(@"[{""pointOfSale"":""121017"",""product"":""17240503200796"",""date"":""2019-06-02"",""stock"":""3""},{""pointOfSale"":""121017"",""product"":""17240503200796"",""date"":""2019-06-03"",""stock"":""3""}"));
        }
        //'[{"pointOfSale":"121017","product":"17240503200796","date":"2019-06-02","stock":"3"},{"pointOfSale":"121017","product":"17240503200796","date":"2019-06-03","stock":"3"},{"pointOfSale":"121017","product":"17240503200796","date":"2019-06-04","stock":"3"},{"pointOfSale":"121017","product":"17240503200796","date":"2019-06-05","stock":"3"},{"pointOfSale":"121017","product":"17240503200796","date":"2019-06-06","stock":"3"},{"pointOfSale":"121017","product":"17240503200796","date":"2019-06-07","stock":"3"},{"pointOfSale":"121017","product":"17240503200796","date":"2019-06-08","stock":"3"},{"pointOfSale":"121017","product":"17240503200796","date":"2019-06-09","stock":"3"},{"pointOfSale":"121017","product":"17240503200796","date":"2019-06-10","stock":"3"},{"pointOfSale":"121017","product":"17240503200796","date":"2019-06-11","stock":"3"},{"pointOfSale":"121017","product":"17240503200796","date":"2019-06-12","stock":"3"},{"pointOfSale":"121017","product":"17240503200796","date":"2019-06-13","stock":"3"},{"pointOfSale":"121017","product":"17240503200796","date":"2019-06-14","stock":"3"},{"pointOfSale":"121017","product":"17240503200796","date":"2019-06-15","stock":"3"},{"pointOfSale":"121017","product":"17240503200796","date":"2019-06-16","stock":"3"},{"pointOfSale":"121017","product":"17240503200796","date":"2019-06-17","stock":"3"},{"pointOfSale":"121017","product":"17240503200796","date":"2019-06-18","stock":"3"},{"pointOfSale":"121017","product":"17240503200796","date":"2019-06-19","stock":"3"},{"pointOfSale":"121017","product":"17240503200796","date":"2019-06-20","stock":"3"},{"pointOfSale":"121017","product":"17240503200796","date":"2019-06-21","stock":"3"},{"pointOfSale":"121017","product":"17240503200796","date":"2019-06-22","stock":"3"},{"pointOfSale":"121017","product":"17240503200796","date":"2019-06-23","stock":"3"},{"pointOfSale":"121017","product":"17240503200796","date":"2019-06-24","stock":"3"},{"pointOfSale":"121017","product":"17240503200796","date":"2019-06-25","stock":"3"},{"pointOfSale":"121017","product":"17240503200796","date":"2019-06-26","stock":"3"},{"pointOfSale":"121017","product":"17240503200796","date":"2019-06-27","stock":"3"}'
    }
}
