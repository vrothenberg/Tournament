using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();

        public static void InitializeConnections(bool database, bool textFiles)
        {
            
            if (database)
            {
                // TODO - Setup SQL connection properly
                SqlConnector sql = new SqlConnector();
                Connections.Add(sql);
            }

            if (textFiles)
            {
                // TODO - Create Text connection 
                TextConnection text = new TextConnection();
                Connections.Add(text);
            }
        }
    }
}
