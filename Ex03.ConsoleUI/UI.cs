using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Ex03.GarageLogic;
using Console = System.Console;

namespace Ex03.ConsoleUI
{
    internal class UI
    {
        public static void Run()
        {
            Console.WriteLine("Welcome To the garage!");
            GarageLogic.GarageLogic garage = new GarageLogic.GarageLogic();
            StartAction(garage);
            string answer = getAnswer();
            byte byteAnswer = isValidAnswer(answer);

            while(byteAnswer == 0)
            {
                answer = getAnswer();
                byteAnswer = isValidAnswer(answer);
            } 

            while(byteAnswer == 1)
            {
                StartAction(garage);
                answer = getAnswer();
                byteAnswer = isValidAnswer(answer);
                while (byteAnswer == 0)
                {
                    answer = getAnswer();
                    byteAnswer = isValidAnswer(answer);
                }
            }

            Console.WriteLine("Have a nice day!");
        }

        private static string getAnswer()
        {
            Console.WriteLine("If you want to continue - press 1, to exit - press 2");
            string answer = Console.ReadLine();

            return answer;
        }

        private static byte isValidAnswer(string i_Answer)
        {
            if (i_Answer.Length != 1)
            {
                Console.WriteLine("Invalid answer, please try again");
                return 0;
            }

            byte byteAnswer = byte.Parse(i_Answer);

            if (byteAnswer < 1 || byteAnswer > 2)
            {
                Console.WriteLine("Invalid answer, please try again");
                return 0;
            }

            return byteAnswer;
        }

        public static void StartAction(GarageLogic.GarageLogic i_Garage)
        {
            string stringAction = getAction();
            byte action = isValidAction(stringAction);

            while(action == 0)
            {
                stringAction = getAction();
                action = isValidAction(stringAction);
            }

            if(action == 1)
            {
                EnterNewVehicle(i_Garage);
            }
            else if (action == 2)
            {
                string withOrWithoutFilter = getWithOrWithoutFilter();
                byte byteWithOrWithoutFilter = isValidFilter(withOrWithoutFilter);

                while (byteWithOrWithoutFilter == 0)
                {
                    withOrWithoutFilter = getWithOrWithoutFilter();
                    byteWithOrWithoutFilter = isValidFilter(withOrWithoutFilter);
                }

                if (byteWithOrWithoutFilter == 1)
                {
                    string[] states = i_Garage.getVehicleStates();
                    Console.WriteLine(states[0]);
                    string state = Console.ReadLine();
                    object validState = ParseAnswer(states[1], state);

                    while (validState == null)
                    {
                        Console.WriteLine("Invalid type - {0} should be {1}", state, states[1]);
                        Console.WriteLine(states[0]);
                        state = Console.ReadLine();
                        validState = UI.ParseAnswer(states[1], state);
                    }

                    Console.WriteLine(i_Garage.DisplayVehiclesLicenses(state));
                }
                else if (byteWithOrWithoutFilter == 2)
                {
                    Console.WriteLine(i_Garage.DisplayVehiclesLicenses());
                }
            }
            else
            {
                string licenseNumber = getString("license number");
                bool licenseNumberValid = isValidNumber(licenseNumber, "license number");

                while (!licenseNumberValid)
                {
                    licenseNumber = getString("license number");
                    licenseNumberValid = isValidNumber(licenseNumber, "license number");
                }

                if(action == 3)
                {
                    string[] states = i_Garage.getVehicleStates();
                    Console.WriteLine(states[0]);
                    string state = Console.ReadLine();
                    object validState = ParseAnswer(states[1], state);

                    while(validState == null)
                    {
                        Console.WriteLine("Invalid type - {0} should be {1}", state, states[1]);
                        Console.WriteLine(states[0]);
                        state = Console.ReadLine();
                        validState = UI.ParseAnswer(states[1], state);
                    }

                    Console.WriteLine(i_Garage.UpdateVehicleState(licenseNumber, state));
                }
                else if(action == 4)
                {
                    Console.WriteLine(i_Garage.inflateVehicleWheels(licenseNumber));
                }
                else if(action == 5)
                {
                    string[] fuelTypes = i_Garage.getFuelTypes();
                    Console.WriteLine(fuelTypes[0]);
                    string fuelType = Console.ReadLine();
                    object validFuelType = ParseAnswer(fuelTypes[1], fuelType);

                    while (validFuelType == null)
                    {
                        Console.WriteLine("Invalid type - {0} should be {1}", fuelType, fuelTypes[1]);
                        Console.WriteLine(fuelTypes[0]);
                        fuelType = Console.ReadLine();
                        validFuelType = ParseAnswer(fuelTypes[1], fuelType);
                    }

                    string fuelAmount = getString("fuel amount");
                    object fuelAmountValid = ParseAnswer("float", fuelAmount);

                    while (fuelAmountValid == null)
                    {
                        Console.WriteLine("Invalid type - {0} should be {1}", fuelAmount, "float");
                        fuelAmount = getString("fuel amount");
                        fuelAmountValid = ParseAnswer("float", fuelAmount);
                    }

                    try
                    {
                        Console.WriteLine(i_Garage.fuelNormalVehicle(licenseNumber, fuelType, (float)fuelAmountValid));
                    }
                    catch(Exception e)
                    {
                        e.ToString();
                    }
                }
                else if(action == 6)
                {
                    string minutesToCharge = getString("minutes to charge");
                    object minutesToChargeValid = ParseAnswer("float", minutesToCharge);

                    while (minutesToChargeValid == null)
                    {
                        Console.WriteLine("Invalid type - {0} should be {1}", minutesToCharge, "float");
                        minutesToCharge = getString("minutes to charge");
                        minutesToChargeValid = ParseAnswer("float", minutesToCharge);
                    }

                    try
                    {
                        Console.WriteLine(i_Garage.chargeElectricVehicle(licenseNumber, (float)minutesToChargeValid));
                    }
                    catch (Exception e)
                    {
                        e.ToString();
                    }
                }
                else if(action == 7)
                {
                    Console.WriteLine(i_Garage.DisplayVehicleData(licenseNumber));
                }
            }
        }

