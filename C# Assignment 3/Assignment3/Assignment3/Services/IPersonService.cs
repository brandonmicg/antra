using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Services
{
    public interface IPersonService
    {
        int CalculateAge();
        decimal CalculateSalary();
        List<string> GetAddress();
    }
}
