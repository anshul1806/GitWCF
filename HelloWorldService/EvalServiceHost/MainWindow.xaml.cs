using System.Windows;
using System.ServiceModel;
using System;
using System.Windows.Data;
namespace EvalServiceHost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded +=(s,e)=>
            {
                try
                {
                    ServiceHost svcHost = new ServiceHost(typeof(HelloWorldService.EvaluationService), new Uri("http://localhost:8080/evalService"));
                    svcHost.Open();
                    dg.ItemsSource = svcHost.Description.Endpoints;
                }
                catch (Exception ee)
                {

                    MessageBox.Show("Exception occured while instanting a service" +ee.Message);
                }
            };
        }
    }
}