        private static string getWithOrWithoutFilter()
        {
            Console.WriteLine(
                string.Format(
                    @"If you wish to view vehicles in the garage and filter them by status - press 1
If you wish to view all vehicles in the garage without filter - press 2"));
            string withOrWithoutFilter = Console.ReadLine();

            return withOrWithoutFilter;
        }

        private static byte isValidFilter(string i_WithOrWithoutFilter)
        {
            if (i_WithOrWithoutFilter.Length != 1)
            {
                Console.WriteLine("Invalid action, please try again");
                return 0;
            }

            byte byteWithOrWithoutFilter = byte.Parse(i_WithOrWithoutFilter);

            if (byteWithOrWithoutFilter < 1 || byteWithOrWithoutFilter > 2)
            {
                Console.WriteLine("Invalid option, please try again");
                return 0;
            }

            return byteWithOrWithoutFilter;
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

        private static byte isValidAction(string i_Action)
        {
            if (i_Action.Length != 1)
            {
                Console.WriteLine("Invalid action, please try again");
                return 0;
            }

            byte byteAction = byte.Parse(i_Action);

            if (byteAction < 1 || byteAction > 7)
            {
                Console.WriteLine("Invalid game type, please try again");
                return 0;
            }

            return byteAction;
        }

        public static void EnterNewVehicle(GarageLogic.GarageLogic i_Garage)
        {
            Vehicle vehicle = InitializeVehicle();
            Dictionary<string, Dictionary<string, string[]>> vehiclesQuestionsDictionary = i_Garage.getVehicleRequiredData(vehicle);
            string[] carTypes = new string[vehiclesQuestionsDictionary.Keys.Count];
            vehiclesQuestionsDictionary.Keys.CopyTo(carTypes, 0);
            string carType = GetCarType(carTypes);
            Dictionary<string, string[]> questionsForUser = vehiclesQuestionsDictionary[carType];
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

            Console.WriteLine(i_Garage.setVehicleData(vehicle, setDataDictionary, carType));
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

        private static bool isValidVehicleModel(string i_VehicleModel)
        {
            const bool v_ValidVehicleModel = true;

            if (i_VehicleModel.Length < 1)
            {
                Console.WriteLine("Invalid vehicle model - Vehicle model should not be empty");
                return !v_ValidVehicleModel;
            }

            return v_ValidVehicleModel;
        }

        public static string GetCarType(string[] i_TypesArray)
        {
            foreach (string vehicleType in i_TypesArray)
            {
                Console.WriteLine(string.Format("For {0} press: {1}", vehicleType, System.Array.IndexOf(i_TypesArray, vehicleType)));
            }

            string strCarType = Console.ReadLine();
            int carType = isValidCarType(strCarType, 0, i_TypesArray.Length - 1);

            while (carType == i_TypesArray.Length)
            {
                strCarType = Console.ReadLine();
                carType = isValidCarType(strCarType, 0, i_TypesArray.Length - 1);
            }

            return i_TypesArray[carType];
        }

        private static int isValidCarType(string i_CarType, int i_MinValue, int i_MaxValue)
        {
            int carType;
            bool validCarType = int.TryParse(i_CarType, out carType);

            if (validCarType == false || i_CarType.Length != 1)
            {
                Console.WriteLine("Invalid car type, please try again");
                return i_MaxValue + 1;
            }

            if (carType < i_MinValue || carType > i_MaxValue)
            {
                Console.WriteLine("Invalid car type, please try again");
                return i_MaxValue + 1;
            }

            return carType;
        }

        public static object ParseAnswer(string i_Type, string i_Answer)
        {
            object answer = null;
            int indexOfColon = i_Type.IndexOf(':');

            if (i_Type == "int")
            {
                if(int.TryParse(i_Answer, out _))
                {
                    answer = int.Parse(i_Answer);
                }
            }
            else if (i_Type == "byte")
            {
                if(byte.TryParse(i_Answer, out _))
                {
                    answer = byte.Parse(i_Answer);
                }
            }
            else if (i_Type == "float")
            {
                if(float.TryParse(i_Answer, out _))
                {
                    answer = float.Parse(i_Answer);
                }
            }
            else if (i_Type == "bool")
            {
                if(bool.TryParse(i_Answer, out _))
                {
                    answer = bool.Parse(i_Answer);
                }
            }
            else if (indexOfColon != -1)
            {
                if(i_Type.Trim().Substring(0, i_Type.IndexOf(':')) == "enum")
                {
                    answer = ParseEnum(i_Type, i_Answer);
                }
            }
            else
            {
                answer = i_Answer;
            }

            return answer;
        }

        public static object ParseEnum(string i_Enum, string i_Answer)
        {
            int indexOfColon = i_Enum.IndexOf(':');
            string enumWithoutSpaces = i_Enum.Replace(" ", string.Empty);
            string[] enumString = enumWithoutSpaces.Substring(indexOfColon + 1, enumWithoutSpaces.Length - (indexOfColon + 1)).Split(',');

            foreach (string value in enumString)
            {
                if(value.ToLower().Equals(i_Answer.ToLower()))
                {
                    return i_Answer;
                }
            }

            return null;
        }
    }
}