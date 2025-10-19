using System;
using System.Collections.Generic;
using System.Linq;

namespace Academia_Super_Eroilor
{
    internal class Program
    {
        class Hero
        {
            public string Name { get; set; }

            private int _level;

            public int Level
            {
                set
                {
                    if (value > 0 && value < 11)
                    {
                        _level = value;
                    }
                    else
                        _level = 1;
                }
                get { return _level; }
            }

            public Hero(string name, int level)
            {
                Name = name;   
                Level = level;
            }

            public Power powers;
            
        }

        class Power
        {
            public string Power1 { get; set; }
            public string Power2 { get; set; }
            public string Power3 { get; set; }

            public Power(string power1, string power2, string power3)
            {
                Power1 = power1;   
                Power2 = power2;
                Power3 = power3; 
            }
        }

        class Training
        {
            public int[][] Grades { get; set; }

            public List<Hero> hero;

            Random rnd = new Random();
            public int[][] Grading()
            {
                  
                int[][] grades = new int[10][];
                
                for (int i = 0; i < hero.Count; i++)
                {
                    int count = 0;
                    while(count ==  0) count = rnd.Next(10);
                    grades[i] = new int[count+1];
                    Console.WriteLine("{0}: ", i.ToString());

                    for (int j = 0; j <= count; j++)
                    {
                        if (hero[i].Level < 5)
                            grades[i][j] =  rnd.Next(6) ;
                        if (hero[i].Level > 5)
                        {
                            grades[i][j] = rnd.Next(11);
                            while (grades[i][j] < 5)
                                grades[i][j] = rnd.Next(11);
                        }
                        Console.WriteLine(grades[i][j]);
                    }
                    Console.WriteLine("\n");
                }
                return grades;
            }
        }

        class Academy
        {
            public List<Hero> hero;

            public void Output()
            {
                foreach (Hero h in hero)
                    Console.WriteLine($"Hero {h.Name} has the power of {h.powers.Power1} \n");
  
            }

            public void Run(double average, int i)
            {
                Console.WriteLine($"{hero[i].Name} (level {hero[i].Level}) obtained the average {average} - ");
                if(average == 10) Console.WriteLine("pfft how did u even get this grade? ");
                if (average >= 7 && average < 10) Console.WriteLine("you could've done better bro. ");
                if( average <= 7 && average > 4) Console.WriteLine(" L ");
                if(average <= 4) Console.WriteLine("go back to training ;-; . ");
            }
        }


        static void Main(string[] args)
        {

            List<Hero> heroes = new List<Hero>
            {
                new Hero("Superman", 8) ,
                new Hero("Batman", 6),
                new Hero("Ironman", 10),
                new Hero("Captain America", 4)
            };

            List<Power> powers = new List<Power>
            {
                new Power ("Super strength", "Flight", "Heat vision"),
                new Power ("Genius-level intellect", "Martial artist", "Advanced gadgets"),
                new Power ("Power armor", "Genius", "Advanced AI"),
                new Power ("Enhanced strength", "Expert in combat", "Vibranium shield")
            };

            for(int i = 0;i < heroes.Count;i++)
            {
                heroes[i].powers = powers[i];
            }

            Training training = new Training
            { 
                hero = heroes,
            };
            training.Grades = training.Grading();

            Academy academy = new Academy
            {
                hero = heroes
            };

            academy.Output();

            for (int i = 0; i < heroes.Count; i++)
                academy.Run((double)training.Grades[i].Sum(x => x) / (double)training.Grades[i].Length, i);


        }
    }
}
