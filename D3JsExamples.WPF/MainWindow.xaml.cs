using D3JsExamples.WPF.DTO;
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

            btnGerarGrafico.IsEnabled = false;

            webBrowserChart.LoadCompleted += WebBrowserChart_LoadCompleted;
            btnGerarGrafico.Click += btnGerarGrafico_Click;
            rbStackedBar.Click += GraficoSelecionado_Click;
        }

        private void WebBrowserChart_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            btnGerarGrafico.IsEnabled = true;
        }

        private void GraficoSelecionado_Click(object sender, RoutedEventArgs e)
        {
            if (((bool)rbStackedBar.IsChecked))
            {
                webBrowserChart.Source = new Uri(string.Format(@"file:///{0}/Html/stacked_bar/chart_stacked_bar.html", Directory.GetCurrentDirectory()));
                //webBrowserChart.Source = new Uri(string.Format(@"file:///{0}/Html/bar/chart_bar.html", Directory.GetCurrentDirectory()));
            }
        }

        private void btnGerarGrafico_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string json = JsonConvert.SerializeObject(ChartBarDTO.GetData());

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