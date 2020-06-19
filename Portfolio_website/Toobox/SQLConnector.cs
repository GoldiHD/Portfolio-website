using Portfolio_website.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Cosmos;
using System.Resources;
using System.Reflection;

namespace Portfolio_website.Toobox
{
    public class SQLConnector 
    {
        ResourceManager resx = new ResourceManager("PortfolioAPI.DB_Data", Assembly.GetExecutingAssembly());
        CosmosClient cosmosClient;

        public async Task CreateSQLConnector()
        {
            cosmosClient = new CosmosClient(resx.GetString("EndpointUrl"), resx.GetString("AuthorizationKey"));
            await CreateDBIfItNotExists();
        }

        public async Task CreateDBIfItNotExists()
        {
            CosmosDatabase db = await cosmosClient.CreateDatabaseIfNotExistsAsync(resx.GetString("DatabaseId"));
        }


        public List<ProjectsModel> GetProjects()
        {
            return new List<ProjectsModel>();
        }
    }
}
