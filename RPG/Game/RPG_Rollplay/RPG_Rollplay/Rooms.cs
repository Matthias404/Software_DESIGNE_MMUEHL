using System;
using System.Collections.Generic;

using RPG_Items;
using RPG_People;
using RPG_Character;
using RPG_Classes;

namespace RPG_Maps
{
    public static class Map
    {
        public static void IntMap()
        {
            Foyer = new Room
            {
                Name = "Foyer",
                Name_Print = "im Foyer",
                InfoText = "Ein Großer Raum mit drei Türenen eine im Norden eine im Osten eine im Westen ",

                Characters = new List<Character>(),
                Inventory = new List<Item>(),

            };

            Libury = new Room
            {
                Name = "Bibliothek",
                Name_Print = "in der Bibliothek",
                InfoText = "Es ist gedämpftes Licht im Raum und die Bücher sind alle ziemlich unsortiert Von Junzt steht neben Hammlet",

                Characters = new List<Character>(),
                Inventory = new List<Item>(),
            };

            Toilet = new Room
            {
                Name = "Toilette",
                Name_Print = "in der Toilette",
                InfoText = "Eine Gemüdliche Toilette, es wäre hier sehr schön würde aus einer toilette nur nicht ein Starker geruch von Alkohol ausdampfen",

                Characters = new List<Character>(),
                Inventory = new List<Item>(),

            };

            Kitchen = new Room
            {
                Name = "Küche",
                Name_Print = "in der Küche",
                InfoText = "Eine Gnaz normale Küche, die etwas zu unordentlich ist und der Koch sien keine zeit zu haben alle Tiere zu töten Bevor er sie Kocht. ein paar schwammen noch Bellend im Topf",

                Characters = new List<Character>(),
                Inventory = new List<Item>(),

            };

            Hall = new Room
            {
                Name = "Esszimmer",
                Name_Print = "im Esszimmer",
                InfoText = "Das essen steht schon angerichtet auf dem Tisch es gibt als Vorspeise Tauben Auflauf mit Joghurt danach Schimmelpilze mit Seseam und zum nachtisch in einer kleinen schale sich bewegende dineg. Alles sieht sooo Lecker aus. ",

                Characters = new List<Character>(),
                Inventory = new List<Item>(),
            };

            Washroom = new Room
            {
                Name = "Waschküche",
                Name_Print = "in der Waschküche",
                InfoText = "Eine Große altmodische Waschmaschine Läuft in einer ecke still vor sich hin. Ein anderer großer Bottich steht in der ecke. Eine verwischter zetterl hängt daran: Nur zum Tierer ...tränken.  Consuela",

                Characters = new List<Character>(),
                Inventory = new List<Item>(),

            };

            Wintergarden = new Room
            {
                Name = "Wintergarten",
                Name_Print = "im Wintergarten",
                InfoText = "Ein schöner verglaster Raum mit blick auf einen Idylischen verstahlten Schrottplatz der mit durch die Radioaktivität gestorbenen Tier Kadavern gesäumt ist. Viele der Tiere haben neueGliedmaße oder Köpfe bekommen. Wie lustig sie aussehen.",

                Characters = new List<Character>(),
                Inventory = new List<Item>(),

            };

            GoldDoor = new Door
            {
                Locked = true,

                Text = ("Die Türe ist mit einem Goldenen Schloss Gesichert")
            };

            SilverDoor = new Door
            {
                Locked = true,

                Text = ("Die Türe ist mit einem Silbernen Schloss Gesichert")
            };

            // Init Foyer
            Foyer.North = Hall;
            Foyer.West = Libury;
            Foyer.East = Wintergarden;
            Foyer.Inventory.Clear();


            // Init Libury
            Libury.East = Foyer;
            Libury.Characters.Add(People.King);
            Libury.Inventory.Add(Items.CanAmor);

            // Init Toilet
            Toilet.South = Hall;
            Toilet.Inventory.Add(Items.Galon);
            

            // Init Kitchen
            Kitchen.South = Wintergarden;
            Kitchen.West = Hall;
            Kitchen.Inventory.Add(Items.SilverKey);
            
            //Init Hall
            Hall.North = Toilet;
            Hall.East = Kitchen;
            Hall.West = Washroom;
            Hall.South = Foyer;

            Hall.Inventory.Add(Items.Energiepotion);

            Hall.IsNorthDoorClose = GoldDoor;
            Hall.IsWestDoorClose = SilverDoor;

            //Init Washroom
            Washroom.East = Hall;

            Washroom.Inventory.Add(Items.GoldKey);

            // Init Wintergarten
            Wintergarden.North = Kitchen;
            Wintergarden.West = Foyer;

            Wintergarden.Inventory.Add(Items.Showel);


        }



        // Rooms
        public static Room Foyer;

        public static Room Libury;

        public static Room Toilet;

        public static Room Kitchen;

        public static Room Hall;

        public static Room Washroom;

        public static Room Wintergarden;

        public static Door GoldDoor;

        public static Door SilverDoor;
    }
}