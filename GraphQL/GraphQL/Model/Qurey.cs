using GraphQL.Db.Context;
using GraphQL.Db.Models;
using HotChocolate;
using HotChocolate.Data;
using System.Linq;

namespace GraphQL.Model
{
    public class Qurey
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<GasCarTable> GetCars([Service] GasCarDbContext dbContext)
            => dbContext.GasCars;

    }
}
