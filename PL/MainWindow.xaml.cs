using BL;
using BE;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MyBL bL;
        public MainWindow()
        {
            InitializeComponent();
            bL = MyBL.Instance;
            string hostingUnitName = "Nave Mahmad";
            bL.addHostingUnit(new HostingUnit(new Host(), hostingUnitName, Enums.HostingUnitType.Zimmer));
            bL.addOrder(new BE.Order(Enums.OrderStatus.Closed, DateTime.Now));

            lb_HostingUnits.DataContext = bL.getAllHostingUnits();
            // lb_HostingUnits.DataContext = bL.getHostingUnits(hostingUnit => hostingUnit.HostingUnitType == Enums.HostingUnitType.Zimmer);

            
        }

        private void pb_AddEditHostingUnit_Click(object sender, RoutedEventArgs e)
        {
            new AddHostingUnit(new HostingUnit(new Host(), "Nave Tikva",Enums.HostingUnitType.Camping)).Show();
        }

        private void lb_HostingUnits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gridHostingUnitDetails.DataContext = (sender as ListBox).SelectedItem as HostingUnit;
          //  new AddHostingUnit((sender as ListBox).SelectedItem as HostingUnit).Show();
        }

        private void lb_HostingUnits_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new AddHostingUnit((sender as ListBox).SelectedItem as HostingUnit).Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource hostingUnitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hostingUnitViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // hostingUnitViewSource.Source = [generic data source]
        }

        private void Window_GotFocus(object sender, RoutedEventArgs e)
        {
            lb_HostingUnits.DataContext = bL.getAllHostingUnits();
        }
    }
}
