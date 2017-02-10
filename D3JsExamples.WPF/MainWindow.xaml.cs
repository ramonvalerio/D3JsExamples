using D3JsExamples.WPF.dto;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows;

namespace D3JsExamples.WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnStackedBar_Click(object sender, RoutedEventArgs e)
        {
            webBrowserChar.Source = new Uri(string.Format(@"file:///{0}/Html/stacked_bar/chart_stacked_bar.html", Directory.GetCurrentDirectory()));
            //string json = JsonConvert.SerializeObject(ChartStackedBarDTO.GetData());

            //webBrowserChar.InvokeScript("GerarGrafico");
            //webBrowserChar.InvokeScript("GerarGrafico", "3", "1.123, 2.456, 3.789");
            //webBrowserChar.InvokeScript("GerarGrafico", json);
            //webBrowserChar.InvokeScript("ChartJS");
        }
    }
}