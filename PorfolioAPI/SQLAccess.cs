using PortfolioAPI.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioAPI
{
    public class SQLAccess
    {
        public List<Project> GetProjects()
        {
            //Test
            return new List<Project>();
        }

        public void AddNewProject()
        {
            using (SqlConnection connection = new SqlConnection(AccessDB().ConnectionString))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT TOP")
            }
        }

        private SqlConnectionStringBuilder AccessDB()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "portfolio-server.database.windows.net";
            builder.UserID = "lars6305";
            builder.Password = "";

            return builder;
        }

    }
}
