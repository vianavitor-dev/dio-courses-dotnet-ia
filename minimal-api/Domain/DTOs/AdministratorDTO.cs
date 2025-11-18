using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinimalApi.Domain.Enums;

namespace MinimalApi.Domain.DTOs
{
    public class AdministratorDTO
    {
        public string Email { get; set; }
        
        public string Password { get; set; }
        
        public AccountType AccountType { get; set; }
    }
}