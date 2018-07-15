using System;
using System.Collections.Generic;
using RPG_Items;
using RPG_Classes;
using RPG_Maps;
using RPG_Character;

namespace RPG_People
{
    public class People
    {
        public static void InitPeople()
        {
            YourMama = new Character
            {
                Name = "Deine Mutter",
                Level = 4,
                Life = 50,
                Magic = 10000,
                Atk = 8,
                Def = 3,
                Dress = new Item[] { Items.Cloths, Items.Fists },

                Text = "Deine dicke Mutter, Sie ist Sauer",
                GLoot = 250
            };

            // Characters 
            King = new Character
            {
                Name = "König Dickbutt",
                Level = 10,
                Life = 150,
                Magic = 10000,
                Atk = 2000,
                Def = -5,
                Dress = new Item[] { Items.Cloths, Items.Fists },

                Text = " Hallo  ich bin König Dickbutt Töte das Monster Aus der Toilette und bringe den Schatz ich bin zu besoffen dafür",
                GLoot = 250000
            };

            Consuela = new Character
            {
                Name = "Consuela",
                Level = 1,
                Life = 15,
                Magic = 10,
                Atk = 2,
                Def = -6,
                Exp = 2,
                Dress = new Item[] { Items.Cloths, Items.Mob },

                Battlecall = "Lemonen Reiniger",
                Text = " Hey ICH hatte gerade hier frisch gewischt",
                GLoot = 30
            };

            Player = new Character
            {
                Name = "",
                Level = 1,
                Life = 25,
                MaxLife = 25,
                Magic = 25,
                MagicAtk = 5,
                MaxMagic = 25,
                Atk = 5,
                Def = 0,
                Exp = 1,
                Inventory = new List<Item>(),
                Dress = new Item[] { Items.Cloths, Items.Fists },

                GLoot = 25,
            };
            Player.Inventory.Add(Items.Healpotion);
            

        }
        // Characters 
        public static Character King;

        public static Character Consuela;

        public static Character Player;

        public static Character YourMama;



    }
}