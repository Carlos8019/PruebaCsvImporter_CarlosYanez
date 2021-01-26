using System;
using acmeProgram.classFiles;
using acmeDB.methods;

namespace acmeTest
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
        Console.WriteLine("Test de app ACME CSV Importer");            
        /*
            Ingresar el texto en formato json para probar la funcionalidad de insercion en la base
            de manera asincrona           
            ejemplo de 2 registros en JSON:

             [{""pointOfSale"":""121017"",""product"":""17240503200796"",""date"":""2019-06-02"",""stock"":""3""}
             ,{""pointOfSale"":""121017"",""product"":""17240503200796"",""date"":""2019-06-03"",""stock"":""3""}]

             Luego de modificar los valores realizar un buil del proyecto acmeTEST 
                1.- Ubicarse en la carpeta de Test cd /ACMEApp/acmeSln/AcmeTest/
                2.- Compilar: dotnet build acmeTest.csproj
                3.- ejecutar el Test : dotnet bin/Debug/net5.0/acmeTest.dll
                4.- Verificacion:
                    4.1 Insercion en la tabla tblProductsACME en caso de respuesta positiva (Correcto)
                    select * from  dbo.tblProductsACME with (nolock)  --i la respuesta fue 
                    4.2 Insercion en la tabla tblErrorInsertACME en caso de respuesta negativa (No extraido)
                    select * from  dbo.tblErrorInsertACME with (nolock)  --i la respuesta fue 

        */
        ManageACMEData objAcmeData= new ManageACMEData();            
        string jsonIncorrecto=@"[{""pointOfSale"":""121017"",""product"":""17240503200796"",""date"":""2019-06-02"",""stock"":""3""},{""pointOfSale"":""121017"",""product"":""17240503200796"",""date"":""2019-06-03"",""stock"":""3""}";
        string jsonCorrecto=@"[{""pointOfSale"":""121017"",""product"":""17240503200796"",""date"":""2019-06-02"",""stock"":""3""},{""pointOfSale"":""121017"",""product"":""17240503200796"",""date"":""2019-06-03"",""stock"":""3""}]";
        string respuesta=await objAcmeData.insertDataACMEAsync(jsonIncorrecto);
        Console.WriteLine("Cadena: "+jsonIncorrecto);
        Console.WriteLine("   Resultado: "+ ((respuesta=="0")? "No extraido":"Correcto"));
        respuesta=await objAcmeData.insertDataACMEAsync(jsonCorrecto);
        Console.WriteLine("Cadena: "+jsonCorrecto);
        Console.WriteLine("   Resultado: "+ ((respuesta=="0")? "No extraido":"Correcto"));



        }
    }
}
