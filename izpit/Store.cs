using System;
using System.Collections.Generic;
using System.Text;

namespace izpit
{
    public class Store
    {
        string name;
        List<Car> Cars;
        public Store(string name)
        {
            this.name = name;
            Cars = new List<Car>();
        }
        public Car GetCarWithHighestPrice()
        {
            Car result=new Car(0,0);
            double curmax = 0;
            for(int i =0;i<Cars.Count;i++)
            {
                if(Cars[i].price>curmax)
                {
                    result.number = Cars[i].number;
                    result.price = Cars[i].price;
                    curmax = Cars[i].price;
                }
            }
            return result;
        }
        public Car GetCarWithLowestPrice()
        {
            Car result = new Car(0, 0);
            double curmin = 0;
            for (int i = 0; i < Cars.Count; i++)
            {
                if (curmin == 0)
                {
                    result.number = Cars[i].number;
                    result.price = Cars[i].price;
                    curmin = Cars[i].price;
                }
                else if (Cars[i].price < curmin)
                {
                    result.number = Cars[i].number;
                    result.price = Cars[i].price;
                    curmin = Cars[i].price;
                }
            }
            return result;
        }
        public void AddCarToStore(Car car)
        {
            this.Cars.Add(car);
        }
        public List<Car> GetCarsList()
        {
            return Cars;
        }
        public void RenameStore(string newname)
        {
            this.name = newname;
        }
        public double CalculateTotalPrice()
        {
            double result = 0;
            for(int i=0;i<Cars.Count;i++)
            {
                result += Cars[i].price;
            }
            return result;
        }
        static Car test;
        Predicate<Car> pred = match;
        static bool match(Car car)
        {
            if (car.number == test.number && car.price == test.price)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SellCar(Car car)
        {
            test = car;
            int num=Cars.RemoveAll(pred);
            return num>0;
        }
        public void SellAllCars()
        {
            Cars.Clear();
        }
    }
}
