using GraphQL.Db.Context;
using GraphQL.Db.Models;
using HotChocolate;
using HotChocolate.Data;
using System.Linq;

namespace GraphQL.GraphQLServices
{
    public class Qurey
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<GasCarTable> GetCars([Service] GasCarDbContext dbContext)
            => dbContext.GasCars;


        public GasCarTable GetCar([Service] GasCarDbContext dbContext, int id)
            => dbContext.GasCars.FirstOrDefault(x => x.Id == id);

    }
}
