using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProductMenegmentClient
{
    /// <summary>
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView: BaseView<ICustomerView, CustomerPresenter>, ICustomerView
    {
        public CustomerView()
            : base()
        {
            InitializeComponent();

            Presenter.OnViewInitialized();
        }

        public void SetCustomerModelAsDataContext(CustomerModel customerModel)
        {
            this.DataContext = customerModel;
        }

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
        }


    }
}