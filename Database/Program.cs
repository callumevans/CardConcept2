using DbUp;
using System;
using System.Linq;

namespace Schema
{
    class Program
    {
        static int Main(string[] args)
        {
            string connectionString = args.FirstOrDefault()
                ?? "Server=localhost;Port=5432;User Id=postgres;Password=root;Database=cardgame";

            var upgrader = DeployChanges.To
                    .PostgresqlDatabase(connectionString)
                    .WithScriptsFromFileSystem("./Migrations")
                    .LogToConsole()
                    .WithTransaction()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();

                #if DEBUG
                Console.ReadLine();
                #endif

                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();

            return 0;
        }
    }
}
