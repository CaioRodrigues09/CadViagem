using CadViagem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadViagem.Repositories
{
    public interface IDriverRepository
    {
        DriverViewModel GetById(Guid id);
        List<DriverViewModel> SearchAll();
        DriverViewModel AddDriver(DriverViewModel driver);
        DriverViewModel UpdateDriver(DriverViewModel driver);
        bool Delete(Guid id);
    }
}
