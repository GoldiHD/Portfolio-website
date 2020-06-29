using Portfolio_website.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading.Tasks;

namespace Portfolio_website.Toobox
{
    public class SingleTon
    {
        private static readonly ResourceManager resx = new ResourceManager("Portfolio_website.Resourceses.ConstData", Assembly.GetExecutingAssembly());
        private static SQLConnector SQLConnectorInstance;

        public static string getResources(string Access)
        {
            return resx.GetString(Access);
        }

        public static SQLConnector GetSQLConnector()
        {
            if(SQLConnectorInstance == null)
            {
                SQLConnectorInstance = new SQLConnector();
            }
            return SQLConnectorInstance;
        }

    }
}
