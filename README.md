# Tournament
Tournament tracker C# application

## Requirements
 * Track games played and their outcome.
 * Multiple competitors play in tournament.
 * Create a tournament plan of who plays in what order.
 * Schedule games.
 * A single loss eliminates player.
 * Last player is the winner.

## Feature List
 * The application should be able to handle a variable number of players in a tournament.
 * A tournament with less than the perfect number of players (multiples of 2) should add in 'byes'.  Certain players get selected at random to skip the first round.
 * The ordering of the tournament should be random.
 * The games are not scheduled, they can be played in whatever order and whenever players want to play them.
 * Each round must be fully completed before games in the next round are played.  
 * Simple score should be stored with a number for each player.  
 * The front-end for the system should be a desktop application for now.
 * Data should be stored in a Microsoft SQL database, but also allow for storing to a text file.
 * The tournament should have an option for charging an entry fee.  Prizes are another option, with the administrator choosing how much money to award a variable number of places.  The total cash amount should not exceed the income from the tournament.  A percentage-based system would also be useful.
 * Simple report specifying the outcome of games per round as well as a report that specifies who won and how much they won.  These can be displayed on a form or emailed to the tournament competitors.
 * Anyone using the application should be able to fill in game scores.
 * The only method of varied access is if the competitors are not allowed into the application and only do everything by email.
 * The system should email users that they are due to play in a round as well as who they are scheduled to play.
 * The tournament tracker should be able to handle the addition of other members.  All members are treated as equals and all get emails.  Teams should also be able to name their team.  

## Overall Design
**Structure:** Windows Forms application and Class Library

**Data:** SQL and/or Text File

**Users:** One at a time on one application

**Key Concepts**
 * Email
 * SQL
 * Custom Events
 * Error Handling
 * Interfaces
 * Random Ordering
 * Texting

## Data Map
**Team**
 * TeamMembers(List<Person>)
 * TeamName (string)

**Person** 
 * FirstName (string)
 * LastName (string)
 * EmailAddress (string)
 * CellphoneNumber (string)

**Tournament**
 * TournamentName (string)
 * EntryFee (decimal)
 * EnteredTeams (List<Team>)
 * Prizes (List<Prize>)
 * Rounds (List<List<Matchup>>)

**Prize**
 * PlaceNumber (int)
 * PlaceName (string)
 * PrizeAmount (decimal)
 * PrizePercentage (double)

**Matchup**
 * Entries (List<MatchupEntry>)
 * Winner (Team)
 * MatchupRound (int)

**MatchupEntry**
 * TeamCompeting (Team)
 * Score (double)
 * ParentMatchup (Matchup)

