using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using InterViewCartV1.App_Start;
using InterViewCartV1.Models;
using InterViewCartV1.Repository.Interface;

namespace InterViewCartV1.Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbContext _dbContext;

        public ProductRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Product> GetProductsByCategory(string category)
        {
            using (SqlCommand sqlCommand = new SqlCommand("SelectProductByCategory_V1", _dbContext.Connection()))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@brand", SqlDbType.VarChar).Value = category;
                DataTable dataTable = new DataTable();
                dataTable = _dbContext.selectAll(sqlCommand);

                IList<Product> products = new List<Product>();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Product product = new Product();
                    product.MobileId = Int32.Parse(dataTable.Rows[i]["slNo"].ToString());
                    product.MobileName = dataTable.Rows[i]["MobileName"].ToString();
                    product.MobilePrice = float.Parse(dataTable.Rows[i]["Price"].ToString());
                    product.MobileUrl = dataTable.Rows[i]["url"].ToString();

                    products.Add(product);
                }
                return products;
            }

        }

    }
}