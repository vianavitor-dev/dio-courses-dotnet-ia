using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinimalApi.Domain.Entities;
using MinimalApi.Domain.DTOs;

namespace MinimalApi.Domain.Interfaces
{
    public interface IAdministratorService
    {
        Administrator Register(Administrator administrator);

        List<Administrator> All(int? page);

        Administrator? FindById(int id);

        Administrator? Login(LoginDTO loginDTO);
    }
}