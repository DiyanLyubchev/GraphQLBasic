using GraphQL.Db.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQL.DbManager
{
    public interface IGasCarDbManager
    {
        Task<int> AddNewCarAsync(GasCarTable car);
        Task DeleteAsync(int carId);
        Task<List<GasCarTable>> GetAllCarsAsync();
    }
}