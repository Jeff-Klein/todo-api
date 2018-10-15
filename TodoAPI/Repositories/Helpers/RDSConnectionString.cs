using System;

namespace TodoAPI.Repositories.Helpers
{
    public static class RDSConnectionString
    {
        public static string GetRDSConnectionString()
        {
            string dbname = "tododb";
            string username = "jeferson";
            string password = "supero123";
            string hostname = "tododb.csbrplja2mdv.us-east-2.rds.amazonaws.com,1433";

            return String.Concat("Data Source=", hostname, ";Initial Catalog=", dbname, 
                                 ";User ID=", username, ";Password=", password, ";");
        }
    }
}