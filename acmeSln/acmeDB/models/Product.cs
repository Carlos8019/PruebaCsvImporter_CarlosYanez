using System;
using Microsoft.EntityFrameworkCore;

namespace acmeDB.models
{
 [Keyless]
    public class Product
    {
        public string pointOfSale{get; set;}
        public string product{get; set;}
        public string date{get; set;}
        public string stock{get; set;}        
    }
}
