using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HelloMethods
{
    internal class Program
    {
        //Stats
        static int maxHealth = 100;
        static int health = 100;

        static int lives = 3;

        static int defense = 100;
        static int maxDefense = 100;

        static float score = 100f;
        static int str = 50;
        static int mana = 0;
        static int charisma = 25;

        //Game Objects
        static string gamerTag = "MediumSalsa";
        static string breaker = "<>====================================<>";
        static Random rnd = new Random();


        //Begin journey
        static void Main(string[] args)
        {



            ShowHUD();

            line();
            Console.WriteLine(gamerTag + " begins journey!");
            Console.WriteLine("Goal: Kill the lich king.");
            line();
            Console.WriteLine(breaker);
            line();
            Console.WriteLine(gamerTag + " enters cave.");
            line();
            Console.WriteLine(gamerTag + " encounters a Cave Worm...");
            TakeDamage(wormDamage);
            Console.WriteLine("Cave Worm Slain!");
            ScrMulti(wormScore);
            line();
            ShowHUD();
            line();
            Console.WriteLine("Continue down the path...");
            line();
            Console.WriteLine("A campfire comes into view...");
            Console.WriteLine("Approach?");

            int choice0 = rnd.Next(100, 200);

            if (choice0 <= 150) 
            { 
                Console.WriteLine("#Yes#"); 
            }
            else if (choice0 > 150)
            { 
                Console.WriteLine("#No, I'll go another way#");
                line();
                Console.WriteLine(gamerTag + " has fallen into a pit!");
                TakeDamage(20);
                ShowHUD();

            }
            line();
            Console.WriteLine(gamerTag + " has encountered a goblin camp...");
            Console.WriteLine("4 goblins approach");
            line();
            Console.WriteLine("Charisma level is " + charisma + ". You attempt to charm..." );
            line();

            int charmChance0 = rnd.Next(0, 35);
            if (charmChance0 >= 25)
            {
                Console.WriteLine("Goblins Charmed!");
                Console.WriteLine("Their shaman gifted you a <Mana Potion>");
                mana += 20;
               
            }
            else if (charmChance0 < 25)
            {
                Console.WriteLine("The gang was unfased...");
                Console.WriteLine("Fight initiated");
                line();
                int gangAmount = rnd.Next(2, 4); 
                TakeDamage(goblinDamage * gangAmount);
                if (health >= 0)
                {
                    Console.WriteLine("The army was slain!");
                    ScrMulti(goblinScore);
                    Console.WriteLine("You picked up <Goblin Shield>");
                    Console.WriteLine("Defense up +30");
                    defense += 30;
                }

            }

            line();
            ShowHUD();
            line();

            Console.WriteLine("Continuing down the cave...");
            line();
            Console.WriteLine(gamerTag + " has found a chest!");
            line();

           int mimicChance = rnd.Next(0, 100);
           if (mimicChance >= 35)
            {
                Console.WriteLine(gamerTag + " has recieved <Potion Of Imense Strength!");
                Console.WriteLine("Max health has increased");
                maxHealth += 50;
                health = maxHealth;
            }
            else
            {
                Console.WriteLine("It was a Mimic!");
                TakeDamage(mimicDamage);
                if (health > 0)
                {
                    Console.WriteLine("Mimic was Slain!");
                    ScrMulti(mimicScore);
                    line();
                    Console.WriteLine("Mimic dropped <Potion Of Imense Strength!");
                    Console.WriteLine("Max health has increased");
                    maxHealth += 50;
                    health = maxHealth;

                }
            }

            line();
            ShowHUD();

            Console.WriteLine("Continuing down the path...");
            Console.WriteLine("Theres a fork in the road. Do you go <Left> or <Right>");
            line();
            int choice1 = rnd.Next(100, 200);

            //RIGHT 0
            if (choice1 <= 150)
            {
                Console.WriteLine("#I'll go RIGHT#");
                Console.WriteLine("Continuing down the path to the right...");
                line();

                Console.WriteLine(gamerTag + " has fallen into a pit!");
                Console.WriteLine("Entered <Labyrinth>");
                TakeDamage(20);
                ShowHUD();

                Console.WriteLine("Continuing down the Labyrinth...");
                line();
                Console.WriteLine("Continuing down the Labyrinth...");
                line();
                Console.WriteLine("Continuing down the Labyrinth...");
                line();


                Console.WriteLine(gamerTag + " encounters a Minotaur!");
                Console.WriteLine("Boss Health: " + minotaurHealth);
                line();
                Console.WriteLine("Mana: " + mana);
                if (mana >= 10)
                {
                    Console.WriteLine(gamerTag + " casted a <FireBall>");
                    mana -= 10;
                    Console.WriteLine("-10 mana");
                    line();
                    minotaurHealth -= str;
                    Console.WriteLine(breaker);
                    Console.WriteLine("Boss Health: " + minotaurHealth);
                    Console.WriteLine(breaker);
                }
                else { Console.WriteLine("You do not cast a spell"); }
                line();
                Console.WriteLine("Strength: " + str);
                line();

                EngageBoss(minotaurHealth, minotaurDamage, minotaurName);







            }
                //LEFT 0
                else if (choice1 > 150)
                {
                    Console.WriteLine("#I'll go LEFT#");
                    Console.WriteLine("Continuing down the path to the left...");
                    line();
                }


            Console.ReadKey();
        }

        //--------------------------------------------------
        //----------------Enemy holding zone----------------
        static int wormDamage = rnd.Next(150, 170);
        static float wormScore = 1.15f;
        //
        static int goblinDamage = rnd.Next(10, 20);
        static float goblinScore = 1.1f;
        //
        static int mimicDamage = rnd.Next(10, 60);
        static float mimicScore = 1.15f;
        //
        static string minotaurName = "Minotaur";
        static int minotaurDamage = rnd.Next(25, 75);
        static int minotaurHealth = 150;
        static float minotaurScore = 1.2f;
        //----------------Enemy holding zone----------------
        //--------------------------------------------------


        static void EngageBoss(int bossHealth, int bossDamage, string bossName)
        {
            while (bossHealth > 0)
            {
                Console.WriteLine("You engage...");
                line();
                bossHealth -= str;
                Console.WriteLine(gamerTag + " did " + str + " damage...");

                line();
                if (bossHealth > 0)
                {
                    Console.WriteLine(breaker);
                    Console.WriteLine(bossName +  " Health: " + bossHealth);
                    Console.WriteLine(breaker);
                    line();
                    TakeDamage(bossDamage);
                    line();
                    ShowHUD();
                    line();
                }
                else
                {
                    bossHealth = 0;
                    Console.WriteLine(bossName + " slain!");
                    line();

                    TakeDamage(bossDamage);
                    ShowHUD();
                    
                    line();
                }


            }
            
        }


        //Damage player
        static void TakeDamage(int damage)
        {
            if (defense > 0)
            {
                defense -= damage;
                Console.WriteLine(gamerTag + " has taken " + damage + " damage to their defences!");
                if (defense <= 0)
                {
                    defense = 0;
                }
            }
            else
            {

                health -= damage;
                Console.WriteLine(gamerTag + " has taken " + damage + " damage!");

            }

            if (health <= 0)
            {
                health = maxHealth;
                defense = maxDefense;

                lives -= 1;
                Console.WriteLine(gamerTag + " has died...");
                Console.WriteLine("...RESPAWNING...");
                line();
            }

        }

        


        //Score multiplier
        static void ScrMulti(float multi)
        {

            score *= multi;
            

        }

        //Show the HUD
        static void ShowHUD()
        {


            Console.WriteLine(breaker);
            Console.WriteLine("{{ Score: " + score);
            Console.WriteLine("}} Lives: " + lives);
            if (defense > 0)
            {
                Console.WriteLine("{{ Health: " + health + "  | " + "Defense: " + defense);
            }
            else
            {
                Console.WriteLine("{{ Health: " + health + "  | " + "Defense: " + defense);
            }
            Console.WriteLine("}} Strength: " + str + " | " + "Mana: " + mana);
            Console.WriteLine(breaker);
        }

        //Useless shortcut that doesn't save time
        static void line()
        { Console.WriteLine(); }

    }
}
