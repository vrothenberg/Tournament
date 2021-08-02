using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary.Models
{
    public class MatchupModel
    {
        /// <summary>
        /// The unique identifier for the matchup.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Represents the matchups for a round.
        /// </summary>
        public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();
        /// <summary>
        /// Represents the winning team.
        /// </summary>
        public TeamModel Winner { get; set; }
        /// <summary>
        /// Represents the number of the round.
        /// </summary>
        public int MatchupRound { get; set; }




    }
}
