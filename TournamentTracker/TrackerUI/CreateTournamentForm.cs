using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreateTournamentForm : Form, IPrizeRequester, ITeamRequester
    {
        List<TeamModel> availableTeams = GlobalConfig.Connection.GetTeam_All();
        List<TeamModel> selectedTeams = new List<TeamModel>();
        List<PrizeModel> selectedPrizes = new List<PrizeModel>();
        public CreateTournamentForm()
        {
            InitializeComponent();

            WireUpLists();
        }

        private void WireUpLists()
        {
            selectTeamDropDown.DataSource = null;
            selectTeamDropDown.DataSource = availableTeams;
            selectTeamDropDown.DisplayMember = "TeamName";

            tournamentTeamsListBox.DataSource = null;
            tournamentTeamsListBox.DataSource = selectedTeams;
            tournamentTeamsListBox.DisplayMember = "TeamName";

            prizesListBox.DataSource = null;
            prizesListBox.DataSource = selectedPrizes;
            prizesListBox.DisplayMember = "PlaceName";
        }


        private void addTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel t = (TeamModel)selectTeamDropDown.SelectedItem;
            if (t != null)
            {
                availableTeams.Remove(t);
                selectedTeams.Add(t);

                WireUpLists();
            }
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            // Call the CreatePrizeForm
            CreatePrizeForm frm = new CreatePrizeForm(this);
            frm.Show();


        }

        public void PrizeComplete(PrizeModel model)
        {
            // Get back from the form a PrizeModel 
            // Take PrizeModel and put it into list of selected prizes 
            selectedPrizes.Add(model);
            WireUpLists();
        }

        public void TeamComplete(TeamModel model)
        {
            selectedTeams.Add(model);
            WireUpLists();
        }

        private void createNewTeamButton_Click(object sender, EventArgs e)
        {
            CreateTeamForm frm = new CreateTeamForm(this);
            frm.Show();
        }



        private void removeSelectedPrizeButton_Click(object sender, EventArgs e)
        {
            PrizeModel p = (PrizeModel)prizesListBox.SelectedItem;
            if (p != null)
            {
                selectedPrizes.Remove(p);

                WireUpLists();
            }
        }

        private void removeSelectedTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel t = (TeamModel)tournamentTeamsListBox.SelectedItem;
            if (t != null)
            {
                selectedTeams.Remove(t);
                availableTeams.Add(t);

                WireUpLists();
            }
        }

        private void createTournamentButton_Click(object sender, EventArgs e)
        {
            // Validate data
            if (tournamentNameValue.Text.Length == 0)
            {
                MessageBox.Show("You need to enter a Tournament name.",
                    "Invalid Tournament Name",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            decimal fee = 0;
            bool feeAcceptable = decimal.TryParse(entryFeeValue.Text, out fee);

            if (!feeAcceptable)
            {
                MessageBox.Show("You need to enter a valid entry fee.", 
                    "Invalid Fee", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }

            if (tournamentTeamsListBox.Items.Count < 2)
            {
                MessageBox.Show("You need to at least 2 teams in the tournament.",
                    "Invalid Number of Teams",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            decimal totalFee = tournamentTeamsListBox.Items.Count * fee;
            decimal totalPayout = 0;

            foreach (PrizeModel pz in selectedPrizes)
            {
                if (pz.PrizeAmount > 0)
                {
                    totalPayout += pz.PrizeAmount;
                } 
                else
                {
                    totalPayout += ((decimal)pz.PrizePercentage / 100) * totalFee;
                }                
            }

            if (totalPayout > totalFee)
            {
                MessageBox.Show(string.Format("The total prize payouts ${0} must be less than the total fees ${1}.", totalPayout, totalFee),
                    "Invalid Prize Amount",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }


            // Create tournament model 
            TournamentModel tm = new TournamentModel();

            tm.TournamentName = tournamentNameValue.Text;
            tm.EntryFee = fee;

            
            tm.Prizes = selectedPrizes;
            tm.EnteredTeams = selectedTeams;

            // Create the matchups
            TournamentLogic.CreateRounds(tm);

            // Create Tournament entry
            // Create all of the prizes entries 
            // Create all of the team entries 
            GlobalConfig.Connection.CreateTournament(tm);

            TournamentViewerForm frm = new TournamentViewerForm(tm);
            frm.Show();
            this.Close();
        }

        private void UpdateTournamentResults(object model)
        {
            throw new NotImplementedException();
        }
    }
}
