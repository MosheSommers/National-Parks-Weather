using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public interface IParkDal
    {
        List<Park> GetParks();

        Park GetParkInfo(String parkCode);
    }
}
