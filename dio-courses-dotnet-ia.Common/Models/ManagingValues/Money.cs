using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace dio_courses_dotnet_ia.Common.Models.ManagingValues
{
    public class Money
    {
        public decimal Amount { get; set; }

        private CultureInfo _myCultureInfo;

        public CultureInfo MyCultureInfo
        {
            get
            {
                if (_myCultureInfo == null)
                {
                    return new CultureInfo("pt-BR");
                }
                
                return _myCultureInfo;
            }
            set { _myCultureInfo = value; }
        }

        public void showFormatedAmount(String format = "C")
        {
            CultureInfo.DefaultThreadCurrentCulture = MyCultureInfo;
            Console.WriteLine(Amount.ToString(format));
        }

    }
}