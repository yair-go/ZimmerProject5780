using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using BE;
using BL;

namespace PL
{
    /// <summary>
    /// Interaction logic for AddHostingUnit.xaml
    /// </summary>
    public partial class AddHostingUnit : Window
    {
        private MyBL bL;
        private HostingUnit hostingUnit;
        public AddHostingUnit(HostingUnit hostingUnit)
        {
            bL = MyBL.Instance;
            this.hostingUnit = hostingUnit;
            InitializeComponent();

            gridDetails.DataContext = hostingUnit;
            if (hostingUnit.HostingUnitName != null)
            {
                hostingUnitNameTextBox.IsEnabled = false;
            }
            hostingUnitTypeComboBox.ItemsSource = Enum.GetValues(typeof(Enums.HostingUnitType));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bL.addHostingUnit(hostingUnit);
        }
    }
}
