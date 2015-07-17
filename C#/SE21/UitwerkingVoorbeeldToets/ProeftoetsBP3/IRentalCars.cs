using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentalCarAdmin
{
    interface IRentalCars
    {
        //returns a list of Id's of cars available for rent
        List<int> GetCarsAvailable();

        //returns a list of Id's of cars rented
        List<int> GetCarsRented();

        //returns a string that describes a rental car or empty in case id not found
        string GetCarDescription(int id);

        //returns the milage of the rental car or negative in case id not found
        long GetCarKilometers(int id);

        //marks an available car to be rented. Returns true on success, false otherwise.
        bool RentCar(int id);

        //when a rented car is returned, it is marked as available
        //the kilometers are registered. returns true on success, false otherwise.
        bool ReturnCar(int id, long kilometers);

        //removes the car with given Id from the administration
        //It is not possible to remove a rented car.
        //It is only possible to remove an available car
        //Returns true on success, false otherwise.
        bool RemoveRentalCar(int id);

        //adds a new regular car to the administration
        //it will be avialable immediately
        void AddRegularCar(RegularCar regularcar);

        //get a new id (unique) for a new Car
        int GetNewId();

        //adds a new truck to the administration
        //it will be avialable immediately
        void AddTruck(Truck truck);

        //saves the rental car administration in a file named rentals.dat
        //if the file already exists, it is overwritten
        //if saving was succesful the returned string is empty 
        //if an exception occurs, the string contains an errormessage
        string SaveRentalCars();

        //loads the rental car administration from a file named rentals.dat
        //if loading was succesful the returned string is empty
        //if an exception occurs, the string contains an errormessage
        string LoadRentalCars();

    }
}
