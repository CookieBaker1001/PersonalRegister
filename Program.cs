namespace PersonalRegister
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Personal Register!");

            List<Employee> employees = new List<Employee>();

            bool exit = false;
            string input = string.Empty;

            while (!exit)
            {
                PrintMenu();
                input = Console.ReadLine();
                int option = 0;
                try
                {
                    option = int.Parse(input);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }
                if (option == 1)
                {
                    employees.Add(AddEmployee());
                }
                else if (option == 2)
                {
                    PrintEmployeeList(employees);
                }
                else {
                    exit = true;
                }
            }

            Console.WriteLine("Exiting program.");
        }

        static void PrintEmployeeList(List<Employee> employees) {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees to display.");
            }
            else {
                Console.WriteLine("--- Employees ---");
                foreach (var e in employees)
                {
                    Console.WriteLine("Name: " + e.Name + ", Salary: " + e.Salary);
                }
            }
            Console.WriteLine();
        }

        static Employee AddEmployee() {
            string name = string.Empty;
            while (string.IsNullOrEmpty(name)) {
                Console.WriteLine("Type the new Employees name.");
                Console.Write(">");
                name = Console.ReadLine();
            }
            int salary = 0;
            bool validSalary = false;
            while (!validSalary) {
                Console.WriteLine("Type " + name + "'s salary.");
                Console.Write(">");
                try
                {
                    salary = int.Parse(Console.ReadLine());
                    validSalary = true;
                }
                catch (FormatException) {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }
            }
            Console.WriteLine();
            return new Employee(name, salary);
        }

        static void PrintMenu() {
            Console.WriteLine("Choose an action:");
            Console.WriteLine("1. Add employee");
            Console.WriteLine("2. View employees");
            Console.WriteLine( "3. Exit");
            Console.Write(">");
        }
    }
}
