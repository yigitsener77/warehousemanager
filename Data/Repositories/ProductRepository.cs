using Core.Abstracts.IRepositories;
using Core.Concretes.Entities;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Generics;

namespace Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DataContext db) : base(db)
        {
        }
    }
}
