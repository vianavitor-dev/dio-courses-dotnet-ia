using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinimalApi.Domain.Enums;

namespace MinimalApi.Domain.ModelViews
{
    public record AdmLogged
    {
        public string Email { get; set; }   

        public AccountType AccountType { get; set; }   
        
        public string Token { get; set; }   
    }
}