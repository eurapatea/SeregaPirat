using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace wtf
{
    
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
    }

    class Bank
    {
        private List<User> users = new List<User>();

        public void AddUser(int id, string name, double balance)
        {
            users.Add(new User { Id = id, Name = name, Balance = balance });
        }

        public void RemoveUser(int id)
        {
            users.RemoveAll(u => u.Id == id);
        }

        public void TransferMoney(int fromId, int toId, double amount)
        {
            var fromUser = users.FirstOrDefault(u => u.Id == fromId);
            var toUser = users.FirstOrDefault(u => u.Id == toId);

            if (fromUser == null || toUser == null)
            {
                Console.WriteLine("Неверный user id");
                return;
            }

            if (fromUser.Balance < amount)
            {
                Console.WriteLine("Недостаточно средств");
                return;
            }

            fromUser.Balance -= amount;
            toUser.Balance += amount;
        }

        public void SortByBalance()
        {
            users = users.OrderBy(u => u.Balance).ToList();
        }

        public void SortByName()
        {
            users = users.OrderBy(u => u.Name).ToList();
        }

        public void PrintUsers()
        {
            foreach (var user in users)
            {
                Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Balance: {user.Balance}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var bank = new Bank();

            while (true)
            {
                Console.WriteLine("Enter command (add, remove, transfer, sortbybalance, sortbyname, print, exit):");
                var command = Console.ReadLine();

                if (command == "add")
                {
                    Console.WriteLine("Enter user id:");
                    var id = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter user name:");
                    var name = Console.ReadLine();

                    Console.WriteLine("Enter user balance:");
                    var balance = double.Parse(Console.ReadLine());

                    bank.AddUser(id, name, balance);
                }
                else if (command == "remove")
                {
                    Console.WriteLine("Enter user id:");
                    var id = int.Parse(Console.ReadLine());

                    bank.RemoveUser(id);
                }
                else if (command == "transfer")
                {
                    Console.WriteLine("Enter from user id:");
                    var fromId = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter to user id:");
                    var toId = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter amount:");
                    var amount = double.Parse(Console.ReadLine());

                    bank.TransferMoney(fromId, toId, amount);
                }
                else if (command == "sortbybalance")
                {
                    bank.SortByBalance();
                }
                else if (command == "sortbyname")
                {
                    bank.SortByName();
                }
                else if (command == "print")
                {
                    bank.PrintUsers();
                }
                else if (command == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid command");
                }
            }
        }
    }


}