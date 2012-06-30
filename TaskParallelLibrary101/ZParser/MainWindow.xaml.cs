using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.IO;

namespace ZParser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = "*.laf";
            dlg.Multiselect = true;
            dlg.InitialDirectory = @"C:\Users\anu\Documents\ZukenParserFiles";
            Nullable<bool> result = dlg.ShowDialog();
            List<String> files = new List<string>();
            if (result == true)
            {
                files.AddRange(dlg.FileNames);
                int count = files.Count;
                List<Task> tasks = new List<System.Threading.Tasks.Task>();
                int taskCount = 1;
                foreach (var fn in files)
                {
                    Task<List<String>> task1 = Task.Factory.StartNew<List<String>>(
                         () =>
                         {
                             Debug.WriteLine("Executing task");
                             List<String> fileLines = new List<string>();
                             using (StreamReader reader = new StreamReader(fn))
                             {
                                 do
                                 {
                                     String readLine = reader.ReadLine();
                                     fileLines.Add(readLine);
                                     Trace.WriteLine(String.Format("{0}::{1}::{2}",taskCount,DateTime.Now.ToLongTimeString(),readLine));
                                 } while (reader.Peek() != -1);
                                 
                             }
                             Trace.WriteLine("Task Count " +taskCount +"total lines read are" + fileLines.Count);
                             taskCount++;
                             return fileLines;
                         }
                        );
                    tasks.Add(task1);

                }
                Dictionary<int, List<String>> dic = new Dictionary<int, List<string>>();
                int i = 0;
                foreach (Task t in tasks)
                {
                    
                    i++;
                }
            }


            Console.ReadLine();


        }

    }
}
