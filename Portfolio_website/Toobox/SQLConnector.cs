using Portfolio_website.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Cosmos;
using System.Resources;
using System.Reflection;
using Portfolio_website.Entities;
using System.Net;
using System.ComponentModel;

namespace Portfolio_website.Toobox
{
    public class SQLConnector
    {
        CosmosClient cosmosClient;

        public async Task CreateSQLConnector()
        {
            cosmosClient = new CosmosClient(SingleTon.getResources("EndpointUrl"), SingleTon.getResources("AuthorizationKey"));
            await GetDB();
            await GetContainer();
        }

        public SQLConnector()
        {
            CreateSQLConnector();
        }

        private async Task<CosmosDatabase> GetDB()
        {
            try
            {
                await cosmosClient.CreateDatabaseIfNotExistsAsync(SingleTon.getResources("DatabaseId"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return cosmosClient.GetDatabase(SingleTon.getResources("DatabaseId"));
        }

        private async Task<CosmosContainer> GetContainer()
        {
            try
            {
                await cosmosClient.GetDatabase(SingleTon.getResources("DatabaseId")).CreateContainerIfNotExistsAsync(new ContainerProperties() { Id = Guid.NewGuid().ToString(), PartitionKeyPath = "/pk", IndexingPolicy = new IndexingPolicy() { Automatic = true, IndexingMode = IndexingMode.Consistent } });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            CosmosContainer container = null;
            try
            {
                container = cosmosClient.GetContainer(SingleTon.getResources("DatabaseId"), SingleTon.getResources("ContainerId"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return container;
        }

        public async Task<List<Project>> GetProjects()
        {
            var sqlQueryText = "SELECT * FROM C";
            CosmosContainer CContainer = await GetContainer();
            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
            List<Project> projects = new List<Project>();
            await foreach (Project project in CContainer.GetItemQueryIterator<Project>(queryDefinition))
            {
                projects.Add(project);
            }
            return projects;
        }

        public async Task AddNewItemToContainerAsync(Project project)
        {
            CosmosContainer container = await GetContainer();
            try
            {
                ItemResponse<Project> newProjecResponse = await container.ReadItemAsync<Project>(project.Id.ToString(), new PartitionKey(project.name));
            }
            catch (CosmosException ex) when (ex.Status == (int)HttpStatusCode.NotFound)
            {
                ItemResponse<Project> newProjecResponse = await container.CreateItemAsync<Project>(project, new PartitionKey(project.name));
            }
        }

        private async Task QueryItemsAsync(string search)
        {
            var sqlQueryText = "SELECT * FROM C WHERE C.name = '" + search + "'";
            CosmosContainer CContainer = await GetContainer();
            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
            List<Project> projects = new List<Project>();
            await foreach (Project project in CContainer.GetItemQueryIterator<Project>(queryDefinition))
            {
                projects.Add(project);
            }
        }
    }
}
