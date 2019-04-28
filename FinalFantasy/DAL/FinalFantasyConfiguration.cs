using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace FinalFantasy.DAL
{
    public class FinalFantasyConfiguration : DbConfiguration
    {
        public FinalFantasyConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }
    }
}