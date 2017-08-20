using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;

namespace Assig2Task3
{
    class GarageProgram
    {
        private static Garage myGarage = new Garage();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the garage");
            int userSelection = 0;
           
            do
            {
                Console.Clear();

                userSelection = MainMenu(userSelection);

                switch (userSelection)
                {
                    case 1: CreateCarMenu(myGarage); break;
                    case 2: CreateCarMenu(myGarage); break;
                    case 3: RemoveCarMenu(myGarage); break;
                    case 4: CarSearchMenu(myGarage); break;
                    case 5: DisplayAll(myGarage); break;
                    default: userSelection=6 ; break;
                }

            } while (userSelection != 6);

        }

        public static void RemoveCarMenu(Garage garage)
        {
            //TODO
            Console.Clear();
            Console.WriteLine("Cars parked in the garage:");
            garage.Display();

            string userSelection = "Yes";
            int selection;
           
            do
            {
                //TODO: Do not display selection if garage is empty!
                Console.Write("\tPlease provide Id of the car you would like removed: ");

                selection = readInt();

                if (selection > 0)
                {
                    Car car = garage.Search(selection);
                    if (car == null)
                        Console.WriteLine("\tCar not parked in the garage!");
                    else
                    {
                        if (garage.Remove(car))
                            Console.WriteLine("\t Car with Id {0} removed from the garage!", selection);
                        else
                            Console.WriteLine("\t Car with Id {0} was not removed  the garage!", selection);
                    }
                }
                else
                    Console.WriteLine("\t Invalid car Id provided!", selection);
                
                Console.Write("Go back to main menu? [Yes]: ");
                userSelection = Console.ReadLine().Trim();
                if (userSelection.Length <= 0) userSelection = "Yes";
            } while (!userSelection.Equals("Yes", StringComparison.OrdinalIgnoreCase));
        }

        public static void CarSearchMenu(Garage garage)
        {
            Console.Clear();
            Console.WriteLine("Car Search:");
            string userSelection = "Yes";
            
            do
            {
                Console.Write("\tPlease provide car Id: ");
                garage.Display(readInt());

                Console.Write("Go back to main menu? [Yes]: ");
                userSelection = Console.ReadLine().Trim();
                if (userSelection.Length <= 0) userSelection = "Yes";
            } while (!userSelection.Equals("Yes", StringComparison.OrdinalIgnoreCase));
        }

        public static void DisplayAll(Garage garage)
        {
            Console.Clear();
            Console.WriteLine("Cars parked in the garage:");
            string userSelection = "Yes";
            do
            {
                garage.Display();
                Console.Write("Go back to main menu? [Yes]: ");
                userSelection = Console.ReadLine().Trim();
                if (userSelection.Length <= 0) userSelection = "Yes";
            } while (!userSelection.Equals("Yes", StringComparison.OrdinalIgnoreCase));
        }

        public static void CreateCarMenu(Garage garage)
        {
            Console.Clear();
            Console.WriteLine("Create new car menu. (input required for all fields)");

            string userSelection = "Yes";
            do
            {
                Car newCar = new Car();
                string userInput = "";
                PropertyInfo[] carProperties = CarUtil.GetProperties();

                foreach (PropertyInfo carProperty in carProperties)
                {
                    Console.Write($"\tCar {carProperty.Name}: ");
                    userInput = Console.ReadLine().Trim();

                    while (userInput.Length <= 0) 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"\tCar {carProperty.Name} (input required): ");
                        Console.ResetColor();
                        userInput = Console.ReadLine().Trim();
                    }
                    carProperty.SetValue(newCar, userInput);
                }
        
                Console.Write("Add car to the garage? [Yes] : ");
                userSelection = Console.ReadLine().Trim();
                if (userSelection.Length <= 0) userSelection = "Yes";

                if (userSelection.Equals("Yes", StringComparison.OrdinalIgnoreCase))
                {
                    if (garage.Add(newCar))
                        Console.WriteLine($"\tCar with id {newCar.Id} successfully added to the garage");
                    else
                        Console.WriteLine($"Car with id {newCar.Id} not added to the garage");
                }
             
                Console.Write("Create another car? [Yes]: ");
                userSelection = Console.ReadLine().Trim();
                if (userSelection.Length <= 0) userSelection = "Yes";

            } while (userSelection.Equals("Yes", StringComparison.OrdinalIgnoreCase));

        }

        public static int MainMenu(int previousSelection)
        {
            Console.WriteLine("Menu Selection");
            Console.WriteLine("\t(1) Create a car: ");
            Console.WriteLine("\t(2) Add new car (to garage): ");
            Console.WriteLine("\t(3) Remove the car (from garage): ");
            Console.WriteLine("\t(4) Search for a car (in garage): ");
            Console.WriteLine("\t(5) Display all cars (in garage): ");

            Console.WriteLine("\t(6) Exit");
            int selection = previousSelection;

            if (selection < 0)
                Console.WriteLine("Invalid selection provided!");

            Console.Write("Please select one option [1-6]: ");
            return readInt();
        }

        private static int readInt()
        {
            int selection = -1;
            try
            {
                selection = int.Parse(Console.ReadLine().Trim());
            }
            catch
            {
                selection = -1;
            }

            return selection;
        }
    }
}
