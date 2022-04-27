using System;
using UniversityModel.Views;

namespace UniversityModel
{
    public class UniversityInterface
    {
        public void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nUniversity database thing\n");
                Console.WriteLine("Press 1 for departments");
                Console.WriteLine("      2 for courses");
                Console.WriteLine("      3 for students");
                Console.WriteLine("      Q to quit");
                Console.WriteLine();

                var userSelection = InputParser.PromptInputFromUser("1", "2", "3", "Q");
                if (userSelection == "1")
                {
                    var selectedItem = DepartmentView.ChooseItemFromDatabase(true);
                    if (selectedItem != null)
                        DepartmentView.OptionsMenu(selectedItem);
                }
                if (userSelection == "2")
                {
                    var selectedItem = CourseView.ChooseItemFromDatabase(true);
                    if (selectedItem != null)
                        CourseView.OptionsMenu(selectedItem);
                }
                if (userSelection == "3")
                {
                    var selectedItem = StudentView.ChooseItemFromDatabase(true);
                    if (selectedItem != null)
                        StudentView.OptionsMenu(selectedItem);
                }
                if (userSelection == "Q")
                {
                    Console.Clear();
                    Console.WriteLine("Exit program? (Y/N)");
                    var confirmExit = InputParser.PromptForYesOrNo();
                    if (confirmExit)
                    {
                        Console.Clear();
                        Environment.Exit(0);
                    }
                    else
                        MainMenu();
                }  
            }
        }
    }
}
