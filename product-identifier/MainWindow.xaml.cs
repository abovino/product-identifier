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

            Product product = new Product();
            List<Inventory> inventory = new List<Inventory>();

            using (var context = new ProductsModel())
            {
                product = GetProductInfo(context, upc);
                inventory = GetProductInventoryByPlant(context, product.material_no, "7010");

                if (product != null)
                {
                    // Update UI
                    UpdateUi(product);
                    UpdateStockGrid(inventory, "plant");
                }
                else
                {
                    MessageBox.Show("Product not found");
                }
            }
            
        }

        public Product GetProductInfo(ProductsModel context, string upc)
        {
            Product product = new Product();
            product = context.Products.Where(p => p.upc == upc).SingleOrDefault();

            return product;
        }

        public List<Inventory> GetProductInventoryByPlant(ProductsModel context, string materialNo, string plantId)
        {
            List<Inventory> inventory = new List<Inventory>();
            inventory = context.Inventories
                .Where(
                    i => (i.material_no == materialNo) && (i.plant_id == plantId)
                 ).ToList();

            return inventory;
        }

        public void UpdateUi(Product product)
        {
            this.descriptionTxt.Text = product.description;
            this.hierarchyIdTxt.Text = product.hierarchy_id;
            this.hierarchyTxt.Text = product.product_hierarchies.hierarchy_description;
            this.imgContainer.Source = new BitmapImage(new Uri($"H:\\C#\\product-identifier\\product-identifier\\Resources\\{product.product_images.file_name}", UriKind.Absolute));
        }

        public void UpdateStockGrid(List<Inventory> inventory, string plant)
        {
            MessageBox.Show(plant);
        }
    }
}
