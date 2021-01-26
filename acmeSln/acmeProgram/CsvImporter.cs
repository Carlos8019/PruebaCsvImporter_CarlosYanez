using System;
using acmeProgram.classFiles;
using acmeDB.methods;

namespace acmeProgram
{
    class CsvImporter
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            clCsvImporter obj=new clCsvImporter();
            ParametersACME objAcmeParam= new ParametersACME();
            Console.WriteLine("CsvImporter "+objAcmeParam.GetJsonAppSetting("batchProcess","csvName"));
            await obj.readFileAsync(objAcmeParam.GetJsonAppSetting("batchProcess","URLCsvLocation"),Int32.Parse(objAcmeParam.GetJsonAppSetting("batchProcess","numRows")));
        }
    }
}
