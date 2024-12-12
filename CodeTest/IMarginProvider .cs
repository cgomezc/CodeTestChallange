using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaIngreso
{
    public interface IMarginProvider
    {
        Task<string> GetMarginAsync(string code);
    }
}
