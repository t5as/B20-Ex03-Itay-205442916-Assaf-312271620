using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ConsoleUI
{
    class UI
    {
        public List<object> ParseAnswers(string i_type, string i_answer)
        {
            List<object> answers = new List<object>();
            if(i_type == "int") answers.Add(int.Parse(i_answer));
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
    }
}
