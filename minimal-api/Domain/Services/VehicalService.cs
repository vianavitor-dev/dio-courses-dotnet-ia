using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using minimal_api.Domain.Entities;
using MinimalApi.Domain.Interfaces;
using MinimalApi.Infrastructure.Db;

namespace minimal_api.Domain.Services
{
    public class VehicalService : IVehicalService
    {
        private readonly MyDbContext _context;

        public VehicalService(MyDbContext context)
        {
            _context = context;
        }

        public List<Vehical> All(int page = 1, string? name = null, string? brand = null)
        {
            var query = _context.Vehicals.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(v => EF.Functions.Like(v.Name.ToLower(), $"%{name.ToLower()}%"));
            }
            if (!string.IsNullOrEmpty(brand))
            {
                query = query.Where(v => EF.Functions.Like(v.Brand.ToLower(), $"%{brand.ToLower()}%"));
            }

            int itemsPerPage = 10;

            query = query.Skip((page - 1) * itemsPerPage).Take(itemsPerPage);

            return query.ToList();
        }   

        public void Delete(Vehical vehical)
        {
            _context.Vehicals.Remove(vehical);
            _context.SaveChanges();
        }

        public Vehical? FindById(int id)
        {
            return _context.Vehicals.Where(v => v.Id == id).FirstOrDefault();
        }

        public void Insert(Vehical vehical)
        {
            _context.Vehicals.Add(vehical);
            _context.SaveChanges();
        }

        public void Update(Vehical vehical)
        {
            _context.Vehicals.Update(vehical);
            _context.SaveChanges();
        }
    }
}