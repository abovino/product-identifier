using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace product_identifer
{

    class Stock
    {
        public int qty { get; set; }
        public int packSize { get; set; }
        public int packs { get; set; }
        public string uom { get; set; }
        public string plantId { get; set; }
        public string binLocation { get; set; }
    }

    class Product
    {
        public string upc { get; private set; }
        public List<Stock> stock { get; private set; }

        public Product(string upc)
        {
            this.upc = upc;
            this.stock = setStock();
        }

        private List<Stock> setStock()
        {
            var listOfStock = new List<Stock>();
            string connStr = "Server=DESKTOP-VPQMC35\\SQLEXPRESS;Database=product_identifier;Trusted_Connection=True;";
            string query = $@"select i.qty, p.pack_size, i.plant_id, i.bin_location, p.uom
                            from inventory AS i
                            LEFT JOIN products AS p
	                        ON p.material_no = p.material_no WHERE p.upc = '{this.upc}'";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader dr = command.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        var stock = new Stock();
                        stock.qty = Convert.ToInt32(dr["qty"].ToString());
                        stock.packSize = Convert.ToInt32(dr["pack_size"].ToString());
                        stock.uom = dr["uom"].ToString();
                        stock.plantId = dr["plant_id"].ToString();
                        stock.binLocation = dr["bin_location"].ToString();

                        stock.packs = stock.qty / stock.packSize;

                        listOfStock.Add(stock);
                    }
                }

                return listOfStock;
            }
        }

    }
}
