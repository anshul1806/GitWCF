using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using DataLibrary;

namespace WCFXmlSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0 && args[0].Equals("-d"))
            {
                DeserializeMessage();
            }
            else
            {
                Serialize();
            }
           
        }

        private static void Serialize()
        {
           Product prd =  new Product(){
               Name="Healthy Coffe Beans",
               Comments="Good for cardiac problems and metabolism",
               Type = "Caps",
               UpdateTime =  DateTime.Now
                };
           using (FileStream fs = new FileStream("Product.xml", FileMode.Create))
           {
               DataContractSerializer ds = new DataContractSerializer(typeof(Product));
               ds.WriteObject(fs, prd);
           }
        }

        private static void DeserializeMessage()
        {
            DataContractSerializer ds = new DataContractSerializer(typeof(Product));
            using (FileStream fs = new FileStream("Product.xml", FileMode.Open))
            {
                Product prd = ds.ReadObject(fs) as Product;
                Console.WriteLine(String.Format("****Product information****\n" +
                                    "{0} \n {1} \n {2} \n{3}", prd.Name, prd.Comments, prd.Type, prd.UpdateTime));
            }
        }
    }
}
