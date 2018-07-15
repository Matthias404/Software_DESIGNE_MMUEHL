using System;
using System.Collections.Generic;

using RPG_Items;
using RPG_People;
using RPG_Maps;
using RPG_Character;

public class Game
{
    public static void Main()
    {
        Game Rpg = new Game();
        Items.InitItems();
        People.InitPeople();
        Map.IntMap();


       while (Console.ReadLine() != "q")
            {
                Rpg.Start();
            };
    }

    public void Start()
    {     
        Console.WriteLine("Hallo Bitte Spielername Eingeben");
        People.Player.Name = Console.ReadLine();
        Console.WriteLine("Wähle einen Kapmfschrei");
        People.Player.Battlecall = Console.ReadLine();

        People.Consuela.InRoom = Map.Kitchen;
        People.YourMama.InRoom = Map.Toilet;
        People.Player.InRoom = Map.Foyer;
        
        Console.WriteLine("Hallo "+People.Player.Name+" Willkommen In die Schlachte des Gemezels");
        Console.WriteLine("und der Agriff der SchlEchten rechtschreibung");
        Console.WriteLine("");

        Look_Room();
    }

    public void Choises()
    {
        Console.WriteLine("Du kannst (l)Dich umschauen, (g)Gehen zu, (i)Interagiere,  (t)Nehemn, (in)Inventar, (s)Status, (q)Ende");
        String choise = Console.ReadLine();

        if (choise == "l" || choise == "g" || choise == "i" || choise == "t" || choise == "in" || choise == "s" || choise == "q")
        {
            switch (choise)
            {
                case "l":
                   Look_Room();
                   break;
                
                case "g":
                    Go();
                    break;

                case "i":
                    Interact();
                    Look_Room();
                    break;

                case "t":
                    People.Player.Take();
                    Look_Room();
                    break;

                case "in":
                    People.Player.ShowInventory();
                    Look_Room();
                    break;
                case "s":
                    People.Player.ShowStatus();
                    Look_Room();
                    break;
                case "q":
                    Exit();
                    break;
                    

                    
            }

        }
        else
        {
            Console.WriteLine("Bitte Korreckte Angaben machen");
            Choises();
        }
    }
  public void Go()
    {
        People.Consuela.Move();
        People.Player.Move();
        if (People.Player.InRoom == People.Consuela.InRoom)
        {
            Console.WriteLine("Du bist auf Consuela Getroffen.");
            Console.WriteLine(People.Consuela.Text);
            Console.WriteLine("Sie Greift An");
            Battle(People.Player, People.Consuela);
        }
        if (People.Player.InRoom == People.YourMama.InRoom)
        {
            Console.WriteLine("Du bist auf deine Mutter getroffen");
            Console.WriteLine(People.YourMama.Text);
            Console.WriteLine("Sie Greift An");
            Battle(People.Player, People.YourMama);
        }
        if (People.Player.InRoom == Map.Libury && People.Player.Inventory.Contains(Items.Galon))
        {
            GameWin();
        }
        Look_Room();
        
    }
          

    public void Look_Room()
    {
        Console.WriteLine("Du bist " + People.Player.InRoom.Name_Print);
        Console.WriteLine(People.Player.InRoom.InfoText);

        if (People.Player.InRoom.North!=null)
            Console.WriteLine("Im Norden ist " + People.Player.InRoom.North.Name);

        if (People.Player.InRoom.East != null)
            Console.WriteLine("Im Osten ist " + People.Player.InRoom.East.Name);

        if (People.Player.InRoom.South != null)
            Console.WriteLine("Im Süden ist " + People.Player.InRoom.South.Name);

        if (People.Player.InRoom.West != null)
            Console.WriteLine("Im Westen ist " + People.Player.InRoom.West.Name);


        People.Player.InRoom.ShowCharatersInRoom();
        People.Player.InRoom.ShowInventoryInRoom();

        Choises();
    }

   
    public void Interact()
    {
        People.Player.InRoom.ShowCharatersInRoom();
        if (People.Player.InRoom.Characters.Count != 0)
        {
            Console.WriteLine("Mit wem möchtest du reden? Namen Eingeben (mit Titel)");
            String how = Console.ReadLine();
            foreach (var i in People.Player.InRoom.Characters)
            {
                if (i.Name == how)
                {
                    Console.WriteLine(i.Text);
                }
                else
                {
                    Console.WriteLine("Bitte namen Korrect eingeben");
                    Interact();
                }
            }
        }
        else
        {
            
            Console.WriteLine("Weil niemand da war hast du dich mit den Steinen der Mauer unterhalten. Sie waren höchst beleidigt das du sie gestört hast");
            Console.WriteLine();
            Choises();
        }
    }

