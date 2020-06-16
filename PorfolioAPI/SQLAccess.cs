using PortfolioAPI.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioAPI
{
    public class SQLAccess
    {
        public List<Project> GetProjects()
        {
            List<Project> projects = new List<Project>();
            using (SqlConnection connection = new SqlConnection(AccessDB().ConnectionString))
            {
                string sql = "SELECT * FROM Projects";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            projects.Add(new Project(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(0), reader.GetString(5), reader.GetString(6)));
                        }
                    }
                    connection.Close();
                }
                sql = "SELECT * FROM ProjectLinks";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            projects[reader.GetInt32(1)].otherLinks.Add(new Links { name = reader.GetString(2), link = reader.GetString(3) });
                        }
                    }
                    connection.Close();
                }
            }
            return new List<Project>();
        }

        public void AddNewProject(Project project)
        {
            using (SqlConnection connection = new SqlConnection(AccessDB().ConnectionString))
            {
                string sql = "INSERT INTO Projects (Name, SmallDescription, Description, ImagePath, TrelloLink, GithubLink) VALUES(" + project.name + "," + project.smallDescriptiom + "," + project.description + "," + project.imagePath + "," + project.trelloLink + "," + project.githubLink + ")";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void GetSpecificProject(int id)
        {
            Project project = new Project();
            using (SqlConnection connection = new SqlConnection(AccessDB().ConnectionString))
            {
                string sql = "SELECT * WHERE Id="+id+" FROM Projects";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            project = new Project(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(0), reader.GetString(5), reader.GetString(6));
                        }
                    }
                    connection.Close();
                }
                sql = "SELECT * WHERE ProjectId="+project.id+" FROM ProjectLinks";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            project.otherLinks.Add(new Links { name = reader.GetString(2), link = reader.GetString(3) });
                        }
                    }
                    connection.Close();
                }
            }
        }

            private SqlConnectionStringBuilder AccessDB()
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                ResourceManager resx = new ResourceManager("PortfolioAPI.DB_Data", Assembly.GetExecutingAssembly());
                builder.DataSource = resx.GetString("datasource");
                builder.UserID = resx.GetString("UserId");
                builder.Password = resx.GetString("password");
                builder.InitialCatalog = resx.GetString("DB");
                return builder;
            }
        }
    }
