using Npgsql;
using System;

namespace project.utils
{
    public class Utils
    {
        public static NpgsqlConnection pgConnection()
        {
            return new NpgsqlConnection(String.Format("Server={0};User Id={1};Password={2};Database={3};",
                Constants.SERVER, Constants.USER, Constants.PASSWORD, Constants.DATABASE));
        }
    }
}