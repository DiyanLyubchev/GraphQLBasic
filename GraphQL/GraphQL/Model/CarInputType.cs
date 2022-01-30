using HotChocolate.Types;

namespace GraphQL.Model
{
    public class CarInputType :  InputObjectType<CarInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<CarInput> descriptor)
        {
            descriptor.Description("Represents the input to add for a platform.");

            descriptor
                .Field(p => p.CarBrand)
                .Description("Represents the car brand.");

            descriptor
             .Field(p => p.CarModel)
             .Description("Represents the car model.");


            base.Configure(descriptor);
        }
    }
}