    //Battle
    public void Battle(Character defender, Character attaker)
    {
        String inp;
        
        if (attaker == People.Player)
        {
            Console.WriteLine("Was willst du Tuen?");
            Console.WriteLine("(a) Angreifen (m) Magie (u)Benutzen (r) Wegrennen");
            inp = Console.ReadLine();
        }
        else
        {
            inp = "a";
        }
        if (inp == "a" || inp == "m" || inp == "u" || inp == "r")
        {
            switch (inp)
            {
                case "a":
                    defender.Life = defender.Life - Math.Abs(attaker.Attack() - defender.Defense());

                    Console.WriteLine(defender.Name + "Schaden von " + Math.Abs(attaker.Atk - defender.Def) + " erlitten");
                    Console.WriteLine(defender.Name + " hat noch " + defender.Life + " Lebenspunkte");
                    Console.WriteLine();

                    break;

                case "m":
                    if (attaker.Magic >= attaker.MagicAtk)
                    {
                        attaker.Magic = attaker.Magic - attaker.MagicAtk;
                        defender.Life = defender.Life - attaker.MagicAtk * 2;
                        Console.WriteLine(defender.Name + "Schaden von " + Math.Abs(attaker.Atk - defender.Def) + " erlitten");
                        Console.WriteLine(defender.Name + " hat noch " + defender.Life + " Lebenspunkte");
                        Console.WriteLine(attaker.Name + "" + attaker.Magic + "hat noch");
                        Console.WriteLine();

                    }
                    else
                    {
                        Console.WriteLine("Du hast nicht genug Magie");
                        Battle(defender, attaker);
                    }
                    break;
                case "u":
                    attaker.ShowInventory();
                    break;
                case "r":
                    attaker.InRoom = Map.Foyer;
                    Choises();
                    break;
            }
            if (defender.Life <= 0)
            {
                Win(attaker, defender);
            }
            else
            {
                Battle(attaker, defender);
            }
        }
        else
        {
            Console.WriteLine("Bitte Korrekte eingabe machen");
            Battle(defender, attaker);
        }       
    }

    public void Win(Character a, Character b)
    {
        if (a == People.Player)
        {
            Console.WriteLine("Glückwunsch du bekommst " + b.Exp+" expiriens");
            a.Exp = a.Exp+b.Exp;
            if (a.Exp >= (a.Level ^ 2))
            {
                a.Level = a.Level + 1;
                Console.WriteLine("Du hast eine Neues Level erreicht");
                
                People.Player.Life = People.Player.MaxLife;
                People.Player.Magic = People.Player.MaxMagic;
                Console.WriteLine("Was Möchtest du Erhöhen?");                
                Console.WriteLine("(a)Angrif, (d)defense, (l)Leben");



                People.Consuela.Life = People.Consuela.MaxLife;
                People.Consuela.InRoom = Map.Kitchen;
                Look_Room();
            }
            else
            {
                Choises();
            }
        }
        else
        {
            Death();

        }

    }
    public static void Death()
    {
        Console.WriteLine("Du bist tot");
        Main();
    }
    public void GameWin()
    {
        Console.WriteLine("Herzlichen Glückwunsch du hast Zeit Verschendet");
        Console.WriteLine("Noch einmal zeoit Verschwenden?(j)ja (n)Nööööööööö echt nich");
        string ch = Console.ReadLine();
        if (ch == "j" || ch == "n")
        {
            Main();
        }
        else
        {
            Main();
        }
    }
    public void Exit()
    {
        Environment.Exit(0); 
    }
}


