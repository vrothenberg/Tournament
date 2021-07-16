using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary.Models
{
    public class TeamModel
    {
        /// <summary>
        /// The unique identifier for the team.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The team name.  
        /// </summary>
        public string TeamName { get; set; }
        /// <summary>
        /// The list of team players. 
        /// </summary>
        public List<PersonModel> TeamMembers { get; set; } = new List<PersonModel>();


    }
}
