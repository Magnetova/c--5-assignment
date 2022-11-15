using cis237_assignment_5.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace cis237_assignment_5
{
    class BeverageRepository
    {
        BeverageContext _beverageContext = new BeverageContext();

        public string Read()
        {
            string output = null;
            foreach (Beverage beverage in _beverageContext.Beverages )
            {
                output += BeverageToString(beverage) + Environment.NewLine;
            }
            return output;
        }


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

        public string FindBeverage(string ID)
        {
            Beverage _searchedBeverage = _beverageContext.Beverages.Find(ID);

            return BeverageToString(_searchedBeverage);

        }


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


        public void Delete(string ID)
        {
            Beverage _beverageToDelete = _beverageContext.Beverages.Find(ID);
            _beverageContext.Beverages.Remove(_beverageToDelete);
            _beverageContext.SaveChanges();
        }


        public string BeverageToString(Beverage beverage)
        {
            return String.Format(
                "{0,-6} {1,-5} {2,-15} {3,6} {4,-6}",
                $"{beverage.Id}",
                $"{beverage.Name}",
                $"{beverage.Pack}",
                $"{beverage.Price}",
                $"{beverage.Active}"
            ) +
            Environment.NewLine;
        }

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
