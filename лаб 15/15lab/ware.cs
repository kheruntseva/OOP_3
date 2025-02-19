using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using System.Threading;


namespace lab15
{
    public class Warehouse
    {
        public string name;
        int balance = 1500;
        public bool isOpen = true;
        public BlockingCollection<Products> goods;
        public string transactions = "";
        public Warehouse(string name)
        {
            this.name = name;
            goods = new BlockingCollection<Products>();
        }
        public void RunStore(Producer producer, Buyer buyer)
        {
            Parallel.Invoke(
                () => ShowInfo(),
                () => OpenWarehouse(),
                () => producer.Produce(this),
                () => buyer.Buy(this)
                );

        }
        public void ShowInfo()
        {
            while (isOpen)
            {
                Console.Clear();
                Console.WriteLine($"Warehouse: {name}");
                Console.WriteLine($"Money: {balance}");
                Console.WriteLine("Operations:");

                Console.WriteLine(transactions);

                Thread.Sleep(1000);
            }
        }
        public void OpenWarehouse()
        {
            Thread.Sleep(30000);
            isOpen = false;
            Thread.Sleep(5000);
            Console.WriteLine("\n\nThe warehouse is not working now");
        }
        public void AddGood(Products good, int amount)
        {
            for (int i = 0; i < amount; i++)
            { goods.Add(good); }
            balance -= good.price * amount;

        }
        public bool BuyGood(Products item, int patience)
        {
            if (goods.TryTake(out item, patience))
            {
                balance += item.price * 2;
                return true;
            }
            else { return false; }
        }
    }
    public class Products
    {
        public string name;
        public int price;
        public Products(string name, int price)
        {
            this.name = name;
            this.price = price;
        }
    }
    public class Producer
    {
        public string name;
        public Products production;
        public int price;
        public int amount;
        public int time;
        string transanction;
        public Producer(string name, Products production, int amount, int time)
        {
            this.name = name;
            this.production = production;
            this.amount = amount;
            this.time = time;
            transanction = $"Producer {name} brought {amount} {production.name}. Cost: {amount * production.price}$\n";
        }
        public void Produce(Warehouse store)
        {
            while (store.isOpen)
            {
                store.AddGood(production, amount);
                store.transactions = transanction + store.transactions;
                Thread.Sleep(time * 1000);
            }
        }
    }
    public class Buyer
    {
        public string name;
        public Products favItem;
        int patience;
        string transanction_succes;
        string transanction_failed = "Transaction Failed\n";
        public Buyer(string name, Products item, int patience)
        {
            this.name = name;
            this.favItem = item;
            this.patience = patience;
            transanction_succes = $"{name} bought {favItem.name}. Price: {favItem.price * 2}$\n";
        }
        public void Buy(Warehouse warehouse)
        {
            Thread.Sleep(1000);
            while (warehouse.isOpen)
            {
                if (warehouse.BuyGood(favItem, patience * 1000))
                {
                    warehouse.transactions = transanction_succes + warehouse.transactions;
                }
                else { warehouse.transactions = transanction_failed + warehouse.transactions; }

                Thread.Sleep(3000);
            }
        }
    }
}

