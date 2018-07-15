using System;
using System.Collections.Generic;

using RPG_Classes;
using RPG_Items;
using RPG_People;
using RPG_Maps;


namespace RPG_Character
{
    public class Character
    {
        public String Name;
        public int Level;
        public int Life;
        public int MaxLife;
        public int Magic;
        public int MaxMagic;
        public int MagicAtk;
        public int Atk;
        public int Def;
        public int Exp;

        public String Text;
        public String Battlecall;
        public int GLoot;

        public Item[] Dress = new Item[] { Items.Cloths, Items.Fists };

        public List<Item> Inventory;
        public Room InRoom;
        

        public int Attack()
        {
            int atk_dam;
            Console.WriteLine("" + this.Battlecall);
           
            return atk_dam = (this.Atk + this.Dress[1].Bonus);

        }

        public int MagicAttack()
        {

            return Attack() + this.MagicAtk;
        }

        public int Defense()
        {
            int def_dam;

            return def_dam = this.Def + this.Dress[0].Bonus;

        }
        public void ShowStatus()
        {
            Console.WriteLine("Name "+this.Name);
            Console.WriteLine("Leben" + this.Life + "/" + this.MaxLife);
            Console.WriteLine("Leben" + this.Magic + "/" + this.MaxMagic);
            Console.WriteLine("Angriff " + this.Atk);
            Console.WriteLine("Verteidigung " +this.Def);
            Console.WriteLine("Du trägst "+this.Dress[0].Name);
            Console.WriteLine("und "+this.Dress[1].Name);
            Console.WriteLine("Level"+this.Level);
            Console.WriteLine("Erfahrung/nächstes Level " + this.Exp+ "/"+(this.Level^2));

        }

