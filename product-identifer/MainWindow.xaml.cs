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

            using (var context = new ProductsModel())
            {
                var productInfo = (from products in context.products
                                   join productImgs in context.product_images
                                     on products.material_no equals productImgs.material_no
                                   join productHierarchies in context.product_hierarchies
                                     on products.hierarchy_id equals productHierarchies.hierarchy_id
                                   where products.upc == upc
                                   select new
                                   {
                                       products.material_no,
                                       products.upc,
                                       products.description,
                                       products.uom,
                                       products.hierarchy_id,
                                       productHierarchies.hierarchy_description,
                                       productImgs.file_name,
                                   }).FirstOrDefault();

            }
        }
    }
}
