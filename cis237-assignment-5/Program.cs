using System;

namespace cis237_assignment_5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the UserInterface class
            UserInterface userInterface = new UserInterface();
            BeverageRepository beverageRepository = new BeverageRepository();

            // Display the Welcome Message to the user
            userInterface.DisplayWelcomeGreeting();

            // Display the Menu and get the response. Store the response in the choice integer
            // This is the 'primer' run of displaying and getting.
            int choice = userInterface.DisplayMenuAndGetResponse();

            // While the choice is not exit program
            while (choice != 5)
            {
                switch (choice)
                {
                    case 1:
                        // Print Entire List Of Items
                        userInterface.DisplayAllItems(beverageRepository.Read());
                        break;

                    case 2:
                        // Update the database


                    case 2:
                        // Search For An Item
                        
                        break;

                    case 3:
                        // Add A New Item To The List
                        beverageRepository.Insert(userInterface.GetNewItemInformation());
                        else
                        {
                            userInterface.DisplayItemAlreadyExistsError();
                        }
                        break;
                }

                // Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();
            }
        }
    }
}
