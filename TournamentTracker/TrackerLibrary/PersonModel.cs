using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary
{
    public class PersonModel
    {
        /// <summary>
        /// Represents the first name of the team player.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Represents the last name of the team player.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Represents the email address of the team player 
        /// for receiving notifications.
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// Represents the cellphone number of the team player 
        /// for receiving text notifications.
        /// </summary>
        public string CellphoneNumber { get; set; }

    }
}
