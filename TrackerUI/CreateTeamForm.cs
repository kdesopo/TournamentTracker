using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreateTeamForm : Form
    {
        private List<PersonModel> availableMembers = GlobalConfig.Connection.GetPerson_All();
        private List<PersonModel> selectedMembers = new List<PersonModel>();

        public CreateTeamForm()
        {
            InitializeComponent();
            //CreateSampleData();
            WireUpLists();
        }

        private void CreateSampleData()
        {
            availableMembers.Add(new PersonModel { FirstName = "Katrina", LastName = "Lee" });
            availableMembers.Add(new PersonModel { FirstName = "Ben", LastName = "Lee" });

            selectedMembers.Add(new PersonModel { FirstName = "Brittney", LastName = "Bonsall" });
            selectedMembers.Add(new PersonModel { FirstName = "James", LastName = "Bonsall" });
        }
        private void WireUpLists()
        {
            selectMemberDropdown.DataSource = null;

            selectMemberDropdown.DataSource = availableMembers;
            selectMemberDropdown.DisplayMember = "FullName";

            teamMembersListBox.DataSource = null;

            teamMembersListBox.DataSource = selectedMembers;
            teamMembersListBox.DisplayMember = "FullName";
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void CreateMemberButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PersonModel p = new PersonModel();

                p.FirstName = firstNameValue.Text;
                p.LastName = lastNameValue.Text;
                p.Email = emailValue.Text;
                p.PhoneNumber = phoneValue.Text;

                p = GlobalConfig.Connection.CreatePerson(p);

                selectedMembers.Add(p);
                WireUpLists();

                firstNameValue.Text = "";
                lastNameValue.Text = "";
                emailValue.Text = "";
                phoneValue.Text = "";
                
            } else
            {
                MessageBox.Show("You need to fill in all fields.");
            }

        }

        private bool ValidateForm()
        {
            if (firstNameValue.Text.Length == 0)
            {
                return false;
            }

            if (lastNameValue.Text.Length == 0)
            {
                return false;
            }

            if (emailValue.Text.Length == 0)
            {
                return false;
            }

            if (phoneValue.Text.Length == 0)
            {
                return false;
            }

            return true;
        }

        private void AddMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)selectMemberDropdown.SelectedItem;

            if (p != null)
            {
                availableMembers.Remove(p);
                selectedMembers.Add(p);

                WireUpLists(); 
            }
        }

        private void RemoveSelectedMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)teamMembersListBox.SelectedItem;

            if (p != null)
            {
                selectedMembers.Remove(p);
                availableMembers.Add(p);

                WireUpLists(); 
            }
        }

        private void CreateTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel t = new TeamModel();
            t.TeamName = teamNameValue.Text;
            t.TeamMembers = selectedMembers;

            t = GlobalConfig.Connection.CreateTeam(t);

            //TODO - If not closing form after creation, reset the form
        }
    }
}
