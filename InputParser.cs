using System;
using System.Linq;

namespace UniversityModel
{
    internal static class InputParser
    {
        internal static string PromptCharFromUser()
        {
                Console.Write(">>> ");
                var selection = Console.ReadLine();
                return selection;
        }

        internal static int PromptIntFromUser(int validIndexSelections)
        {
            var validSelectionRange = Enumerable.Range(1, validIndexSelections).ToList().ConvertAll(x => x.ToString());

            bool validInput = false;
            int result = 0;
            while (!validInput)
            {
                var selection = PromptInputFromUser(validIndexSelections);
                result = Convert.ToInt32(selection);
                validInput = (result != -1);
            }
            return result;
        }

        internal static string PromptInputFromUser(params string[] acceptableValues)
        {
            bool validInput = false;
            string selection = " ";

            while (!validInput)
            {
                Console.Write(">>> ");
                selection = Console.ReadLine();
                if (selection.All(Char.IsLetter))
                    selection = selection.ToUpper();
                var selectionIndex = Array.FindIndex(acceptableValues, x => x == selection);
                if (selectionIndex == -1)
                    Console.WriteLine("\n\nSorry, invalid input. Please try again!");
                else
                    validInput = true;
            }
            return selection;
        }

        internal static string PromptInputFromUser(int validIndexSelections, params string[] acceptableValues)
        {
            bool validInput = false;
            string selection = " ";
            var validSelectionRange = Enumerable.Range(1, validIndexSelections).ToList().ConvertAll(x => x.ToString());
            validSelectionRange.AddRange(acceptableValues.ToList());

            while (!validInput)
            {
                Console.Write(">>> ");
                selection = Console.ReadLine();
                if (selection.All(Char.IsLetter))
                    selection = selection.ToUpper();
                var selectionIndex = validSelectionRange.SingleOrDefault(x => x == selection);
                if (selectionIndex == default(string))
                    Console.WriteLine("\n\nSorry, invalid input. Please try again!");
                else
                    validInput = true;
            }
            return selection;
        }

        internal static bool PromptForYesOrNo()
        {
            var result = PromptInputFromUser(new string[] {"Y", "N"});
            Console.WriteLine();
            if (result == "Y")
                return true;
            else
                return false;
        }
    }
}