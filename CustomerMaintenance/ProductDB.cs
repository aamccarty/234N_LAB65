using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
namespace CustomerMaintenance
{
    public class ProductDB
    {

        public static Product GetProduct(string prodCode)
        {
            SqlConnection connection = MMABooksDB.GetConnection();
            string selectStatement
                = "SELECT * "
                + "FROM Products "
                + "WHERE ProductCode = @ProdcutCode";
            SqlCommand selectCommand =
                  new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ProductCode", prodCode);

            try
            {
                connection.Open();
                SqlDataReader prodReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (prodReader.Read())
                {
                    Product product = new Product();
                    product.ProductCode = prodReader["ProductCode"].ToString();
                    product.Description = prodReader["Description"].ToString();
                    product.UnitPrice = (decimal)prodReader["UnitPrice"];
                    product.ProductCode = prodReader["ProductCode"].ToString();
                    prodReader.Close();
                    return product;
                }
                else
                {
                    return null;
                }

            }
            catch
            {

            }
        }


    }
}
