using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace SKY
{
    /// <summary>
    /// Interaction logic for LiveChartUserControl.xaml
    /// </summary>
    public partial class LiveChartUserControl : UserControl
    {

        

            public LiveChartUserControl()
        {
            InitializeComponent();

            Values = new ChartValues<double> { 150, 375, 420, 500, 160, 140 };

            DataContext = this;
        }
        public ChartValues<double> Values { get; set; }

        private void UpdateOnclick(object sender, RoutedEventArgs e)
        {
            Chart.Update(true);
        }
    }
}
