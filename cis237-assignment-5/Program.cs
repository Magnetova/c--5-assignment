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
                        // Print Entire List Of Items
                        userInterface.DisplayAllItems(beverageRepository.Read());
                        break;

                    case 2:
                        // Update a beverage
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
                        // Search for a beverage
       
                        string searchID = userInterface.GetBeverageId("search");

                        if (beverageRepository.CheckID(searchID))
                            userInterface.DisplayItemFound(beverageRepository.FindBeverage(searchID));
                        else
                            userInterface.DisplayItemFoundError();
                        break;

                    case 4:
                        // Delete a beverage
                        string deleteID = userInterface.GetBeverageId("delete");

                        if (beverageRepository.CheckID(deleteID))
                        {
                            beverageRepository.Delete(deleteID);
                            userInterface.DisplayItemDeleteSuccess();
                        }
                        else
                            userInterface.DisplayItemFoundError();
                        break;


                    case 5:
                        // Add A New Item To The List
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
