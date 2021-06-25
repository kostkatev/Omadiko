using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Omadiko.Database;
using Omadiko.Entities;
using System.Data.Entity;

namespace Omadiko.RepositoryServices
{
    class CustomerRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();


        public IEnumerable<Customer> GetAll()
        {
            return db.Customers.ToList();
        }

        public IEnumerable<Customer> GetAllOrderedByName()
        {
            return db.Customers.OrderBy(x => x.Name).ToList();
        }

        public IEnumerable<Customer> FilterByName(string name)
        {
            return db.Customers.Where(x => x.Name.Contains(name)).ToList();
        }



        public Product GetById(int? id)
        {
            return db.Customers.Find(id);
        }

        public void Insert(Customer customer)
        {
            db.Entry(customer).State = EntityState.Added;
            db.SaveChanges();
        }

        public void Update(Customer customer)
        {
            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var customer = db.Customers.Find(id);

            db.Entry(customer).State = EntityState.Deleted;
            db.SaveChanges();
        }



        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
