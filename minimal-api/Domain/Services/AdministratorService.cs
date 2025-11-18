using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Entities;
using MinimalApi.Domain.Interfaces;
using MinimalApi.Domain.DTOs;
using MinimalApi.Infrastructure.Db;

namespace MinimalApi.Domain.Services
{
    public class AdministratorService : IAdministratorService
    {
        private readonly MyDbContext _context;

        public AdministratorService(MyDbContext context)
        {
            _context = context;
        }

        public List<Administrator> All(int? page = 1)
        {
            var query = _context.Administrators.AsQueryable();

            int itemsPerPage = 10;

            if (page == null || page <= 0)
            {
                // throw new Exception("Invalid page number");
                return new List<Administrator>();
            }

            query = query.Skip(((int) page - 1) * itemsPerPage).Take(itemsPerPage);

            return query.ToList();
        }

        public Administrator? FindById(int id)
        {
            return _context.Administrators.Find(id);
        }

        public Administrator? Login(LoginDTO loginDTO)
        {
            var adm = _context.Administrators.Where(a => 
                    a.Email == loginDTO.Email && 
                    a.Password == loginDTO.Password
                ).FirstOrDefault();

            return adm;
        }

        public Administrator Register(Administrator administrator)
        {
            _context.Administrators.Add(administrator);
            _context.SaveChanges();

            return administrator;
        }
    }
}