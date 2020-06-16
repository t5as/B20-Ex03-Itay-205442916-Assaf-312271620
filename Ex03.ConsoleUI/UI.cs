using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;
using Console = System.Console;

namespace Ex03.ConsoleUI
{
    class UI
    {
        public List<object> ParseAnswers(string i_type, string i_answer)
        {
            List<object> answers = new List<object>();
            if (i_type == "int") answers.Add(int.Parse(i_answer));
            else if (i_type == "byte") answers.Add(byte.Parse(i_answer));
            else if (i_type == "float") answers.Add(float.Parse(i_answer));
            else if (i_type == "bool") answers.Add(bool.Parse(i_answer));
            else if (i_type == "string") answers.Add(i_answer);
            return answers;
        }

        public static string[] ParseEnums(string i_enum)
        {
            int indexOfColon = i_enum.IndexOf(':');
            string[] enumString = i_enum.Trim().Substring(indexOfColon + 1, i_enum.Length).Split(',');
            return enumString;
        }

        private static string getAction()
        {
            Console.WriteLine(
                string.Format(
                    @"Hello, 
If you wish to enter a new vehicle to the garage - press 1
If you wish to see license numbers of vehicles in the garage - press 2
If you wish to change vehicle state in the garage - press 3
If you wish to inflate vehicle wheels to maximum - press 4
If you wish to refuel a fueled driven vehicle - press 5
If you wish to recharge an electric vehicle - press 6
If you wish to see full vehicle data by it's license number - press 7"));
            string action = Console.ReadLine();

            return action;
        }

        private static byte isValidAction(string i_action)
        {
            if (i_action.Length != 1)
            {
                Console.WriteLine("Invalid action, please try again");
                return 0;
            }

            byte byteAction = byte.Parse(i_action);

            if (byteAction < 1 || byteAction > 7)
            {
                Console.WriteLine("Invalid game type, please try again");
                return 0;
            }

            return byteAction;
        }

        public static Ex03.GarageLogic.Vehicle InitializeVehicle()
        {
            string ownerFirstName = getString("first name");
            bool firstNameValid = IsValidName(ownerFirstName);
            while (!firstNameValid)
            {
                ownerFirstName = getString("first name");
                firstNameValid = IsValidName(ownerFirstName);
            }

            string ownerSurname = getString("surname");
            bool surnameValid = IsValidName(ownerSurname);
            while (!surnameValid)
            {
                ownerSurname = getString("surname");
                surnameValid = IsValidName(ownerSurname);
            }

            string ownerName = string.Format("{0} {1}", ownerFirstName, ownerSurname);

            string ownerPhoneNumber = getString("phone number");
            bool phoneNumberValid = IsValidNumber(ownerPhoneNumber, "phone number");
            while (!phoneNumberValid)
            {
                ownerPhoneNumber = getString("phone number");
                phoneNumberValid = IsValidNumber(ownerPhoneNumber, "phone number");
            }

            string vehicleModel = getString("vehicle model");
            bool vehicleModelValid = IsValidVehicleModel(vehicleModel);
            while (!vehicleModelValid)
            {
                vehicleModel = getString("vehicle model");
                vehicleModelValid = IsValidVehicleModel(vehicleModel);
            }

            string licenseNumber = getString("license number");
            bool licenseNumberValid = IsValidNumber(licenseNumber, "license number");
            while (!vehicleModelValid)
            {
                licenseNumber = getString("license number");
                licenseNumberValid = IsValidNumber(licenseNumber, "license number");
            }
            
            Ex03.GarageLogic.Vehicle vehicle = new Vehicle(ownerName, ownerPhoneNumber, vehicleModel, licenseNumber);
            return vehicle;
        }

        private static string getString(string i_Type)
        {
            Console.WriteLine("Please enter {0}", i_Type);
            string str = Console.ReadLine();
            return str;
        }

        public static bool IsValidName(string i_StrInputName)
        {
            const bool v_ValidName = true;

            if (i_StrInputName.Length < 2)
            {
                Console.WriteLine("Invalid name - Name should contain at least two letters");
                return !v_ValidName;
            }

            if (!char.IsLetter(i_StrInputName[0]))
            {
                Console.WriteLine("Invalid name - Name should contain only English letters");
                return !v_ValidName;
            }

            if (!char.IsUpper(i_StrInputName[0]))
            {
                Console.WriteLine("Invalid name - Name should start with a capital English letter");
                return !v_ValidName;
            }

            for (int i = 1; i < i_StrInputName.Length; i++)
            {
                if (!char.IsLetter(i_StrInputName[i]))
                {
                    Console.WriteLine("Invalid name - Name should contain only English letters");
                    return !v_ValidName;
                }

                if (!char.IsLower(i_StrInputName[i]))
                {
                    Console.WriteLine(
                        "Invalid name - Name should start with a capital English letter, followed by lower English letter");
                    return !v_ValidName;
                }
            }

            return v_ValidName;
        }

        public static bool IsValidNumber(string i_StrNumber, string i_Type)
        {
            int number;
            bool isNumeric = int.TryParse(i_StrNumber, out number);
            if (isNumeric == false)
            {
                Console.WriteLine("Invalid {0} - Phone number should contain only digits", i_Type);
            }
            return isNumeric;
        }

        private static bool IsValidVehicleModel(string i_VehicleModel)
        {
            const bool v_ValidVehicleModel = true;

            if (i_VehicleModel.Length < 1)
            {
                Console.WriteLine("Invalid vehicle model - Vehicle model should not be empty string");
                return !v_ValidVehicleModel;
            }

            return v_ValidVehicleModel;
        }
    }
}



