
using System.Threading.Tasks;
using acmeProgram.interfaces;
using System.IO;
using System.Net.Http;
using System;
using System.Collections.Generic;
using acmeDB.methods;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;

namespace acmeProgram.classFiles
{
    public class clCsvImporter : IFileAccess
    {
         private static StreamReader URLStream(String fileurl){
            return new StreamReader(new HttpClient().GetStreamAsync(fileurl).Result);
        }

        public async Task readFileAsync(string url, int numRows)
        {
            StreamReader s = URLStream(url);
            string[] delimiters = { ";" };
            Console.WriteLine("Iniciando extraccion");
            Console.WriteLine("Origen: "+ url);
            using (TextFieldParser csvReader = new TextFieldParser(s))
            {
                ManageACMEData objManage= new ManageACMEData();
                List<Product> producto = new List<Product>();
                int numLote=1;
                string[] fieldsStream;
                csvReader.SetDelimiters(delimiters);
                csvReader.HasFieldsEnclosedInQuotes = true;     
                csvReader.ReadLine();               
                while (!csvReader.EndOfData)
                {
                    fieldsStream=csvReader.ReadFields();
                    if(producto.Count<= numRows)
                    {
                        try{//Control data of previous import
                            producto.Add(new Product {pointOfSale=fieldsStream[0],product = fieldsStream[1], date = fieldsStream[2],stock = fieldsStream[3] });                    
                        }catch(Exception){
                            Console.WriteLine("Data omitida de previa importacion:"+fieldsStream.ToString() +" la extraccion continua.");
                        } 
                    }
                    else
                    {
                      //add data of this loop
                      try{//Control data of previous import
                            producto.Add(new Product {pointOfSale=fieldsStream[0],product = fieldsStream[1], date = fieldsStream[2],stock = fieldsStream[3] });                    
                      }catch(Exception){
                            Console.WriteLine("Data omitida de previa importacion:"+fieldsStream.ToString() +" la extraccion continua.");
                      }                      
                      Console.WriteLine("Lote en ejecucion: "+numLote+ " con "+numRows.ToString()+" filas.");                      
                      string stringToSerialize = JsonConvert.SerializeObject(producto); 
                      string respuesta=await objManage.insertDataACMEAsync(stringToSerialize);
                      Console.WriteLine("   Resultado: "+ ((respuesta=="0")? "No extraido":"Correcto"));
                      producto.Clear();
                      numLote++;
                        }
                    }
                }
            }
    }
}

