using src.Clients.Admin.ManageCustomer;
using src.Clients.Admin.ManageRooms;
using src.Clients.Admin.ManageUser;

namespace src.Services.Admin.Manager
{
    public class RegristServices
    {
        private readonly WebApplicationBuilder _builder = null!;
        public RegristServices(WebApplicationBuilder builder)
        {
            _builder = builder;
        }

        public void AddAllServices()
        {
            AddManagerCustomerServices();
            AddMangerRoomServices();
        }
        private void AddManagerCustomerServices()
        {
            _builder.Services.AddTransient<ICreateCustomer, CreateCustomer>();
            _builder.Services.AddScoped<IGetCustomer, GetCustomer>();
            _builder.Services.AddScoped<IUpdateCustomer, UpdateCustomer>();
        }
        private void AddMangerRoomServices()
        {
            _builder.Services.AddScoped<ICRURoom, CRDRoom>();
        }
    }
}
