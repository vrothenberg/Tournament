﻿using System;
using System.Collections.Generic;
using System.Text;
using TrackerLibrary.DataAccess;
using System.Configuration;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public static IDataConnection Connection { get; private set; }


        public static void InitializeConnections(DatabaseType db)
        {            
            if (db == DatabaseType.Sql)
            {
                // TODO - Setup SQL connection properly
                SqlConnector sql = new SqlConnector();
                Connection = sql;
            }
            else if (db == DatabaseType.TextFile)
            {
                // TODO - Create Text connection 
                TextConnector text = new TextConnector();
                Connection = text;
            }
        }

        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
