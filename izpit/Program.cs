using System;
using System.Collections.Generic;

namespace izpit
{
    class Program
    {
        static void action(Car car)
        {
            Console.WriteLine($"Car number {car.number} costs {car.price.ToString("0.00").Replace(',', '.')}");
        }
        static void Main(string[] args)
        {
            Dictionary<string, Store> Stores=new Dictionary<string, Store>();
            string cmdstring;
            do
            {
                cmdstring = Console.ReadLine();
                string[] param = cmdstring.Split(' ');
                switch (param[0])
                {
                    case "CreateStore":
                        {
                            
                            string storename = param[1];
                            if (storename.Length < 5)
                            {
                                Console.WriteLine("Invalid store name!");
                               // throw new ArgumentException("Invalid store name!");
                            }
                            else
                            {
                                Stores[storename] = new Store(storename);
                                Console.WriteLine($"You created store {storename}.");
                            }
                            break;
                        }
                    case "AddCar":
                        {
                            int carid = Convert.ToInt32(param[1].Trim());
                            double carprice = Convert.ToDouble(param[2].Trim().Replace('.',','));
                            string storename = param[3];
                            if(Stores.ContainsKey(storename))
                            {
                               if(carprice<1000)
                               {
                                    Console.WriteLine("Invalid car price!");
                                    //throw new ArgumentException("Invalid car price!");
                               }
                               else
                               {
                                    Car tmp = new Car(carid, carprice);
                                    Stores[storename].AddCarToStore(tmp);
                                    Console.WriteLine($"You added car with number {carid} to store {storename}.");

                               }

                            }
                            break;
                        }
                    case "StoreInfo":
                        {
                            string storename = param[1];
                            if(Stores.ContainsKey(storename))
                            {
                                List<Car>tmp = Stores[storename].GetCarsList();
                                int numcars = tmp.Count;
                                if (numcars == 0)
                                {
                                    Console.WriteLine($"Store {storename} has no available cars.");
                                }
                                else
                                {
                                    Console.WriteLine($"Store {storename} has {numcars} car/s:");
                                    tmp.ForEach(action);
                                }
                            }
                            break;
                        }
                    case "SellCar":
                        {
                            int num = Convert.ToInt32(param[1].Trim());
                            double price = Convert.ToDouble(param[2].Trim().Replace('.', ','));
                            string store = param[3];
                            Car tmp = new Car(num, price);
                            bool flag=Stores[store].SellCar(tmp);
                            if (flag) Console.WriteLine($"You sold car with number {num} from store {store}.");
                            break;
                        }
                    case "SellAllCars":
                        {
                            string store = param[1];
                            Stores[store].SellAllCars();
                            Console.WriteLine($"You sold all cars from store {store}.");
                            break;
                        }
                    case "CalculateTotalPrice":
                        {
                            string store = param[1];
                            double total = Stores[store].CalculateTotalPrice();
                            Console.WriteLine($"Total price: {total}");
                            break;
                        }
                    case "RenameStore":
                        {

                            string store = param[1];
                            string newname = param[2];
                            if (newname.Length < 5)
                            {
                                Console.WriteLine("Invalid store name!");
                                // throw new ArgumentException("Invalid store name!");
                            }
                            else
                            {
                                Stores[newname] = Stores[store];
                                Stores[newname].RenameStore(newname);
                                Stores.Remove(store);
                                Console.WriteLine($"You renamed your store from {store} to {newname}.");
                            }
                            
                            break;
                        }
                    case "GetCarWithHighestPrice":
                        {
                            string store = param[1];
                            Car highest = Stores[store].GetCarWithHighestPrice();
                            Console.WriteLine($"Car from store {store} has highest price: {highest.price.ToString("0.00").Replace(',', '.')}");
                            break;
                        }
                    case "GetCarWithLowestPrice":
                        {
                            string store = param[1];
                            Car lowest = Stores[store].GetCarWithLowestPrice();
                            Console.WriteLine($"Car from store {store} has lowest price: {lowest.price.ToString("0.00").Replace(',','.')}");
                            break;
                        }
                    case "STOP":
                        {
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid command!");
                            break;
                        }
                }
            }
            while (cmdstring != "STOP");
        }
    }
}
