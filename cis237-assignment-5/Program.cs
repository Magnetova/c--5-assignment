// Cayden Greer
// CIS 237 - Fall 2022
// 11-16-2022

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
            while (choice != 6)
            {
                switch (choice)
                {
                    case 1:
                        // Print all beverage items from the database
                        userInterface.DisplayAllItems(beverageRepository.Read());
                        break;

                    case 2:
                        // Update a beverage within the database
                        string updateID = userInterface.GetBeverageId("update");

                        if (beverageRepository.CheckID(updateID))
                        {
                            userInterface.DisplayItemFound(beverageRepository.FindBeverage(updateID));
                            beverageRepository.Update(updateID, userInterface.GetNewItemInformation("existing"));
                            userInterface.DisplayItemUpdateSuccess(beverageRepository.FindBeverage(updateID));
                        }
                        else
                            userInterface.DisplayItemFoundError();
                        break;

                    case 3:
                        // Search for a beverage in the database
       
                        string searchID = userInterface.GetBeverageId("search");

                        if (beverageRepository.CheckID(searchID))
                            userInterface.DisplayItemFound(beverageRepository.FindBeverage(searchID));
                        else
                            userInterface.DisplayItemFoundError();
                        break;

                    case 4:
                        // Delete a beverage from the database
                        string deleteID = userInterface.GetBeverageId("delete");

                        if (beverageRepository.CheckID(deleteID))
                        {
                            userInterface.DisplayItemFound(beverageRepository.FindBeverage(deleteID));
                            if (userInterface.UserConfirmation())
                            {
                                beverageRepository.Delete(deleteID);
                                userInterface.DisplayItemDeleteSuccess();
                            }
                            else
                            {
                                userInterface.CancelOperation();
                            }
                        }
                        else
                            userInterface.DisplayItemFoundError();
                        break;


                    case 5:
                        // Add a new beverage item to the database 
                        string insertID = userInterface.GetBeverageId("create");

                        if (!beverageRepository.CheckID(insertID))
                        {
                            beverageRepository.Insert(insertID, userInterface.GetNewItemInformation("created"));
                            userInterface.DisplayAddWineItemSuccess(beverageRepository.FindBeverage(insertID));
                        }
                        else
                            userInterface.DisplayItemAlreadyExistsError(beverageRepository.FindBeverage(insertID));
                        break;
                }

                // Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();
            }
        }
    }
}
