using ApiTest.DataBase;
using ApiTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Repository
{
    public class RepositoryModel 
    {
        ApplicationDbContext _db;

        public RepositoryModel()
        {
            _db = new ApplicationDbContext();
        }

        public async Task<List<CustomerModel>> Add(CustomerModel customer)
        {
            _db.Customers.Add(customer);
            await _db.SaveChangesAsync();
            return await _db.Customers.ToListAsync();
        }

        public bool AddRange(ICollection<CustomerModel> Customers)
        {
            _db.Customers.AddRange(Customers);
            return _db.SaveChanges() > 0;
        }

        public bool Update(CustomerModel Customer)
        {
            _db.Customers.Update(Customer);

            return _db.SaveChanges() > 0;
        }

        public async Task<List<CustomerModel>?> Delete(int id)
        {
            var customer = await _db.Customers.FindAsync(id);
            if (customer is null)
                return null;

            _db.Customers.Remove(customer);
            await _db.SaveChangesAsync();

            return await _db.Customers.ToListAsync();
        }

        public async Task<ActionResult<CustomerModel>> GetById(int id)
        {
            var customer = await _db.Customers.FindAsync(id);
            if (customer is null)
                return null;

            return customer;
        }

        public async Task<ActionResult<List<CustomerModel>>> GetAllAsync()
        {
            var customers = await _db.Customers.ToListAsync();
            return customers;
        }


       /* public async Task<List<CustomerModel>?> Updatecustomer(int id, CustomerModel request)
        {
            var customer = await _db.Customers.FindAsync(id);
            if (customer is null)
                return null;

            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
            customer.Name = request.Name;
            customer.Place = request.Place;

            await _db.SaveChangesAsync();

            return await _db.Customers.ToListAsync();
        }*/
    }
}
