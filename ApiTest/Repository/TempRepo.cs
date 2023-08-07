using ApiTest.DataBase;
using ApiTest.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Repository
{
    public class TempRepo  
    {
        private readonly ApplicationDbContext _db;

        public TempRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<CustomerModel>> Add(CustomerModel customer)
        {
            _db.Customers.Add(customer);
            await _db.SaveChangesAsync();
            return await _db.Customers.ToListAsync();
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

        public async Task<List<CustomerModel>> GetAll()
        {
            var customeres = await _db.Customers.ToListAsync();
            return customeres;
        }

        public async Task<CustomerModel?> GetById(int id)
        {
            var customer = await _db.Customers.FindAsync(id);
            if (customer is null)
                return null;

            return customer;
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
