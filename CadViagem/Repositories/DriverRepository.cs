using CadViagem.Data;
using CadViagem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadViagem.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        private readonly DataBaseContext _dataBaseContext;
        public DriverRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public DriverViewModel AddDriver(DriverViewModel driver)
        {
            _dataBaseContext.Driver.Add(driver);
            _dataBaseContext.SaveChanges();

            return driver;
        }

        public List<DriverViewModel> SearchAll()
        {
            return _dataBaseContext.Driver.ToList();
        }
        public DriverViewModel GetById(Guid Id)
        {
            return _dataBaseContext.Driver.FirstOrDefault(x => x.Id == Id);
        }

        public DriverViewModel UpdateDriver(DriverViewModel driver)
        {
            DriverViewModel driverDB = GetById(driver.Id);

            if (driverDB == null) throw new System.Exception("Houve um erro na atualização do motorista !");
            driverDB.FirstName = driver.FirstName;
            driverDB.LastName = driver.LastName;
            driverDB.Cep = driver.Cep;
            driverDB.StreetName = driver.StreetName;
            driverDB.StreetNumber = driver.StreetNumber;
            driverDB.StreetComplement = driver.StreetComplement;
            driverDB.Uf = driver.Uf;
            driverDB.Municipio = driver.Municipio;
            driverDB.District = driver.District;
            driverDB.Truck = driver.Truck;
            driverDB.Marck = driver.Marck;
            driverDB.Axis = driver.Axis;
            driverDB.Model = driver.Model;
            driverDB.Plaque = driver.Plaque;

            _dataBaseContext.Driver.Update(driverDB);
            _dataBaseContext.SaveChanges();

            return driverDB;
        }

        public bool Delete(Guid id)
        {
            DriverViewModel driverDB = GetById(id);

            if (driverDB == null) throw new System.Exception("Houve um erro ao apagar o motorista!");

            _dataBaseContext.Driver.Remove(driverDB);
            _dataBaseContext.SaveChanges();

            return true;
        }
    }
}
