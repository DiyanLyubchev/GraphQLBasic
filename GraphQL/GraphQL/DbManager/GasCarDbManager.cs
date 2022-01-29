using GraphQL.Db.Context;
using GraphQL.Db.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQL.DbManager
{
    public class GasCarDbManager : IGasCarDbManager
    {
        private readonly GasCarDbContext context;

        public GasCarDbManager(GasCarDbContext context)
        {
            this.context = context;
        }

        public async Task<int> AddNewCarAsync(GasCarTable car)
        {
            // int carId = await GetNextValueAsync();

            //  car.Id = carId;

            var newCar = await this.context.GasCars.AddAsync(car);
            await this.context.SaveChangesAsync();


            return newCar.Entity.Id;
        }

        public async Task DeleteAsync(int carId)
        {
            var currentCar = await this.context.GasCars
                .SingleOrDefaultAsync(id => id.Id == carId);

            this.context.GasCars.Remove(currentCar);
            await this.context.SaveChangesAsync();
        }

        public async Task<List<GasCarTable>> GetAllCarsAsync()
        {
            return await this.context.GasCars
                .ToListAsync();
        }

    }
}
