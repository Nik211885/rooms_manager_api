using src.Data;

namespace src.SeederData
{
    public static class SeederData
    {
        public async static Task SeederDataAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetService<RoomsManagerDbConText>();
                if (db != null)
                {
                    await SeederAdmin.SeederAsync(db);
                    await SeederCustomer.SeederAsync(db);
                }
            };
        }
    }
}
