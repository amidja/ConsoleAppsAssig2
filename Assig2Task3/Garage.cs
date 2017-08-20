using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assig2Task3
{
    class Garage
    {
        private HashSet<Car> cars;

        public Garage()
        {
            this.cars = new HashSet<Car>();
        }

        public bool Add(Car car)
        {
            return this.cars.Add(car);   
        }

        public bool Remove (Car car)
        {
            return this.cars.Remove(car);
        }

        public Car Search(int carId)
        {
            foreach (Car car in cars)
            {
                if (car.Id == carId)
                {
                    return car;
                }
            }
            return null;
        }

        public bool Remove(int carId)
        {
            Car car = Search(carId);

            if (car != null)
                return Remove(car);

            return false;
        }

        public void Display(int carId)
        {

            if (carId <=0)
            {
                Console.WriteLine("\t Invalid car id provided!", carId);
                return;
            }
            
            Car car = Search(carId);
            if (car == null)
                Console.WriteLine("\t Car with Id {0} is not parked in the garage!", carId);
            else
                Display(car);
        }

        public void Display()
        {
            if (cars.Count <=0)
                Console.WriteLine("\t Garage is empty!");
            else
                foreach (Car car in cars)  Display(car);
        }
        
        private void Display(Car car)
        { 
            if (car != null)
                Console.WriteLine("\tCar Id: {0} \tMake: {1:20t} \tModel:{2:20t} ", car.Id, car.Make, car.Model);
        }
    }
}
