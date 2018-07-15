using System;
using System.Collections.Generic;

using RPG_Items;
using RPG_People;
using RPG_Maps;
using RPG_Character;


namespace RPG_Classes
{
    public enum Itemtype
    {
        Heal, MagicHeal, Armor, Weapon, Key, Lock
    }

    public class Item
    {
        public String Name;
        public Itemtype Type;
        public int Bonus;
        public String Text;
    }

    public class Door
    {
        public Boolean Locked;
        public Itemtype Lock;
        public String Text;
    }

    public class Room
    {
        public String Name ;
        public List<Item> Inventory;
        public List<Character> Characters;
        public String Name_Print;

        public Room North;
        public Room East;
        public Room West;
        public Room South;

        public Door IsNorthDoorClose;
        public Door IsEastDoorClose;
        public Door IsWestDoorClose;
        public Door IsSouthDoorClose;

        public String InfoText;

        public void ShowInfo()
        {
            Console.Write("" + this.InfoText);
        }

        public void AddToRoomCharacters(Character b)
        {
            Characters.Add(b);
        }

        public void ShowCharatersInRoom()
        {
            if (this.Characters.Count != 0)
            { 
               foreach(var i in this.Characters)
                {
                   Console.WriteLine(i.Name);
                }
                
               
            }
            else
            {
                Console.WriteLine("Es ist niemand im Raum");
            }
        }

        public void ShowInventoryInRoom()
        {
            if (this.Inventory.Count != 0)
            {
                Console.WriteLine("Im Raum ist");
                foreach(var i in this.Inventory)
                Console.WriteLine(i.Name);
            }
            else
            {
                Console.WriteLine("Es ist nichts im Raum");
            }
        }
        public void BossBattle()
        {

        }
    }
 
}
