using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Collections.Specialized;


namespace EdifParser
{
    class Program
    {
        static void Main(string[] args)
        {
           IEnumerable<String> files = Directory.GetFiles(EdifParser.Constants.BaseDir);
           Dictionary<String, List<String>> filedata = new Dictionary<string, System.Collections.Generic.List<string>>();
           Parallel.ForEach(files, currentFile => {
               filedata[currentFile] = new System.Collections.Generic.List<String>();
           });

           Parallel.ForEach(files, currentFile => 
           { 
            using(StreamReader reader =  new StreamReader(currentFile))
            {
                String line = String.Empty;
                while(( line =reader.ReadLine() )!= null)
                {
                    filedata[currentFile].Add(line);    
                }

                
            
            }
           });
            int count =0;
            foreach(var key in  filedata.Keys)
            {
                List<String> fileLines = filedata[key];
                count +=fileLines.Count;
            }

           Console.WriteLine(String.Format("Total files read are {0} and total lines read are {1}",filedata.Keys.Count,count));
           Console.ReadLine();
        }
    }
}
