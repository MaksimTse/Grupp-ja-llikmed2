using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_ja_liikmed
{
    public class Program
    {

        public static void Main()
        {

            Random random = new Random();

            List<Liik> group1Members = new List<Liik>();
            List<Liik> group2Members = new List<Liik>();

            for (int i = 0; i < 20; i++)
            {
                string name1 = GenerateRandomName(random);
                string name2 = GenerateRandomName(random);
                int age1 = random.Next(18, 60);
                int age2 = random.Next(18, 60);

                Liik liik1 = new Liik(name1, age1);
                Liik liik2 = new Liik(name2, age2);

                group1Members.Add(liik1);
                group2Members.Add(liik2);
            }

            string groupName1 = GenerateRandomName(random);
            int maxAmount1 = 20;
            Console.ForegroundColor = ConsoleColor.Red;
            Group group1 = new Group(groupName1, maxAmount1);
            Console.WriteLine($"Group 1 Max Spaces: {maxAmount1} ");

            string groupName2 = GenerateRandomName(random);
            int maxAmount2 = 20;
            Group group2 = new Group(groupName2, maxAmount2);
            Console.WriteLine($"Group 2 Max Spaces: {maxAmount2}\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Group 1 Candidates:");
            PrintColoredNames(group1Members);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nGroup 2 Candidates:");
            PrintColoredNames(group2Members);
            Console.WriteLine("\n");
            Console.ResetColor();

            for (int i = 0; i < maxAmount1; i++)
            {
                if (group1Members.Count > 0)
                {
                    Liik member = group1Members[0];
                    group1.AddMember(member.Name, member.Age);
                    group1Members.RemoveAt(0);
                }
            }

            for (int i = 0; i < maxAmount2; i++)
            {
                if (group2Members.Count > 0)
                {
                    int randomIndex = random.Next(group2Members.Count);
                    Liik member = group2Members[randomIndex];
                    group2.AddMember(member.Name, member.Age);
                    group2Members.RemoveAt(randomIndex);
                }
            }

            static void PrintResults(List<Liik> candidates, Group group)
            {
                foreach (Liik candidate in candidates)
                {
                    if (group.HasMember(candidate.Name))
                    {
                        Console.WriteLine($"{candidate.Name} has joined {group.Name}.");
                    }
                    else
                    {
                        Console.WriteLine($"{candidate.Name} did not join {group.Name}.");
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(group1.GetOldestMember());
            Console.WriteLine(group2.GetOldestMember());
            Console.ResetColor();
        }

        public static void Shuffle<T>(IList<T> list, Random random)
        {
            int n = list.Count;
            for (int i = 0; i < n; i++)
            {
                int r = i + random.Next(n - i);
                T temp = list[i];
                list[i] = list[r];
                list[r] = temp;
            }
        }

        public static string GenerateRandomName(Random random)
        {
            string[] names = { "John", "Mary", "Samantha", "Robert", "Emily", "Maksim", "Luca", "Alex", "Martin", "Yarik", "Sasha", "Timur", "Arkadii", "Archi", "Artur", "Albert", "Stark", "Tony", "Alik", "Mart", "Kirill", "Oleg" };
            return names[random.Next(names.Length)];
        }

        public static void PrintColoredNames(List<Liik> members)
        {
            HashSet<string> uniqueNames = new HashSet<string>();
            foreach (Liik member in members)
            {
                string name = member.Name;
                if (uniqueNames.Contains(name))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    uniqueNames.Add(name);
                }
                Console.Write($"{member}, ");
            }
            Console.ResetColor();
            Console.WriteLine();
        }

    }
}