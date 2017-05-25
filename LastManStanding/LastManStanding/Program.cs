using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastManStanding
{
    class Program
    {
        public struct Man
        {
            public string Status;
            public int Order;
        }
        
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please enter the man count");

                int count = int.Parse(Console.ReadLine());

                Init(count);
            }
        }

        static public void Init(int n)
        {
            Man[] Soldiers = new Man[n];

            for (int i = 0; i < n; i++)
            {
                Soldiers[i].Order = i + 1;
                Soldiers[i].Status = "Alive";
            }

            Man LastSoldier = LastMan(Soldiers);

            Console.WriteLine("Last soldier is:" + LastSoldier.Order);

        }
        
        static public Man LastMan(Man[] Soldiers)
        {
            Man NextSoldier = new Man
            {
                Order = 0,
                Status = "Deceased"
            };

            while (ReturnAliveSoldiers(Soldiers) != 1)
            {

                var Soldier = Soldiers.Where(w => w.Status == "Alive" && w.Order > NextSoldier.Order).FirstOrDefault();


                if (Soldier.Status == null)
                {
                    Soldier = Soldiers.Where(w => w.Status == "Alive").FirstOrDefault();
                }

                
                NextSoldier = Soldiers.Where(w => w.Status == "Alive" && w.Order > Soldier.Order).FirstOrDefault();

                if (NextSoldier.Status == null)
                {
                    NextSoldier = Soldiers.Where(w => w.Status == "Alive").FirstOrDefault();
                }


                Soldiers[NextSoldier.Order - 1].Status = "Deceased";
                Console.WriteLine("Olen adam: " + NextSoldier.Order);
            }

            Man LastSoldierStanding = Soldiers.Where(w => w.Status == "Alive").SingleOrDefault();

            return LastSoldierStanding;
        }

        static public int ReturnAliveSoldiers(Man[] Soldiers)
        {
            int AliveSoldierCount = 0;

            for (int i = 0; i < Soldiers.Count(); i++)
            {
                if (Soldiers[i].Status == "Alive")
                {
                    AliveSoldierCount++;
                }
            }

            return AliveSoldierCount;
        }
    }
}
