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
                output += beverage + Environment.NewLine;
            }
            return output;
        }


        public void Insert(string[] Data)
        {
            Beverage newBeverage = new Beverage();

            // Assing properties to the parts of the model
            newBeverage.Id = Data[0];
            newBeverage.Name = Data[1];
            newBeverage.Pack = Data[2];
            newBeverage.Price = Decimal.Parse(Data[3]);
            newBeverage.Active = Convert.ToBoolean(Data[4]);

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


        public void Update()
        {

        }


        public void Delete()
        {

        }
    }
}
