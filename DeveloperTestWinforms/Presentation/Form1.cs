using DeveloperTestAPI.Models;
using DeveloperTestConsole.Modules;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeveloperTestWinforms
{
    public partial class Form1 : Form
    {
        PersonInfoModule personInfoModule;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            //***************
            //new Module instance
            //***************
            personInfoModule = new PersonInfoModule();

            //***************
            //prepare model to send
            //***************
            PersonModel personModel = new PersonModel
            {
                FirstName = this.textBoxFirstname.Text,
                LastName = this.textBoxLastname.Text,
                SocialSkills = this.textBoxSocialSkills.Text,
                SocialAccounts = this.textBoxSocialAccounts.Text
            };

            //***************
            //if the check is passed, do the HTTP request
            //***************
            if (CheckUserInput(personModel))
            {
                try
                {
                    PersonInfoModel personInfoModel = personInfoModule.GetPersonInfo(personModel).Result;
                    SetOutput(personInfoModel);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }                
            }
            else
            {
                MessageBox.Show("Please fill in all the fields");
            }
        }

        private bool CheckUserInput(PersonModel personModel)
        {
            bool allowRequest = false;

            if(!string.IsNullOrWhiteSpace(personModel.FirstName) 
                && !string.IsNullOrWhiteSpace(personModel.LastName)
                && !string.IsNullOrWhiteSpace(personModel.SocialSkills)
                && !string.IsNullOrWhiteSpace(personModel.SocialAccounts))
            {
                allowRequest = true;
            }

            return allowRequest;
        }

        private void SetOutput(PersonInfoModel personInfoModel)
        {
            this.textBoxOutput.Clear();

            this.textBoxOutput.AppendText(String.Format("The number of VOWELS: {0}", personInfoModel.Vowels));
            this.textBoxOutput.AppendText(Environment.NewLine);
            this.textBoxOutput.AppendText(String.Format("The number of CONSTENANTS: {0}", personInfoModel.Constenants));
            this.textBoxOutput.AppendText(Environment.NewLine);
            this.textBoxOutput.AppendText(String.Format("The firstname + last name entered: {0}", personInfoModel.FullName));
            this.textBoxOutput.AppendText(Environment.NewLine);
            this.textBoxOutput.AppendText(String.Format("The reverse version of the firstname and lastname: {0}", personInfoModel.ReversedFullName));
            this.textBoxOutput.AppendText(Environment.NewLine);
            this.textBoxOutput.AppendText("The JSON format of the entire object:");
            this.textBoxOutput.AppendText(JsonConvert.SerializeObject(personInfoModel.OriginalPersonModel, Formatting.Indented));
        }
    }
}
