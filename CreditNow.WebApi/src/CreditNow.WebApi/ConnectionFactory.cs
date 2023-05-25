using Microsoft.Extensions.Configuration;

namespace ContactList.Infrastructure
{
    public abstract class ConnectionFactory
    {
        protected string ConnectionString { get; private set; }

        public ConnectionFactory(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("Postgresql");
        }
    }
}
