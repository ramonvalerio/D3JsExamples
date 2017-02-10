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

            webBrowserChart.Source = new Uri(string.Format(@"file:///{0}/Html/stacked_bar/chart_stacked_bar.html", Directory.GetCurrentDirectory()));
            btnStackedBar.IsEnabled = false;

            webBrowserChart.LoadCompleted += WebBrowserChart_LoadCompleted;
        }

        private void WebBrowserChart_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            btnStackedBar.IsEnabled = true;
        }

        private void btnStackedBar_Click(object sender, RoutedEventArgs e)
        {
            string json = JsonConvert.SerializeObject(ChartStackedBarDTO.GetData());

            try
            {
                webBrowserChart.InvokeScript("LimparGrafico");
                webBrowserChart.InvokeScript("GerarGrafico", json);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}