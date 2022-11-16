// Cayden Greer
// CIS 237 - Fall 2022
// 11-16-2022


using cis237_assignment_5.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace cis237_assignment_5
{
    class BeverageRepository
    {
        // Instance of BeverageContext created from connecting to database allowing for interaction with the database
        BeverageContext _beverageContext = new BeverageContext();

        /// <summary>
        /// A public method that reads all of the data entries within a string and concats them into a single string.
        /// </summary>
        /// <returns>A single string that contains all of the beverage items in the database</returns>
        public string Read()
        {
            string output = null;
            foreach (Beverage beverage in _beverageContext.Beverages )
            {
                output += BeverageToString(beverage) + Environment.NewLine;
            }
            return output;
        }


        /// <summary>
        /// A public method that adds a new beverage item to the database from a string array of user inputs.
        /// </summary>
        /// <param name="ID"> The user entered ID of the beverage they would like to insert</param>
        /// <param name="Data"> The user entered information of the new beverage's name, pack, price, and active passed in as an array</param>
        public void Insert(string ID, string[] Data)
        {
            Beverage newBeverage = new Beverage();


            // Assing properties to the parts of the model
            newBeverage.Id = ID;
            newBeverage.Name = Data[0];
            newBeverage.Pack = Data[1];
            newBeverage.Price = Decimal.Parse(Data[2]);
            newBeverage.Active = Convert.ToBoolean(Data[3]);

            try
            {
                // Add the new car to the Cars Colleciton
                _beverageContext.Beverages.Add(newBeverage);

                // This method call actually does the work of saving the changes to the database
                _beverageContext.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                // Remove the new car form the CarsCollection since we can't save it.
                // We don' twant it hanging around on the next time we go to save changes.
                _beverageContext.Beverages.Remove(newBeverage);
                // Write to console that there was an error.
                Console.WriteLine("Can't add the record. Already have one with that Primary Key");
            }
        }


        /// <summary>
        /// A public method that searches the database for a beverage item with an item ID.
        /// </summary>
        /// <param name="ID"> User entered ID of the beverage item they would like to find </param>
        /// <returns> The beverage item converted into a string my the method BeverageToString </returns>
        public string FindBeverage(string ID)
        {
            Beverage _searchedBeverage = _beverageContext.Beverages.Find(ID);

            return BeverageToString(_searchedBeverage);

        }


        /// <summary>
        /// A public method that Updates an existing beverage item and saves the new data overwriting the existing data in the database.
        /// </summary>
        /// <param name="ID"> User entered ID of the beverage item they would like to update </param>
        /// <param name="Data"> The user entered updated information of the beverage's name, pack, price, and active passed in as an array </param>
        public void Update(string ID, string[] Data)
        {
            Beverage _beverageToUpdate = _beverageContext.Beverages.Find(ID);


            if(Data[0] != null)
                _beverageToUpdate.Name = Data[0];
            if(Data[1] != null)
                _beverageToUpdate.Pack = Data[1];
            if(Data[2] != null)
                _beverageToUpdate.Price = Decimal.Parse(Data[2]);
            if(Data[3] != null)
                _beverageToUpdate.Active = Convert.ToBoolean(Data[3]);

            _beverageContext.SaveChanges();

        }


        /// <summary>
        /// A public method that deletes a beverage item from the database based on a provided ID.
        /// </summary>
        /// <param name="ID">User entered ID of the beverage item they would like to delete</param>
        public void Delete(string ID)
        {
            Beverage _beverageToDelete = _beverageContext.Beverages.Find(ID);
            _beverageContext.Beverages.Remove(_beverageToDelete);
            _beverageContext.SaveChanges();
        }


        /// <summary>
        /// A private method that generates a formatted string form a beverage item.
        /// </summary>
        /// <param name="beverage"> An item that contains all of the information about a single beverage from the database</param>
        /// <returns> A string that formats and displays the beverage item's information</returns>
        private string BeverageToString(Beverage beverage)
        {
            return String.Format(
                "{0,-6} {1,-100} {2,-19} {3,6} {4,8}",
                $"{beverage.Id}",
                $"{beverage.Name}",
                $"{beverage.Pack}",
                $"{beverage.Price.ToString("C")}",
                $"{beverage.Active}"
            ) +
            Environment.NewLine;
        }


        /// <summary>
        /// A public method that checks if the user entered ID already exists within the database.
        /// </summary>
        /// <param name="ID"> User entered ID of the beverage item </param>
        /// <returns> True if the ID already exists and False if the ID does not exist</returns>
        public bool CheckID(string ID)
        {
           Beverage _checkBeverage = _beverageContext.Beverages.Find(ID);

            if(_checkBeverage == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
