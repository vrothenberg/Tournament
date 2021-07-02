using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary
{
    public class TeamModel
    {
        /// <summary>
        /// Represents the list of team players. 
        /// </summary>
        public List<PersonModel> TeamMembers { get; set; } = new List<PersonModel>();
        /// <summary>
        /// Represents the team name.  
        /// </summary>
        public string TeamName { get; set; }

    }
}
