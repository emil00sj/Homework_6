using System;

namespace Tasks_Tumakov
{
    //Упражнение 7.1)
    enum AccountType { Current, Savings, Deposit };
    class BankAccount
    {
        private int accountNumber;
        private decimal balance;
        private AccountType type;
        public BankAccount(int accountNumber, decimal balance, AccountType type)
        {
            this.accountNumber = accountNumber;
            this.balance = balance;
            this.type = type;
        }
        public int GetAccountNumber()
        {
            return accountNumber;
        }
        public decimal GetBalance()
        {
            return balance;
        }
        public AccountType GetType()
        {
            return type;
        }
    }
    // Упражнение 7.2) 
    enum AccountType1 { Current, Savings, Deposit };
    class BankAccount1
    {
        private static int nextAccountNumber = 1000;
        private int accountNumber;
        private decimal balance;
        private AccountType1 type;
        public BankAccount1(decimal balance, AccountType1 type)
        {
            this.balance = balance;
            this.type = type;
            accountNumber = GetNextAccountNumber();
        }
        public int GetAccountNumber()
        {
            return accountNumber;
        }
        public decimal GetBalance()
        {
            return balance;
        }
        public AccountType1 GetType()
        {
            return type;
        }
        static int GetNextAccountNumber()
        {
            nextAccountNumber++;
            return nextAccountNumber;
        }
    }
    // Упржнение 7.3)
    enum AccountType3 { Current, Savings, Deposit };
    class BankAccount3
    {
        private static int nextAccountNumber = 1000;
        private decimal balance;
        private int accountNumber;
        public decimal MinBalance { get; set; } = 0m;
        private AccountType3 type;
        public BankAccount3 (decimal balance, AccountType3 type)
        {
            this.balance = balance;
            this.type = type;
            accountNumber = GetNextAccountNumber();
        }
        public int GetAccountNumber()
        {
            return accountNumber;
        }
        public decimal GetBalance()
        {
            return balance;
        }
        public AccountType3 GetType()
        {
            return type;
        }
        static int GetNextAccountNumber()
        {
            nextAccountNumber++;
            return nextAccountNumber;
        }
        public void Withdraw(decimal amount)
        {
            if (amount <= 0 || amount > balance)
                throw new ArgumentOutOfRangeException("Сумма должна быть положительной и не превышать баланс.");
            balance -= amount;
        }
        public bool Deposit(decimal amount)
        {
            if (!MinBalance.Equals(0))
            {
                if (balance + amount < MinBalance)
                    return false;
            }
            balance += amount;
            return true;
        }
    }
    // Домашнее задание 7.1)
    class Building
    {
        private static int nextBuildingNumber = 10;
        private int buildingNumber;
        private double height;
        private int floorsCount;
        private int apartmentsCount;
        private int entrancesCount;
        public Building(double height, int floorsCount, int apartmentsCount, int entrancesCount)
        {
            this.height = height;
            this.floorsCount = floorsCount;
            this.apartmentsCount = apartmentsCount;
            this.entrancesCount = entrancesCount;
            buildingNumber = GetNextBuildingNumber();
        }
        public int GetBuildingNumber()
        {
            return buildingNumber;
        }
        public double GetHeight()
        {
            return height;
        }
        public int FloorsCount()
        {
            return floorsCount;
        }
        public int ApartmentsCount()
        {
            return apartmentsCount;
        }
        public int EntrancesCount()
        {
            return entrancesCount;
        }
        static int GetNextBuildingNumber()
        {
            nextBuildingNumber++;
            return nextBuildingNumber;
        }
        public void PrintInfo()
        {
            Console.WriteLine("Номер здания: " + buildingNumber);
            Console.WriteLine($"Высота: {height} м");
            Console.WriteLine($"{floorsCount} этажей (1-5)");
            Console.WriteLine($"{apartmentsCount} квартир(1-20)");
            Console.WriteLine($"{entrancesCount} подъезд(1-4)");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 7.1");
            BankAccount account = new BankAccount(22002201, 1000.0m, AccountType.Savings);
            Console.WriteLine("Номер счета: " + account.GetAccountNumber());
            Console.WriteLine("Баланс: " + account.GetBalance());
            Console.WriteLine("Тип счета: " + account.GetType());

            Console.WriteLine("\nУпражнение 7.2");
            BankAccount1 acccount = new BankAccount1(100.0m, AccountType1.Savings);
            Console.WriteLine("Номер счета: " + acccount.GetAccountNumber());
            Console.WriteLine("Баланс: " + acccount.GetBalance());
            Console.WriteLine("Тип счета: " + acccount.GetType());

            Console.WriteLine("\nУпражнение 7.3");
            BankAccount3 account3 = new BankAccount3 (100.0m, AccountType3.Savings);
            Console.WriteLine("Номер счета: " + account3.GetAccountNumber());
            Console.WriteLine("Баланс: " + account3.GetBalance());
            Console.WriteLine("Тип счета: " + account3.GetType());
            try
            {
                account3.Withdraw(50);
                Console.WriteLine($"Снято со счёта {50} руб.");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            bool success = account3.Deposit(150);
            if (success)
                Console.WriteLine($"Положено на счёт {150} руб.");

            Console.WriteLine("\nДомашнее задание 7.1)");
            Building building = new Building(25, 5, 20, 4);
            building.PrintInfo();
            Console.ReadKey();
        }
    }
}
