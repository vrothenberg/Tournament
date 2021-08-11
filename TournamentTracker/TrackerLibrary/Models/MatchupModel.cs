using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary.Models
{
    public class MatchupModel
    {
        /// <summary>
        /// The unique identifier for a matchup of competing teams, or a single team during a bye.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Represents the matchup entries (competing teams) for a matchup in a round.
        /// </summary>
        public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();
        /// <summary>
        /// The ID from the database that will be used to identify winner.
        /// </summary>
        public int WinnerId { get; set; }
        /// <summary>
        /// Represents the winning team.
        /// </summary>
        public TeamModel Winner { get; set; }
        /// <summary>
        /// Represents the number of the round.  There can be multiple matchups in a single round.  
        /// </summary>
        public int MatchupRound { get; set; }

        public string DisplayName 
        { 
            get
            {
                string output = "";

                foreach (MatchupEntryModel me in Entries)
                {
                    if (me.TeamCompeting != null)
                    {
                        if (output.Length == 0)
                        {
                            output = me.TeamCompeting.TeamName;
                        }
                        else
                        {
                            output += $" vs. { me.TeamCompeting.TeamName }";
                        }
                    }
                    else
                    {
                        output = "Matchup Not Yet Determined";
                        break;
                    }
                }

                return output;
            }
        }




    }
}
