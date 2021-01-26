using System;
using acmeDB.contextDB;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
namespace acmeDB.methods
{
    public class ManageACMEData
    {
        public async Task<string> insertDataACMEAsync(string json)
        {
            var context = new ProductContext();
            var parameters= new SqlParameter[]{
                new SqlParameter(){
                    ParameterName="@json",
                    SqlDbType=SqlDbType.NVarChar,
                    Size=-1,
                    Direction=ParameterDirection.Input,
                    Value=json
                },
                new SqlParameter(){
                    ParameterName="@response",
                    SqlDbType=SqlDbType.VarChar,
                    Size=50,
                    Direction=ParameterDirection.Output,
                }
            };
            //Console.WriteLine(json);
            await context.Database.ExecuteSqlRawAsync("[dbo].[sp_InsertProductsACME] @json, @response out", parameters);

            return Convert.ToString(parameters[1].Value); 
        }
    }
}
