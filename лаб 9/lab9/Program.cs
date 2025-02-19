using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace lab9
{
    public class Car
    {
        public string Model { get; set; }
        public int Year { get; set; }

        public Car(string model, int year)
        {
            Model = model;
            Year = year;
        }

        public override bool Equals(object obj)
        {
            if (obj is Car other)
            {
                return Model == other.Model && Year == other.Year;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Model, Year);
        }
        public override string ToString()
        {
            return $"{Model} ({Year})";
        }
    }

    public class CarSet: ISet<Car>
    {

        public Dictionary<int, Car> Cars { get; set; } = new Dictionary<int, Car>();

        public int Count => Cars.Count;
        public bool IsReadOnly => false;

        public bool Add(Car item)
        {
            if (Cars.ContainsKey(item.GetHashCode()))
                return false;
            Cars[item.GetHashCode()] = item;
            return true;
        }

        void ICollection<Car>.Add(Car item) => Add(item);

        public void Clear()
        {
            Cars.Clear();
        }

        public bool Contains(Car item)
        {
            return Cars.ContainsKey(item.GetHashCode());
        }

        public void CopyTo(Car[] array, int arrayIndex)
        {
            foreach (var car in Cars.Values)
            {
                array[arrayIndex++] = car;
            }
        }

        public void ExceptWith(IEnumerable<Car> other)
        {
            foreach (var car in other)
            {
                Cars.Remove(car.GetHashCode());
            }
        }

        public IEnumerator<Car> GetEnumerator()
        {
            return Cars.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void IntersectWith(IEnumerable<Car> other)
        {
            var otherKeys = new HashSet<int>();
            foreach (var car in other)
            {
                otherKeys.Add(car.GetHashCode());
            }

            var keysToRemove = new List<int>();
            foreach (var key in Cars.Keys)
            {
                if (!otherKeys.Contains(key))
                    keysToRemove.Add(key);
            }

            foreach (var key in keysToRemove)
            {
                Cars.Remove(key);
            }
        }

        public bool IsProperSubsetOf(IEnumerable<Car> other)
        {
            return new HashSet<Car>(this).IsProperSubsetOf(other);
        }

        public bool IsProperSupersetOf(IEnumerable<Car> other)
        {
            return new HashSet<Car>(this).IsProperSupersetOf(other);
        }

        public bool IsSubsetOf(IEnumerable<Car> other)
        {
            return new HashSet<Car>(this).IsSubsetOf(other);
        }

        public bool IsSupersetOf(IEnumerable<Car> other)
        {
            return new HashSet<Car>(this).IsSupersetOf(other);
        }

        public bool Overlaps(IEnumerable<Car> other)
        {
            return new HashSet<Car>(this).Overlaps(other);
        }

        public bool Remove(Car item)
        {
            return Cars.Remove(item.GetHashCode());
        }

        public bool SetEquals(IEnumerable<Car> other)
        {
            return new HashSet<Car>(this).SetEquals(other);
        }

        public void SymmetricExceptWith(IEnumerable<Car> other)
        {
            foreach (var car in other)
            {
                if (Cars.ContainsKey(car.GetHashCode()))
                    Cars.Remove(car.GetHashCode());
                else
                    Add(car);
            }
        }

        public void UnionWith(IEnumerable<Car> other)
        {
            foreach (var car in other)
            {
                Add(car);
            }
        }


    }




    class Program
    {
        static void Main(string[] args)
        {

            var carSet = new CarSet();
            carSet.Add(new Car("Toyota", 2020));
            carSet.Add(new Car("BMW", 2019));
            carSet.Add(new Car("Audi", 2021));

            Console.WriteLine("CarSet Collection:");
            foreach (var car in carSet.Cars.Values)
            {
                Console.WriteLine(car);
            }

            var intList = new List<int> { 10, 20, 30, 40, 50, 60, 70 };
            Console.WriteLine("\nList<int> Collection:");
            Console.WriteLine(string.Join(", ", intList));

            int n = 3;
            intList.RemoveRange(0, n);

            Console.WriteLine($"\nList<int> после удаления {n} элементов:");
            Console.WriteLine(string.Join(", ", intList));

            intList.Add(80);
            intList.Insert(0, 5);
            intList.AddRange(new[] { 90, 100 });

            Console.WriteLine("\nList<int> после добавления элементов:");
            Console.WriteLine(string.Join(", ", intList));

            // вторая коллекция
            var sortedList = new SortedList<int, int>();
            for (int i = 0; i < intList.Count; i++)
            {
                sortedList.Add(i, intList[i]);
            }

            Console.WriteLine("\nSortedList<int, int> Collection:");
            foreach (var kvp in sortedList)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }

            int searchValue = 50;
            Console.WriteLine($"\n поиск значения{searchValue}");
            bool found = sortedList.ContainsValue(searchValue);
            Console.WriteLine(found ? "значение найдено" : "значение не найдено.");

            // ObservableCollection<T>
            var observableCollection = new ObservableCollection<Car>();

            observableCollection.CollectionChanged += (sender, e) =>
            {
                Console.WriteLine($"Action: {e.Action}");
                if (e.NewItems != null)
                {
                    foreach (Car newItem in e.NewItems)
                    {
                        Console.WriteLine($"добавлено: {newItem}");
                    }
                }

                if (e.OldItems != null)
                {
                    foreach (Car oldItem in e.OldItems)
                    {
                        Console.WriteLine($"удалено: {oldItem}");
                    }
                }
            };

            observableCollection.Add(new Car("Tesla", 2022));
            observableCollection.Add(new Car("Mercedes", 2020));
            observableCollection.RemoveAt(0);




        }
    }
}
