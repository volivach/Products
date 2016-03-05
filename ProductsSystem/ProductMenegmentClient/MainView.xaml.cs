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

namespace ProductMenegmentClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainView : BaseView<IMainView, MainPresenter>, IMainView
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void ProductsSearch_Click(object sender, RoutedEventArgs e)
        {
            Task foreverTask = new Task(() =>
            {
                for (;;); 
            });

            foreverTask.Start();
        }

        private void CustomersSearch_Click(object sender, RoutedEventArgs e)
        {
            Presenter.NavigateToCustomers();
        }

        public void NavigateToCustomers()
        {
            var customerView = new CustomerView();
            customerView.ShowInTaskbar = false;
            customerView.Owner = this as Window;
            customerView.Show();
        }
    }
}
