using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinimalApi.Domain.ModelViews
{
    public class Home
    {
        public string Message {get => "Welcome to the Vehicles API"; }

        public string Documentation {get => "/swagger"; }
    }
}