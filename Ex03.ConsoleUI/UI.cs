using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Ex03.GarageLogic;
using Console = System.Console;

namespace Ex03.ConsoleUI
{
    class UI
    {

        public static void startAction()
        {
            string stringAction = getAction();
            byte action = isValidAction(stringAction);
            while(action == 0)
            {
                stringAction = getAction();
                action = isValidAction(stringAction);
            }

            if(action == 1) EnterNewVehicle();
            if(action == 2) EnterNewVehicle();
            if(action == 3) EnterNewVehicle();
            if(action == 4) EnterNewVehicle();
            if(action == 5) EnterNewVehicle();
            if(action == 6) EnterNewVehicle();
            if(action == 7) EnterNewVehicle();
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

        public static void EnterNewVehicle()
        {
            Vehicle vehicle = InitializeVehicle();
            GarageLogic.GarageLogic garage = new GarageLogic.GarageLogic();
            Dictionary<string, Dictionary<string, string[]>> vehiclesQuestionsDictionary = garage.getVehicleRequiredData(vehicle);
            string[] carTypes = new string[vehiclesQuestionsDictionary.Keys.Count];
            vehiclesQuestionsDictionary.Keys.CopyTo(carTypes, 0);
            Dictionary<string, string[]> questionsForUser = vehiclesQuestionsDictionary[GetCarType(carTypes)];
            Dictionary<string, object> setDataDictionary = new Dictionary<string, object>();
            foreach (KeyValuePair<string, string[]> vehiclePair in questionsForUser)
            {
                Console.WriteLine(vehiclePair.Value[0]);
                Console.WriteLine("The type of answer: " + vehiclePair.Value[1]);
                string answer = Console.ReadLine();
                object validAnswer = ParseAnswer(vehiclePair.Value[1], answer);
                while (validAnswer == null)
                {
                    Console.WriteLine("Invalid type - {0} should be {1}", vehiclePair.Key, vehiclePair.Value[1]);
                    Console.WriteLine(vehiclePair.Value[0]);
                    answer = Console.ReadLine();
                    validAnswer = UI.ParseAnswer(vehiclePair.Value[1], answer);
                }
                setDataDictionary.Add(vehiclePair.Key, validAnswer);
            }
        }

        public static Vehicle InitializeVehicle()
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
            bool phoneNumberValid = isValidNumber(ownerPhoneNumber, "phone number");
            while (!phoneNumberValid)
            {
                ownerPhoneNumber = getString("phone number");
                phoneNumberValid = isValidNumber(ownerPhoneNumber, "phone number");
            }

            string vehicleModel = getString("vehicle model");
            bool vehicleModelValid = isValidVehicleModel(vehicleModel);
            while (!vehicleModelValid)
            {
                vehicleModel = getString("vehicle model");
                vehicleModelValid = isValidVehicleModel(vehicleModel);
            }

            string licenseNumber = getString("license number");
            bool licenseNumberValid = isValidNumber(licenseNumber, "license number");
            while (!licenseNumberValid)
            {
                licenseNumber = getString("license number");
                licenseNumberValid = isValidNumber(licenseNumber, "license number");
            }
            
            Ex03.GarageLogic.Vehicle vehicle = new Vehicle(ownerName, ownerPhoneNumber, vehicleModel, licenseNumber);
            return vehicle;
        }

        private static string getString(string i_Type)
        {
            Console.WriteLine("Please enter {0}:", i_Type);
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

        private static bool isValidNumber(string i_StrNumber, string i_Type)
        {
            const bool v_ValidNumber = true;

            if (i_StrNumber.Length < 1)
            {
                Console.WriteLine("Invalid {0} - {0} should not be empty", i_Type);
                return !v_ValidNumber;
            }

            foreach (char digit in i_StrNumber)
            {
                if(!char.IsDigit(digit))
                {
                    Console.WriteLine("Invalid {0} - {0} should contain digits only", i_Type);
                    return !v_ValidNumber;
                }
            }

            return v_ValidNumber;
        }

        private static bool isValidVehicleModel(string i_vehicleModel)
        {
            const bool v_ValidVehicleModel = true;

            if (i_vehicleModel.Length < 1)
            {
                Console.WriteLine("Invalid vehicle model - Vehicle model should not be empty");
                return !v_ValidVehicleModel;
            }

            return v_ValidVehicleModel;
        }

        public static string GetCarType(string[] i_typesArray)
        {
            foreach (string vehicleType in i_typesArray)
            {
                Console.WriteLine(string.Format("For {0} press: {1}", vehicleType, System.Array.IndexOf(i_typesArray, vehicleType)));
                
            }

            string strCarType = Console.ReadLine();
            int carType = isValidCarType(strCarType, 0, i_typesArray.Length - 1);
            while (carType == i_typesArray.Length)
            {
                strCarType = Console.ReadLine();
                carType = isValidCarType(strCarType, 0, i_typesArray.Length - 1);
            }
            return i_typesArray[carType];
        }

        private static int isValidCarType(string i_carType, int i_minValue, int i_maxValue)
        {
            int carType;
            bool validCarType = int.TryParse(i_carType, out carType);

            if (validCarType == false || i_carType.Length != 1)
            {
                Console.WriteLine("Invalid car type, please try again");
                return i_maxValue + 1;
            }

            if (carType < i_minValue || carType > i_maxValue)
            {
                Console.WriteLine("Invalid car type, please try again");
                return i_maxValue + 1; ;
            }

            return carType;
        }

        public static object ParseAnswer(string i_type, string i_answer)
        {
            object answer = null;
            int indexOfColon = i_type.IndexOf(':');

            if (i_type == "int")
            {
                if (int.TryParse(i_answer, out _)) answer = int.Parse(i_answer);
            }
            else if (i_type == "byte")
            {
                if (byte.TryParse(i_answer, out _)) answer = byte.Parse(i_answer);
            }
            else if (i_type == "float")
            {
                if (float.TryParse(i_answer, out _)) answer = float.Parse(i_answer);
            }
            else if (i_type == "bool")
            {
                if (bool.TryParse(i_answer, out _)) answer = bool.Parse(i_answer);
            }
            else if (indexOfColon != -1)
            {
                if (i_type.Trim().Substring(0, i_type.IndexOf(':')) == "enum") answer = ParseEnum(i_type, i_answer);
            }
            else answer = i_answer;

            return answer;
        }

        public static object ParseEnum(string i_enum, string i_answer)
        {
            int indexOfColon = i_enum.IndexOf(':');
            string enumWithoutSpaces = i_enum.Replace(" ", string.Empty);
            string[] enumString = enumWithoutSpaces.Substring(indexOfColon + 1, enumWithoutSpaces.Length - (indexOfColon + 1)).Split(',');

            foreach (string value in enumString)
            {
                if (value.ToLower().Equals(i_answer.ToLower())) return i_answer;
            }

            return null;
        }
    }
}



