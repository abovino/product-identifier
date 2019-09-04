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

namespace product_identifer
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

        private void handleSearch(object sender, RoutedEventArgs e)
        {
            var upc = upcTxt.Text;
            var context = new ProductModel();

            var query = from p in context.products
                        where p.upc == upc
                        select p;

            var selectedProduct = query.FirstOrDefault<Product>();

            descriptionTxt.Text = selectedProduct.description;
            hierarchyIdTxt.Text = selectedProduct.hierarchy_id;


            //MessageBox.Show("hi");
        }
    }
}
