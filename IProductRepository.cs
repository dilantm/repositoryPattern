using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterViewCartV1.Models;

namespace InterViewCartV1.Repository.Interface
{
    public interface IProductRepository
    {
        IList<Product> GetProductsByCategory(string category);
    }
}
