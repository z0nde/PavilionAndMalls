using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavilionAndMalls.Pages.Manager_C.Malls
{
    public interface IQueryIdsMall
    {
        int IdCity(string City);
        int IdStatus(string Status);
    }
}
