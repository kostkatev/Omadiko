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
    public class CustomerRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();

        //Get All Customers
        public IEnumerable<Customer> GetAll()
        {
            return db.Customers.ToList();
        }

        //Get All Customers Asc Order By FirstName
        public IEnumerable<Customer> GetAllOrderedByFirstName()
        {
            return db.Customers.OrderBy(x => x.FirstName).ToList();
        }


        //Get All Customers Desc Order By FirstName
        public IEnumerable<Customer> GetAllOrderedByFirstNameDesc()
        {
            return db.Customers.OrderByDescending(x => x.FirstName).ToList();
        }

        //Find Customers By FirstName
        public IEnumerable<Customer> FilterByFIrstName(string name)
        {
            return db.Customers.Where(x => x.FirstName.Contains(name)).ToList();
        }

        //Get All Customers Asc Order By LastName
        public IEnumerable<Customer> GetAllOrderedByLastName()
        {
            return db.Customers.OrderBy(x => x.LastName).ToList();
        }

        //Get All Customers Desc Order By LastName
        public IEnumerable<Customer> GetAllOrderedByLastNameDesc()
        {
            return db.Customers.OrderByDescending(x => x.LastName).ToList();
        }

        //Find Customers By LastName
        public IEnumerable<Customer> FilterByLastName(string name)
        {
            return db.Customers.Where(x => x.LastName.Contains(name)).ToList();
        }

        //Find Customers By Id
        public Customer GetById(int? id)
        {
            return db.Customers.Find(id);
        }

        //Create Customer
        public void Insert(Customer customer)
        {
            db.Entry(customer).State = EntityState.Added;
            db.SaveChanges();
        }

        //Update Customer
        public void Update(Customer customer)
        {
            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();
        }

        //Delete Customer
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
