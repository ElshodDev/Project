//=================================================
//Copyright (c) Coalition of Good-Hearted Engineers
// Free To use Comfort and peace
//=================================================
using EFxceptions;
using Microsoft.EntityFrameworkCore;

namespace Project.Api.Brokers.Storages
{
    public partial class StorageBroker:EFxceptionsContext, IStorageBroker
    {
        private readonly IConfiguration configuration;

        public StorageBroker(IConfiguration configuration)
        {
            this.configuration=configuration;
            this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          string  ConnectionString = this.configuration.GetConnectionString(name: "DefaultConnection");
            optionsBuilder.UseSqlServer(ConnectionString);
        }
        public override void Dispose() { }
       
    }
    }

