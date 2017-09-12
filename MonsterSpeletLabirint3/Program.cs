using System;
using System.Collections;
using System.Collections.Generic;

namespace MonsterSpeletLabirint3
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList path = new ArrayList() { "up", "left", "left", "right", "up", "left", "up", "right", "left", "right" };

            
            int steg = 0;
            
            int damage = GetDamage();

            Console.WriteLine("YOU HAVE ENTERED AN EVIL LABIRYNTH. CHOOSE THE RIGHT PATH, YOU LIVE. CHOOSE WRONG AND YOU'LL FACE A MONSTER!");

            for (int i = 0; i < path.Count; i++)
            {
                Console.WriteLine("Which way will you go? (up, left or right?)");
                string userInput = GetUserInput();
                int life = Life(damage);

                if (life < 0)
                { // skriv kod som skriver ut att man dött för att sedan avsluta

                    Console.WriteLine("HAHAHA! You DIED!!!");

                }
                else if (path[i].ToString() == userInput)      // <----Will the cast be a problem??
                {
                    Console.WriteLine("You went the right way. What's your next step?");
                    steg++;
                }
                else if (path[i].ToString() != userInput)
                {
                    GenerateMonster(ref life);

                    GetDamage();

                    Life(damage);
                    

                }
            }
        }


        static string GetUserInput()
        {
            
            string userInput = Console.ReadLine();
            return userInput;
        }

        static void GenerateMonster(ref int life)
        {
            LabirintMonster Artax = new LabirintMonster();
            Artax.name = "Artax";
            LabirintMonster Diablo = new LabirintMonster();
            Diablo.name = "Diablo";
            LabirintMonster Rexx = new LabirintMonster();
            Rexx.name = "Rexx";
            LabirintMonster Drexx = new LabirintMonster();
            Rexx.name = "Drexx";
            LabirintMonster Ghrar = new LabirintMonster();
            Ghrar.name = "Ghrar";
            

            List<LabirintMonster> monsterlist = new List<LabirintMonster>();

            monsterlist.Add(Artax);
            monsterlist.Add(Diablo);
            monsterlist.Add(Rexx);
            monsterlist.Add(Drexx);
            monsterlist.Add(Ghrar);

            Random randommonster = new Random();

            int monsterKey = randommonster.Next(0,5);

            

            Console.WriteLine("Oh NO! You ran into: {0}. Your remaining health is: {1}", monsterlist[monsterKey].name, life);

            

            

        }

        static int GetDamage()
        {
            Random random = new Random();
            int damage = random.Next(5, 15);

            return damage;
        }
        static int Life(int damage)
        {
            int life = 100;
            return life - damage;
        }
    }
}
