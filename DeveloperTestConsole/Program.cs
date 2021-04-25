using DeveloperTestAPI.Models;
using DeveloperTestConsole.Modules;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DeveloperTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //****************
            //Module
            //****************
            PersonInfoModule personInfoModule = new PersonInfoModule();

            //****************
            //User input flow
            //****************
            Console.WriteLine("What's your First Name?");
            string firstName = Console.ReadLine();

            Console.WriteLine("What's your Last Name?");
            string lastname = Console.ReadLine();

            Console.WriteLine("What are your Social Skills ? (seperate by comma e.g. 'fun, social, friendly')");
            string socialSkills = Console.ReadLine();

            Console.WriteLine("What are your Social Accounts ? (Type - Address e.g. 'Twitter - @JDoe, Instagram - @JDOE')");
            string socialAccounts = Console.ReadLine();

            //****************
            //Construct PersonModel object
            //****************
            PersonModel personModel = new PersonModel
            {
                FirstName = firstName,
                LastName = lastname,
                SocialSkills = socialSkills,
                SocialAccounts = socialAccounts
            };

            //****************
            //API request
            //****************
            PersonInfoModel personInfoModel = personInfoModule.GetPersonInfo(personModel).Result;

            //****************
            //Output
            //****************
            if(personInfoModel != null)
            {
                Console.WriteLine("************** Output **************");
                Console.WriteLine(String.Format("The number of VOWELS: {0}", personInfoModel.Vowels));
                Console.WriteLine(String.Format("The number of CONSTENANTS: {0}", personInfoModel.Constenants));
                Console.WriteLine(String.Format("The firstname + last name entered: {0}", personInfoModel.FullName));
                Console.WriteLine(String.Format("The reverse version of the firstname and lastname: {0}", personInfoModel.ReversedFullName));
                Console.WriteLine("The JSON format of the entire object:");
                Console.WriteLine(JsonConvert.SerializeObject(personInfoModel.OriginalPersonModel, Formatting.Indented));
            }
        }
    }
}