        public void Take()
        {
            
            if (this.InRoom.Inventory.Count >= 1)
            {
                this.InRoom.ShowInventoryInRoom();
                Console.WriteLine("Bitte namen des Items eingeben oder (a) für alles nehmen");
                String take =Console.ReadLine();
                if (take == "a")
                {
                    foreach (var i in this.InRoom.Inventory)
                    {
                        this.Inventory.Add(i);
                        Console.WriteLine("Du hast "+i.Name+"aufgeommen");
                    }
                    this.InRoom.Inventory.Clear();
                }
                try
                { 
                    this.Inventory.Add(this.InRoom.Inventory.Find(Items => Items.Name.Contains(take)));
                    this.InRoom.Inventory.Remove(this.InRoom.Inventory.Find(Items => Items.Name.Contains(take)));
                    Console.WriteLine("Du hast " + take + " aufgeommen");
                }
                catch
                {
                    Console.WriteLine("Leider nicht"+ take+"Gefunden");
                    Take();
                }                                                       
            }
            else
            {
                Console.WriteLine("Es ist nichts im Raum, aber du hast ein Paar schöne Fussel gefunden die die einsteckst");
                this.Inventory.Add(RPG_Items.Items.Dust);
                Console.WriteLine("Schöne Fussel Aufgenommen");
            }
        }
        public void ShowInventory()
        {
            try
            {
                foreach (var i in this.Inventory)
                {
                    Console.WriteLine(i.Name);
                }
            }
            catch {

            }
           
            if (this.Inventory.Count != 0)
            {
                
                if (this == People.Player)
                {
                    Console.WriteLine("Was möchtest du machen?");
                    Console.WriteLine("(u)Item Auswählen, (b)Zurück");
                    String ch = Console.ReadLine();
                   
                    if (ch == "u" || ch == "b")
                    {   
                        switch (ch)
                        {
                            
                            case "u":
                                
                                Console.WriteLine("Bitte Namen des gegenstands eingeben");
                                String chItem = Console.ReadLine();
                                try
                                {
                                    Item j = this.InRoom.Inventory.Find(Items => Items.Name.Contains(chItem));
                                }
                                catch
                                {
                                    Console.WriteLine("Bitte Korrekte angaben machen");
                                    ShowInventory();
                                }
                                    Console.WriteLine("Was möchtest du damit machen");
                                    Console.WriteLine("(u)benutzen, (l)ansehen, (r)ablegen, (b)zurück");
                                    String chUse = Console.ReadLine();
                                    if (chUse == "u" || chUse == "l" || chUse == "r" || chUse == "b")
                                    {
                                        Item j = this.Inventory.Find(Items => Items.Name.Contains(chItem));

                                        switch (chUse)
                                        {
                                            case "u":
                                                ItemUse(j);
                                                this.Inventory.Remove(j);                                                                                               
                                                break;
                                            case "l":
                                                Console.WriteLine(j.Name);
                                                Console.WriteLine(j.Text);
                                                break;
                                            case "r":
                                                this.InRoom.Inventory.Add(j);
                                                this.Inventory.Remove(j);
                                                
                                                break;
                                            case "b":

                                                break;
                                        }
                                    }

                                
                                                                                                                                                                            
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Bitte Korrekte angaben machen");
                    ShowInventory();
                }
            }
            else
            {
                Console.WriteLine("Es ist nichts im Inventar");
            }
        }
        public void ItemUse(Item a)
        {
            if (a.Type==Itemtype.Heal)
            {
                this.Life = this.Life+a.Bonus;
                if (this.Life>= this.MaxLife)
                {
                    this.Life = this.MaxLife;
                }
                if(this.Life>= 1)
                { 
                    Console.WriteLine(this.Name+"leben ist"+a.Bonus+"gestigen");
                    Console.WriteLine(this.Name + "leben ist jetzt" +this.Life);
                }
                else
                {                   
                    Game.Death();
                }
            }
            if (a.Type == Itemtype.MagicHeal)
            {
                this.Magic = +a.Bonus;
                if (this.Life >= this.MaxMagic)
                {
                    this.Life = this.MaxMagic;
                }
                Console.WriteLine(this.Name + "Magie ist" + a.Bonus + "gestigen");
                Console.WriteLine(this.Name + "Magie ist jetzt" + this.Life);
            }
            if (a.Type == Itemtype.Armor)
            {
                if (this.Dress[0] != null)
                {
                    Console.WriteLine("Du hast "+this.Dress[0]+"abgelegt");
                    this.Inventory.Add(this.Dress[0]);

                }
                this.Dress[0] = a;
                
                this.Inventory.Remove(a);

                Console.WriteLine("Du trägst jetzt"+a.Name);
                
            }
            if (a.Type == Itemtype.Weapon)
            {
                if (this.Dress[1] != null)
                {
                    Console.WriteLine("Du hast " + this.Dress[1] + "abgelegt");
                    this.Inventory.Add(this.Dress[1]);
                }
                this.Dress[1] = a;
                Console.WriteLine("Du trägst jetzt" + a.Name);
                this.Inventory.Remove(a);
            }
            if (a.Type == Itemtype.Key)
            {
                Console.WriteLine(a.Text);
            }
            if (a.Type == Itemtype.Lock)
            {
                Console.WriteLine(a.Text);
            }

        }

        public void Move()
        {
            Character a = this;
            if (a == People.Player)
            {
                Console.WriteLine("Bitte (n)Norden, (e)Osten, (w)Westen oder (s)Süden oder eingeben (b)zurück");
                String direction = Console.ReadLine();
                this.ChangeRoom(direction);
            }
            else
            {
                Random _random = new Random();

                int num = _random.Next(0, 3);
                switch (num)
                {
                    case (0):

                        this.ChangeRoom("n");

                        break;
                    case (1):

                        this.ChangeRoom("e");

                        break;
                    case (2):

                        this.ChangeRoom("w");

                        break;
                    case (3):

                        this.ChangeRoom("s");

                        break;
                }
            }
        }
        public void ChangeRoom(String dir)
        {

            if (dir == "n" || dir == "e" || dir == "w" || dir == "s"||dir == "b")
            {
                if (this == People.Player)
                {
                    switch (dir)
                    {
                        case "n":
                            if (this.InRoom.North != null)
                            {
                                if (InRoom.IsNorthDoorClose == null)
                                {                                    
                                    this.InRoom = InRoom.North;                                   
                                }
                                else
                                {
                                    if (InRoom.IsNorthDoorClose.Locked == true)
                                    {
                                        if ((InRoom.IsNorthDoorClose == Map.SilverDoor && this.Inventory.Contains(Items.SilverKey)) || InRoom.IsNorthDoorClose == Map.GoldDoor && this.Inventory.Contains(Items.GoldKey))
                                        {
                                            Console.WriteLine("Du benutzt einen Schlüssel um die Tür zu Öffnen");
                                            
                                            this.InRoom = InRoom.North;                                            
                                        }
                                        else
                                        {                                          
                                            Console.WriteLine("Die Tür Ist Verschlossen, mit einem " + InRoom.IsNorthDoorClose.Text);
                                            Move();

                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Der Raum ist nicht if Verfügbar");
                            }
                            break;

                        case "e":
                            if (this.InRoom != null)
                            {
                                if (InRoom.IsEastDoorClose == null)
                                {                                    
                                    this.InRoom = InRoom.East;                                    
                                }
                                else
                                {
                                    if (InRoom.IsEastDoorClose.Locked == true)
                                    {
                                        if ((InRoom.IsEastDoorClose == Map.SilverDoor && this.Inventory.Contains(Items.SilverKey)) || InRoom.IsEastDoorClose == Map.GoldDoor && this.Inventory.Contains(Items.GoldKey))
                                        {
                                            Console.WriteLine("Du benutzt einen Schlüssel um die Tür zu Öffnen");
                                            
                                            this.InRoom = InRoom.East;
                                            
                                        }
                                        else
                                        {
                                            Console.WriteLine("Die Tür Ist Verschlossen, mit einem " + InRoom.IsEastDoorClose.Text);
                                            Move();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Der Raum ist nicht if Verfügbar");
                                Move();
                            }
                            break;

                        case "w":
                            if (this.InRoom.West != null)
                            {
                                if (InRoom.IsWestDoorClose == null)
                                {
                                    
                                    this.InRoom = InRoom.West;
                                   
                                }
                                else
                                {
                                    if (InRoom.IsWestDoorClose.Locked == true)
                                    {
                                        if ((InRoom.IsWestDoorClose == Map.SilverDoor && this.Inventory.Contains(Items.SilverKey)) || InRoom.IsWestDoorClose == Map.GoldDoor && this.Inventory.Contains(Items.GoldKey))
                                        {
                                            Console.WriteLine("Du benutzt einen Schlüssel um die Tür zu Öffnen");
                                            
                                            this.InRoom = InRoom.West;
                                            
                                        }
                                        else
                                        {

                                            
                                            Console.WriteLine("Die Tür Ist Verschlossen, mit einem " + InRoom.IsWestDoorClose.Text);
                                            Move();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Der Raum ist nicht if Verfügbar");
                                Move();
                            }
                            break;

                        case "s":
                            if (this.InRoom.South != null)
                            {
                                if (InRoom.IsSouthDoorClose == null)
                                {
                                    
                                    this.InRoom = InRoom.South;
                                    
                                }
                                else
                                {
                                    if (InRoom.IsSouthDoorClose.Locked == true)
                                    {
                                        if ((InRoom.IsSouthDoorClose == Map.SilverDoor && this.Inventory.Contains(Items.SilverKey)) || InRoom.IsSouthDoorClose == Map.GoldDoor && this.Inventory.Contains(Items.GoldKey))
                                        {

                                            Console.WriteLine("Du benutzt einen Schlüssel um die Tür zu Öffnen");
                                            
                                            this.InRoom = InRoom.South;
                                            
                                        }
                                        else
                                        {
                                            Console.WriteLine("Die Tür Ist Verschlossen, mit einem " + InRoom.IsSouthDoorClose.Text);
                                            Move();
                                        }
                                    }
                                }
                            }
                            else
                            {

                                Console.WriteLine("Der Raum ist nicht if Verfügbar");
                                Move();
                            }
                            break;
                        case "b":
                            break;
                    }
                }
                else
                {
                    try
                    {
                        switch (dir)
                        {
                            case "n":
                                if (this.InRoom != null)
                                {
                                    this.InRoom = this.InRoom.North;
                                }
                                
                                break;
                            case "e":
                                if (this.InRoom != null)
                                {
                                    this.InRoom = this.InRoom.East;
                                }
                                
                                break;
                            case "w":
                                if (this.InRoom != null)
                                {
                                    this.InRoom = this.InRoom.West;
                                }
                                
                                break;
                            case "s":
                                if (this.InRoom != null)
                                {
                                    this.InRoom = this.InRoom.South;
                                }
                                
                                break;
                        }
                    }
                    catch
                    {

                    }
                }
            }
            else
            {
                Console.WriteLine(dir + "ist keine Richtung");
                Move();
            }
        }

        
    }
}