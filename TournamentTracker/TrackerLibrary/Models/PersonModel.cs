using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerLibrary.Models
{
    public class PersonModel
    {
        /// <summary>
        /// The unique identifier for the person.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The first name of the team player.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// The last name of the team player.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// The email address of the team player 
        /// for receiving notifications.
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// The cellphone number of the team player 
        /// for receiving text notifications.
        /// </summary>
        public string CellphoneNumber { get; set; }

        public string FullName
        {
            get
            {
                return $"{ FirstName } {LastName }";
            }
        }


    }
}
