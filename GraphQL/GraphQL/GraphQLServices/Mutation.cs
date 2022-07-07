using GraphQL.Db.Context;
using GraphQL.Db.Models;
using GraphQL.Model;
using HotChocolate;
using HotChocolate.Data;
using System.Threading.Tasks;

namespace GraphQL.GraphQLServices
{
    /// <summary>
    /// Represents the mutations available.
    /// </summary>
    public class Mutation
    {
        private readonly GasCarDbContext context;

        public Mutation(GasCarDbContext context)
        {
            this.context = context;
        }

        public async Task<GasCarTable> AddCar(CarInput input)
        {
            var car = new GasCarTable
            {
                CarBrand = input.CarBrand,
                CarModel = input.CarModel
            };

            context.GasCars.Add(car);
            var id = await context.SaveChangesAsync();

            car.Id = id;
            return car;
        }
    }
}
