using System;

namespace Project_2
{
    internal static class Program
    {
        private static readonly CustomMaxHeap CustomHeap = new CustomMaxHeap(new Person[] { }, 50);

        private static readonly Action[] Actions =
        {
            AddPerson,
            CustomHeap.Print,
            IncreaseSkill,
            () => Console.WriteLine(CustomHeap.Maximum()),
            () => Console.WriteLine(CustomHeap.ExtractMaximum())
        };

        private static void ShowHelp()
        {
            Console.WriteLine(@"
1. Add new person
2. Print the list
3. Increase person skill level
4. Show the top person
5. Extract the top person
0. Exit
"); // Top? Superior? Best? idk
        }

        private static string GetInput(string name)
        {
            Console.Write($"{name}: ");
            return Console.ReadLine();
        }

        private static void AddPerson()
        {
            var age = Convert.ToInt32(GetInput("Age"));
            var skill = Convert.ToChar(GetInput("Skill (A-F)"));
            var person = new Person(age, skill);
            CustomHeap.Insert(person);
        }

        private static void IncreaseSkill()
        {
            var index = Convert.ToInt32(GetInput("Index"));
            var skill = Convert.ToChar(GetInput("Skill (A-F)"));
            CustomHeap.IncreaseSkillLevel(index - 1, skill);
        }

        private static int GetOption()
        {
            while (true)
            {
                Console.Write("> ");
                var input = Console.ReadLine();

                if (int.TryParse(input, out var option) && option >= 0 && option <= 5)
                    return option;

                Console.WriteLine("Invalid input.");
            }
        }

        private static void GetKey(bool exit = false)
        {
            var to = exit ? "exit" : "continue";
            Console.WriteLine($"\nPress any key to {to} ...");
            Console.ReadKey();
        }

        public static void Main()
        {
            int option;
            ShowHelp();
            while ((option = GetOption()) != 0)
                try
                {
                    var method = Actions[option - 1];
                    method.Invoke();

                    GetKey();
                    ShowHelp();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error => {e.Message}");
                }

            GetKey(true);
        }
    }
}