using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System
{
    internal class InventoryManagement
    {
        static void Main(string[] args)
        {

            Inventory inventory = new Inventory();
            char ch;
            do
            {
                Console.WriteLine("Inventory Management System");
                Console.WriteLine("1. Add a new item");
                Console.WriteLine("2. Display Items");
                Console.WriteLine("3. Find Item with ID ");
                Console.WriteLine("4.Update Item ");
                Console.WriteLine("5.Delete a item");
                Console.WriteLine("6.Exit");
                Console.Write("Enter your choice:");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Item ID:");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter Item Name:");
                        string name = Console.ReadLine();
                        Console.Write("Enter Item Price:");
                        int price = int.Parse(Console.ReadLine());
                        Console.Write("Enter Quantity :");
                        int quantity = int.Parse(Console.ReadLine());
                        inventory.AddItem(new Item(id, name, price, quantity));
                        break;
                    case 2:
                        inventory.DisplayItem();
                        break;
                    case 3:
                        Console.Write("Enter id of the item:");
                        int fid = int.Parse(Console.ReadLine());
                        inventory.FindItem(fid);
                        break;
                    case 4:
                        Console.Write("Enter id of the item:");
                        int uid = int.Parse(Console.ReadLine());
                        inventory.UpdateItemById(uid);
                        break;

                    case 5:
                        Console.Write("Enter id of the item:");
                        int did = int.Parse(Console.ReadLine());
                        inventory.DeleteItem(did);
                        break;
                    case 6:
                        System.Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
                Console.WriteLine("Do you want to continue: y or n");
                ch = Console.ReadKey().KeyChar;
            } while (ch == 'y' || ch == 'Y');
        }



    }
}


    internal class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public Item(int id,string name,int price,int quantity)
        {
            ID = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

    }

     internal class Inventory
    {
        private List<Item> items = new List<Item>();

        public void AddItem(Item item)
        {
             items.Add(item);
            Console.WriteLine("Item added successfully");

        }

        public void DisplayItem()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("No Item Added");
            }
            else
            {
                foreach(var Item in items)
                {
                    Console.WriteLine($"ID: {Item.ID} , Name : {Item.Name}, Price: {Item.Price}, Quantity:{Item.Quantity}");
                }
            }
        }

        public void FindItem(int id)
        {
            int index = -1;
            for(int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == id)
                {
                    index = i;
                    break;  
                }
            }

            if (index != -1)
            {
                Console.WriteLine($"Details of item with id {id} are : Name {items[index].Name}, Price : {items[index].Price}");
            }
            else
            {
                Console.WriteLine($"Item not found with id : {id}");
            }
        }

        public void UpdateItemById(int id)
        {
            int index = -1;
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == id)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                Console.WriteLine($"Item not found with id : {id}");
            }
            else
            {
                Console.WriteLine("Enter the New Name of the Item:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the new Price of the Item:");
                int price = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the new Quantity of the Item:");
                int quantity = int.Parse(Console.ReadLine());
                items[index].Name = name;
                items[index].Price = price;
                items[index].Quantity = quantity;
                Console.WriteLine("Update Successfully");
            }
        }

        public void DeleteItem(int id)
        {
            Item item = items.Find(i => i.ID == id);
            if (item != null)
            {
                items.Remove(item);
                Console.Write($"Item Deleted with id : {id}");
            }
            else
            {
                Console.WriteLine($"No item with id:{id}");
            }
        }
    }

