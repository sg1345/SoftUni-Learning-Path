using System.Threading.Channels;

namespace _03.Raiding
{
    public class Program
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine()!);

            List<BaseHero> raidParty = new List<BaseHero>();
            int sumPower = 0;
            while (number > raidParty.Count)
            {
                string name = Console.ReadLine()!;
                string type = Console.ReadLine()!.ToLower();

                BaseHero? newHero = type switch
                {
                    "druid" => new Druid(name),
                    "paladin" => new Paladin(name),
                    "rogue" => new Rogue(name),
                    "warrior" => new Warrior(name),
                    _ => null
                };

                if (newHero == null)
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }
                
                raidParty.Add(newHero);
                
            }

            foreach (BaseHero hero in raidParty)
            {
                Console.WriteLine(hero.CastAbility());
                sumPower += hero.Power;
            }

            int bossPower = int.Parse(Console.ReadLine()!);

            if (sumPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        //static BaseHero? PrintMessageAndReturnNull()
        //{
            
        //    return null;
        //}
    }
}
