using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CollectionsDemo
{
    public class CustomObj
    {
        public CustomObj()
        {
            Count = 0;
            Name = "Hello World";
        }
        public CustomObj(int _count, String _name)
        {
            Count = _count;
            Name = _name;
        }
        public int Count { get; set; }
        public String Name { get; set; }

        //public override string ToString()
        //{
        //    base.ToString();
        //    String retVal = "Count :" + this.Count + "Name :" + this.Name;
        //    return retVal;
        //}
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Array list demo");
            // blocked demo for the array list class.
            // ArrayListdemo();

            Console.WriteLine("hash table vs dictionary demo");
            Hashtable hst = new Hashtable();
            hst.Add("Anshul", "Archana");
            hst.Add("Samir", "Aditi");
            hst.Add("Poorna", "Nirmala");
            hst.Add("Beeju", "Moti");
            //hst.Add(1, 2);
            // Checking if the has contains "anshul";
            Console.WriteLine("checking for the key {0} : Status {1}", "anshul", hst.ContainsKey("anshul") ? "found" : "NotFound");
            // Checking if the has contains "Anshul";
            Console.WriteLine("checking for the key {0} : Status {1}", "anshul", hst.ContainsKey("Anshul") ? "found" : "NotFound");
            // Copy to 
            int hstCount = hst.Count;
            object[] arr = new object[hstCount];
            hst.CopyTo(arr, 0);

            PrintHashTable(hst);
            Console.WriteLine("Copied all the elements into the array");
            foreach (var elm in arr)
            {
                Console.WriteLine("Array element key : {0}  ", ((DictionaryEntry)elm).Key);
            }

            Hashtable clonedCopy = (Hashtable)hst.Clone();
            PrintHashTable(clonedCopy);



            /// Now creating a  new hastable with person as value and person name as the key
        
            Pers
            Hashtable personHash =  new  Hashtable();
            
            Console.ReadLine();

        }


        private static void PrintHashTable(Hashtable hst)
        {
            Console.WriteLine("***************hash table data printing********************");
            foreach (var x in hst.Keys)
                Console.WriteLine("Hst Key :{0}  Value : {1}", x, hst[x]);
        }

        #region Array List section
        private static void ArrayListdemo()
        {
            ArrayList myAl = new ArrayList();
            PrintPropertiesOfMyAl(myAl);

            Console.WriteLine("populating the arrya with string elements");
            myAl.Add("Hello Anshul");
            myAl.Add("Archana Hello");
            myAl.Add("Samir");
            myAl.Add("Niramal Awasthi");
            // custom object creation instance 1;
            CustomObj obj1 = new CustomObj();
            //CustomObj obj2 = new CustomObj(_name = "Archana Awasthi", _count = 1);
            CustomObj obj2 = new CustomObj(1, "archana");
            myAl.Add(obj1);
            myAl.Add(obj2);
            //myAl.Add(1);
            //myAl.Add(2);
            //myAl.Add(1.1);
            PrintArrayList(myAl);
            PrintPropertiesOfMyAl(myAl);
            // sorting the arrayList;

            Console.WriteLine("After sorting the list");
            myAl.Sort();
            PrintArrayList(myAl);
        }

        private static void PrintPropertiesOfMyAl(ArrayList myAl)
        {
            Console.WriteLine();
            Console.WriteLine("************\tProperties of array list \t*************");
            Console.WriteLine("Arraylist properties ");
            Console.WriteLine("array list Capacity {0}", myAl.Capacity);
            Console.WriteLine("array list count {0}", myAl.Count);
            Console.WriteLine("array list IsReadOnly {0}", myAl.IsReadOnly);
            Console.WriteLine("array list IsFixedSize {0}", myAl.IsFixedSize);
            Console.WriteLine("array list IsSynchronized {0}", myAl.IsSynchronized);
        }

        private static void PrintArrayList(ArrayList myAl)
        {
            int i = 0;
            foreach (var item in myAl)
            {
                Console.WriteLine("Item {0} : {1}", i++, item);
            }
        }
        #endregion Array List section
    }

    public class Person
    {
        public Person(String _name, int _age, String xex , Address addr)
        {
            Name  = _name;
            Age =  _age;
            Sex =  xex;
            Addresses  = new List<Address>();
           Addresses.Add(addr);
        }
        // encapsulation of private property.
        private String userName;
        public String Name
        {
            get
            {
                return userName;
            }
            set
            {
                userName = this.value;
            }
        }
        // now these methods has no backing property 
        public String Age { get; set; }
        public String Sex { get; set; }
        private List<Address> addresses;
        public List<Address> Addresses
        {
          get { return addresses; }
          set { addresses = value; }
        }
        //public List<Address> MyAddress {
        //    get{
        //        return addresses;
        //    }
        //    set{
        //        if (addresses != null)
        //        {
        //            addresses.Add(this.value);
        //        }
        //        else
        //        {
        //            addresses = new List<Address>();
        //            addresses.Add(this.value);
        //        }
        //    }
        //}
    }
    public class Address {
        public String StrtAddress1 {get;set}
        public String StrtAddress2 {get;set}
        public String City{ get; set; }
        public String State{ get; set; }
        public String Country{get;set;}
        public String Zip { get; set; }
    }
}
