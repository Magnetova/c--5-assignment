// Cayden Greer
// CIS 237 - Fall 2022
// 11-16-2022

using System;

namespace cis237_assignment_5
{
    class UserInterface
    {
        const int MAX_MENU_CHOICES = 6;

        /*
        |----------------------------------------------------------------------
        | Public Methods
        |----------------------------------------------------------------------
        */

        // Display Welcome Greeting
        public void DisplayWelcomeGreeting()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to the wine program!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Display Menu And Get Response
        public int DisplayMenuAndGetResponse()
        {
            // Declare variable to hold the selection
            string selection;

            // Display menu, and prompt
            this.DisplayMenu();
            this.DisplayPrompt();

            // Get the selection they enter
            selection = this.GetSelection();

            // While the response is not valid
            while (!this.VerifySelectionIsValid(selection))
            {
                // Display error message
                this.DisplayErrorMessage();

                // Display the prompt again
                this.DisplayPrompt();

                // Get the selection again
                selection = this.GetSelection();
            }
            // Return the selection casted to an integer
            return Int32.Parse(selection);
        }

        // Get the search query from the user
        public string GetSearchQuery()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to search for?");
            Console.Write("> ");
            return Console.ReadLine();
        }

        // Get New Item Information From The User.
        public string[] GetNewItemInformation(string itemType)
        {
            string name = this.GetStringField("Name", itemType);
            string pack = this.GetStringField("Pack", itemType);
            string price = this.GetDecimalField("Price", itemType);
            string active = this.GetBoolField("Active", itemType);

            return new string[] { name, pack, price, active };
        }

