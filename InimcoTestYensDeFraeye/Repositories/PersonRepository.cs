using DeveloperTestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DeveloperTestAPI.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        #region API methods
        /// <summary>
        /// returns a PersonInfoModel based on the user's input
        /// </summary>
        /// <param name="personModel">Contains the user's input</param>
        /// <returns>PersonInfoModel</returns>
        public async Task<PersonInfoModel> GetInfo(PersonModel personModel)
        {
            return new PersonInfoModel
            {
                Vowels = CalculateVowels(personModel.FirstName) + CalculateVowels(personModel.LastName),
                Constenants = CalculateConsonants(personModel.FirstName) + CalculateConsonants(personModel.LastName),
                FullName = String.Format("{0} {1}", personModel.FirstName, personModel.LastName),
                ReversedFullName = ReverseName(String.Format("{0} {1}", personModel.FirstName, personModel.LastName)),
                OriginalPersonModel = new OriginalPersonModel
                {
                    FirstName = personModel.FirstName,
                    LastName = personModel.LastName,
                    SocialSkills = new List<string>(personModel.SocialSkills.Split(',')),
                    SocialAccounts = socialAccountsStringToList(personModel.SocialAccounts)
                }                
            };
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Calulate the Vowels in a string
        /// </summary>
        /// <param name="name">String name</param>
        /// <returns>Number of Vowels found</returns>
        private int CalculateVowels(string name)
        {
            // list of vowels
            List<char> vowels = new List<char> { 'a', 'e', 'i', 'o', 'u' };

            // count vowels - make name to Lower: make it case insensitive
            return name.ToLower().Count(c => vowels.Contains(c));
        }

        /// <summary>
        /// Calculates the Consonants in a string
        /// </summary>
        /// <param name="name">String name</param>
        /// <returns>Number of Consonants found in the string</returns>
        private int CalculateConsonants(string name)
        {
            // list of consonants
            List<char> consonants = new List<char> { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z' };

            // count consonants - make name to Lower: make it case insensitive
            return name.ToLower().Count(c => consonants.Contains(c));
        }

        /// <summary>
        /// Reverse the given string
        /// </summary>
        /// <param name="name">String name</param>
        /// <returns>Returns the string in reversed order</returns>
        private string ReverseName(string name)
        {
            char[] charArray = name.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        /// <summary>
        /// Transforms the SocialAccounts string to a List of SocialAccount objects.
        /// </summary>
        /// <param name="socialAccountString">String of Social Accounts</param>
        /// <returns>List of SocialAccounts</returns>
        private List<SocialAccount> socialAccountsStringToList(string socialAccountString)
        {
            List<SocialAccount> socialAccounts = new List<SocialAccount>();
            string[] socialAccountsSplittedString = socialAccountString.Split(',');
            foreach (string saString in socialAccountsSplittedString)
            {
                string[] saSplitted = saString.Split('-');
                socialAccounts.Add(new SocialAccount { Type = saSplitted[0], Address = saSplitted[1] });
            }

            return socialAccounts;
        }
        #endregion

    }
}
