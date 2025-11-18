using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.Domain.Entities;
using MinimalApi.DTOs;

namespace MinimalApi.Domain.Interfaces
{
    public interface IVehicalService
    {
        List<Vehical> All(int page = 1, string? name = null, string? brand = null);
        
        Vehical? FindById(int id);

        void Insert(Vehical vehical);

        void Update(Vehical vehical);

        void Delete(Vehical vehical);
    }
}