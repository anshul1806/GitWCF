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
           // run this program from console only. Don't run this program from debug menu. 
            // this program requires varying number of arguments to be passed under different runs.
            //following are supported usage.
            /*
             * WCFXMLSerialization.exe -d(Desirialize the file generated)
             * WCFXMLSerialization.exe runs the program and generate the product.xml
             * */
            String vInfo = FindDataContractVersionToUse(args);
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
            Product prd = new Product()
            {
                Name = "Healthy Coffe Beans",
                Comments = "Good for cardiac problems and metabolism",
                Type = "Caps",
                UpdateTime = DateTime.Now
            };
            ExtendedProduct exProd = new ExtendedProduct();
            exProd.Name = "Fashion Suit";
            exProd.Comments = "Really Nice Suit";
            exProd.Type = "Dress";
            exProd.UpdateTime = DateTime.Now;
            exProd.Designer = "Manish Lula";

            using (FileStream fs = new FileStream("Product.xml", FileMode.Create))
            {
                DataContractSerializer ds = new DataContractSerializer(typeof(Product));
                ds.WriteObject(fs, exProd);
            }
           
        }

        private static void DeserializeMessage()
        {
            String fileName = "Product.xml";

            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                DataContractSerializer ds = new DataContractSerializer(typeof(Product));
                Product prd = ds.ReadObject(fs) as Product;
                Console.WriteLine(String.Format("****Product information****\n" +
                                    "{0} \n {1} \n {2} \n{3}", prd.Name, prd.Comments, prd.Type, prd.UpdateTime));
                if(prd is ExtendedProduct )
                {
                    ExtendedProduct exP = prd as ExtendedProduct;
                    Console.WriteLine(String.Format("Mr Designer:\t {0}", exP.Designer));
                }
            }
        }

        private static String GetFileNameBasedOnVersionInfo(String vInfo)
        {
            String fileName = String.Empty;
            if (!String.IsNullOrEmpty(vInfo) && vInfo.Equals("2"))
            {
                fileName = "ProductVersion2.xml";
            }
            else
            {
                fileName = "Product.xml";
            }
            return fileName;
        }

        private static string FindDataContractVersionToUse(string[] args)
        {
            if (args.Length == 3 && args[1].Equals("-v"))
            {
                // if -v argument is inluded next arguments becomes version of class to be used
                String versionInfo = args[2];
                return versionInfo;
            }
            return String.Empty;
        }

    }
}
