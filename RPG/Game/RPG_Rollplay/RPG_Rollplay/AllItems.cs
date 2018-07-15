using System;
using System.Collections.Generic;

using RPG_Classes;


namespace RPG_Items
{
    public static class Items
    {
        public static void InitItems()
        {
            Showel = new Item
            {
                Name = "Klappsparten",
                Type = Itemtype.Weapon,
                Bonus = 7,
                Text = "Ein Klappsparten mit ziehmlich spitzen Kanten",
            };

            CanAmor = new Item
            {
                Name = "Pfanddosen Rüstung",
                Type = Itemtype.Armor,
                Bonus = 3,
                Text = "Eine Rüstung aus alten Pfanddosen",
            };

            Healpotion = new Item
            {
                Name = "Heilpulver",
                Type = Itemtype.Heal,
                Bonus = 15,
                Text = "Eine Mischung aus Schnaps, Ingver und den resten des Medizinschrank",
            };

            Energiepotion = new Item
            {
                Name = "Zauberheilpulver",
                Type = Itemtype.MagicHeal,
                Bonus = 15,
                Text = "Ein starker Geruch von Faulen Eiern, alten Socken und einem hauch von Zimt mit Zitronen Gras Geht von ihm aus",
            };

            Cloths = new Item
            {
                Name = "Einfache Kleidung",
                Type = Itemtype.Armor,
                Bonus = 0,
                Text = "Einfach Kleidung"
            };

            Fists = new Item
            {
                Name = "Fäuste",
                Type = Itemtype.Weapon,
                Bonus = 0,
                Text = "Fäuste"
            };

            Mob = new Item
            {
                Name = "Mob",
                Type = Itemtype.Weapon,
                Bonus = 2,
                Text = "Ein Mob"
            };

            SilverKey = new Item
            {
                Name = "Silber Schlüssel",
                Type = Itemtype.Key,
                Bonus = 1,
                Text = "Eine Silberner Schlüssel",
            };

            GoldKey = new Item
            {
                Name = "Goldener Schlüssel",
                Type = Itemtype.Key,
                Bonus = 2,
                Text = "Ein mit Goldpapier eingewickelter Silber Schlüssel",
            };

            Dust = new Item
            {
                Name = "Staub Fussel",
                Type = Itemtype.Heal,
                Bonus = 0,
                Text = "Ein Fussel, er sieht sehr Nett aus",
            };

            Galon = new Item
            {
                Name = "Der Schatz, Alkohol",
                Type = Itemtype.Heal,
                Bonus = -1500,
                Text = "14 Galoen von deiner Mudder gebranten schnaps, wer weiß was Sie da gemischt hat",
            };

        }
        public static Item Showel;

        public static  Item CanAmor;

        public static Item Healpotion;

        public static Item Energiepotion;

        public static Item Cloths;

        public static Item Fists;

        public static Item Mob;

        public static Item SilverKey;

        public static Item GoldKey;

        public static Item Dust;

        public static Item Galon;
    }
}