        // Display All Items
        public void DisplayAllItems(string allItemsOutput)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Printing List");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(this.GetItemHeader());
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(allItemsOutput);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("All items have been printed");
            Console.ForegroundColor = ConsoleColor.Gray;

        }

        // Display Item Found Success and the information of the found item
        public void DisplayItemFound(string itemInformation)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Item Found!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(this.GetItemHeader());
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(itemInformation);
        }

        // Display Item Found Error
        public void DisplayItemFoundError()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("A Match was not found");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Display Add Wine Item Success and the information of the added item
        public void DisplayAddWineItemSuccess(string itemInformation)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Item was successfully added");
            Console.WriteLine(GetItemHeader());
            Console.WriteLine(itemInformation);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Display that the item was successfully deleted from the database
        public void DisplayItemDeleteSuccess()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Item was successfully deleted");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        //Display that the item had updated in the database and prints updated item information
        public void DisplayItemUpdateSuccess(string itemInformation)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Item was successfully updated");
            Console.WriteLine(GetItemHeader());
            Console.WriteLine(itemInformation);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        // Get Id of bevereage user wants to update
        public string GetBeverageId(string functionType)
        {
            Console.WriteLine();
            Console.WriteLine("What is the Id of the beverage you would like to {0}?", functionType);
            string id = Console.ReadLine();
            return id;
        }

        // Display Item Already Exists Error
        public void DisplayItemAlreadyExistsError(string itemInformation)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("An Item With That Id Already Exists");
            Console.WriteLine(itemInformation);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /*
        |----------------------------------------------------------------------
        | Private Methods
        |----------------------------------------------------------------------
        */

        // Display the Menu
        private void DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("1. Print all of the Beverages in the database");
            Console.WriteLine("2. Update an existing Beverage in the database");
            Console.WriteLine("3. Search for a Beverage in the database");
            Console.WriteLine("4. Delete a Beverage from the database");
            Console.WriteLine("5. Add a new Beverage to the database");


            Console.WriteLine("6. Exit Program");
        }

        // Display the Prompt
        private void DisplayPrompt()
        {
            Console.WriteLine();
            Console.Write("Enter Your Choice: ");
        }

        // Display the Error Message
        private void DisplayErrorMessage()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("That is not a valid option. Please make a valid choice");
            Console.ForegroundColor = ConsoleColor.Gray;

        }

        // Get the selection from the user
        private string GetSelection()
        {
            return Console.ReadLine();
        }

        // Verify that a selection from the main menu is valid
        private bool VerifySelectionIsValid(string selection)
        {
            // Declare a returnValue and set it to false
            bool returnValue = false;

            try
            {
                // Parse the selection into a choice variable
                int choice = Int32.Parse(selection);

                // If the choice is between 0 and the maxMenuChoice
                if (choice > 0 && choice <= MAX_MENU_CHOICES)
                {
                    // Set the return value to true
                    returnValue = true;
                }
            }
            // If the selection is not a valid number, this exception will be thrown
            catch (Exception e)
            {
                // Set return value to false even though it should already be false
                returnValue = false;
            }

            // Return the reutrnValue
            return returnValue;
        }

        // Get a valid string field from the console
        private string GetStringField(string fieldName, string itemType)
        {
            Console.WriteLine("What is the {1} Item's new {0}", fieldName, itemType);
            string value = null;
            bool valid = false;
            while (!valid)
            {
                value = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(value))
                {
                    valid = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You must provide a value.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.WriteLine("What is the {1} Item's new {0}", fieldName, itemType);
                    Console.Write("> ");
                }
            }
            return value;
        }

        // Get a valid decimal field from the console
        private string GetDecimalField(string fieldName, string itemType)
        {
            Console.WriteLine("What is the {1} Item's new {0}", fieldName, itemType);
            decimal value = 0;
            bool valid = false;
            while (!valid)
            {
                try
                {
                    value = decimal.Parse(Console.ReadLine());
                    valid = true;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is not a valid Decimal. Please enter a valid Decimal.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.WriteLine("What is the {1} Item's new {0}", fieldName, itemType);
                    Console.Write("> ");
                }
            }

            return value.ToString();
        }

        // Get a valid bool field from the console
        private string GetBoolField(string fieldName, string itemType)
        {
            Console.WriteLine("Should the {1} Item be {0} (y/n)", fieldName, itemType);
            string input = null;
            bool value = false;
            bool valid = false;
            while (!valid)
            {
                input = Console.ReadLine();
                if (input.ToLower() == "y" || input.ToLower() == "n")
                {
                    valid = true;
                    value = (input.ToLower() == "y");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is not a valid Entry.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.WriteLine("Should the {1} Item be {0} (y/n)", fieldName, itemType);
                    Console.Write("> ");
                }
            }

            return value.ToString();
        }

        // Get a string formatted as a header for items
        private string GetItemHeader()
        {
            return String.Format(
                "{0,-6} {1,-100} {2,-19} {3,6} {4,8}",
                "Id",
                "Name",
                "Pack",
                "Price",
                "Active"
            ) +
            Environment.NewLine +
            String.Format(
                "{0,-6} {1,-100} {2,-19} {3,7} {4,6}",
                new String('-', 6),
                new String('-', 40),
                new String('-', 15),
                new String('-', 6),
                new String('-', 5)
            );
        }


        // Asks the user if they are sure that the item that corresponds with the entered id
        // is the one that they wish to delete from the database.
        public bool UserConfirmation()
        {
            Console.WriteLine("Are you sure you want to delete this item from the database? (y for yes, n for no)");
            string input = null;
            bool value = false;
            bool valid = false;
            while (!valid)
            {
                input = Console.ReadLine();
                if (input.ToLower() == "y" || input.ToLower() == "n")
                {
                    valid = true;
                    if (input == "y")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is not a valid Entry.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.WriteLine("Are you sure you want to delete this item from the database? (y for yes, n for no)");
                    Console.Write("> ");
                }
            }
            return false;

        }

        // cancels the operation of deleting an item from the database if the user answers "n" 
        public void CancelOperation()
        {
            Console.WriteLine();
            Console.WriteLine("Operation has been cancelled");
        }
    }
}
