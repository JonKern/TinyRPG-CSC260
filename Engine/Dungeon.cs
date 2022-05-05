using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Dungeon
    {
        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Enemy> Enemies = new List<Enemy>();
        public static readonly List<Quest> Quests = new List<Quest>();
        public static readonly List<DungeonRooms> Rooms = new List<DungeonRooms>();

        // 1XX ints for weapons
        public const int ITEM_ID_TRUSTY_DAGGER = 101;
        public const int ITEM_ID_DARK_SCIMITAR = 102;
        public const int ITEM_ID_CODERS_KEYBOARD = 103;

        // 2XX ints for healing/status changing items
        public const int ITEM_ID_HEALING_POTION = 201;

        // 3XX ints for monster drops
        public const int ITEM_ID_UNDEAD_SKULL = 301;
        public const int ITEM_ID_SKELETAL_FINGER = 302;
        public const int ITEM_ID_GUARD_EMBLEM = 303;
        public const int ITEM_ID_BROKEN_SWORD = 304;
        public const int ITEM_ID_TWINKLING_GEM = 305;
        public const int ITEM_ID_WIZARD_HAT = 306;
        public const int ITEM_ID_POCKET_CALCULATOR = 307;
        public const int ITEM_ID_ASCII_CHART = 308;
        public const int ITEM_ID_PROGRAMMER_TEAR = 309;
        public const int ITEM_ID_COMPLETED_PROJECT = 310;

        // 4XX ints for quest rewards
        public const int ITEM_ID_RUBY_KEY = 401;
        public const int ITEM_ID_OBSIDIAN_KEY = 402;

        // 5XX ints for enemies
        public const int ENEMY_ID_SKELETON = 501;
        public const int ENEMY_ID_GUARD = 502;
        public const int ENEMY_ID_WIZARD = 503;
        public const int ENEMY_ID_SAD_CODER = 504;
        public const int ENEMY_ID_BOSS = 505;

        // 6XX ints for quests
        public const int QUEST_ID_DEFEAT_SKELETONS = 601;
        public const int QUEST_ID_DEFEAT_GUARDS = 602;
        public const int QUEST_ID_DEFEAT_WIZARDS = 603;
        public const int QUEST_ID_DEFEAT_CODER = 604;

        // 7XX ints for rooms
        public const int ROOM_ID_DUNGEON_ENTRANCE = 701;
        public const int ROOM_ID_SMALL_PRISON = 702;
        public const int ROOM_ID_DARK_ROOM = 703;
        public const int ROOM_ID_GATE = 704;
        public const int ROOM_ID_DINING_ROOM = 705;
        public const int ROOM_ID_STRANGE_HALLWAY = 706;
        public const int ROOM_ID_ALCHEMY_ROOM = 707;
        public const int ROOM_ID_MARBLE_HALLWAY = 708;
        public const int ROOM_ID_ARMORY = 709;
        public const int ROOM_ID_SECRET_PASSAGE = 710;
        public const int ROOM_ID_HIDDEN_PASSAGE = 711;
        public const int ROOM_ID_SUPER_SECRET_PASSAGE = 712;
        public const int ROOM_ID_CODERS_LAIR = 713;
        public const int ROOM_ID_GIANT_DOOR = 714;
        public const int ROOM_ID_BOSS_LAIR = 715;


        static Dungeon()
        {
            AddItems();
            AddEnemies();
            AddQuests();
            AddRooms();
        }

        private static void AddItems()
        {
            Items.Add(new Weapon(ITEM_ID_TRUSTY_DAGGER, "Trusty dagger", "Trusty daggers", 0, 5));
            Items.Add(new Weapon(ITEM_ID_DARK_SCIMITAR, "Dark scimitar", "Dark Scimitars", 3, 10));
            Items.Add(new Weapon(ITEM_ID_CODERS_KEYBOARD, "Coder's keyboard", "Coder's keyboards", 3000, 5000));

            Items.Add(new Item(ITEM_ID_UNDEAD_SKULL, "Undead skull", "Undead skulls"));
            Items.Add(new Item(ITEM_ID_SKELETAL_FINGER, "Skeletal finger", "Skeletal fingers"));
            Items.Add(new Item(ITEM_ID_GUARD_EMBLEM, "Guard emblem", "Guard emblems"));
            Items.Add(new Item(ITEM_ID_BROKEN_SWORD, "Broken sword", "Broken swords"));
            Items.Add(new Item(ITEM_ID_ASCII_CHART, "Ascii chart", "Ascii charts"));            
            Items.Add(new Item(ITEM_ID_PROGRAMMER_TEAR, "Programmer tear", "Programmer tears"));
            Items.Add(new Item(ITEM_ID_POCKET_CALCULATOR, "Pocket calculator", "pocket calculators"));
            Items.Add(new Item(ITEM_ID_COMPLETED_PROJECT, "Completed project", "Completed projects"));

            Items.Add(new HealingItem(ITEM_ID_HEALING_POTION, "Healing potion", "Healing potions", 5));            

            Items.Add(new Item(ITEM_ID_RUBY_KEY, "Ruby key", "Ruby keys"));
            Items.Add(new Item(ITEM_ID_OBSIDIAN_KEY, "Obsidian key", "Obsidian keys"));
        }

        private static void AddEnemies()
        {
            Enemy skeleton = new Enemy(ENEMY_ID_SKELETON, "Skeleton", 2, 5, 1, 3, 3);
            skeleton.LootTable.Add(new LootItem(ItemByID(ITEM_ID_UNDEAD_SKULL), 75, false));
            skeleton.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SKELETAL_FINGER), 75, true));
            skeleton.LootTable.Add(new LootItem(ItemByID(ITEM_ID_HEALING_POTION), 25, false));

            Enemy guard = new Enemy(ENEMY_ID_GUARD, "Guard", 4, 3, 5, 5, 5);            
            guard.LootTable.Add(new LootItem(ItemByID(ITEM_ID_DARK_SCIMITAR), 25, false));
            guard.LootTable.Add(new LootItem(ItemByID(ITEM_ID_GUARD_EMBLEM), 75, true));
            //guard.LootTable.Add(new LootItem(ItemByID(ITEM_ID_BROKEN_SWORD), 75, false));            

            Enemy wizard = new Enemy(ENEMY_ID_WIZARD, "Wizard", 2, 5, 7, 20, 20);
            wizard.LootTable.Add(new LootItem(ItemByID(ITEM_ID_TWINKLING_GEM), 50, false));
            wizard.LootTable.Add(new LootItem(ItemByID(ITEM_ID_WIZARD_HAT), 50, true));

            Enemy sadCoder = new Enemy(ENEMY_ID_SAD_CODER, "Sad Coder", 1, 1, 1, 1, 1);
            //sadCoder.LootTable.Add(new LootItem(ItemByID(ITEM_ID_ASCII_CHART), 25, false));
            sadCoder.LootTable.Add(new LootItem(ItemByID(ITEM_ID_CODERS_KEYBOARD), 50, false));
            // sadCoder.LootTable.Add(new LootItem(ItemByID(ITEM_ID_POCKET_CALCULATOR), 25, true));            

            Enemy boss = new Enemy(ENEMY_ID_BOSS, "BOSS", 50000, 100, 100, 300, 300);
            boss.LootTable.Add(new LootItem(ItemByID(ITEM_ID_PROGRAMMER_TEAR), 25, false));
            boss.LootTable.Add(new LootItem(ItemByID(ITEM_ID_COMPLETED_PROJECT), 100, true));

            Enemies.Add(skeleton);
            Enemies.Add(guard);
            Enemies.Add(wizard);
            Enemies.Add(sadCoder);
            Enemies.Add(boss);
        }

        private static void AddQuests()
        {
            Quest defeatSkeletons =
                new Quest(
                    QUEST_ID_DEFEAT_SKELETONS,
                    "Defeat undead skeletons",
                    "Kill skeletons in the Small Prison until you have 3 skulls. You will receive 5 gold " +
                    "and a key to unlock the next area.", 10, 5);

            defeatSkeletons.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_UNDEAD_SKULL), 3));

            defeatSkeletons.RewardItem = ItemByID(ITEM_ID_RUBY_KEY);

            Quest defeatGuards =
                new Quest(
                    QUEST_ID_DEFEAT_GUARDS,
                    "Defeat the guards",
                    "Fight guards in the Armory until you have 5 Guard Emblems. You will receive " +
                    "20 gold and a key to unlock the next area.", 20, 20);

            defeatGuards.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_GUARD_EMBLEM), 5));

            defeatGuards.RewardItem = ItemByID(ITEM_ID_OBSIDIAN_KEY);

            Quest defeatWizards =
                 new Quest(
                     QUEST_ID_DEFEAT_WIZARDS,
                     "Defeat the wizards",
                     "Fight wizards in the Alchemy Room until you have 7 Twinkling Gems. You will receive " +
                     "50 gold and a healing potion.", 35, 50);

            defeatWizards.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_TWINKLING_GEM), 7));

            defeatWizards.RewardItem = ItemByID(ITEM_ID_HEALING_POTION);


            Quests.Add(defeatSkeletons);
            Quests.Add(defeatGuards);
            Quests.Add(defeatWizards);
        }

        private static void AddRooms()
        {
            // Create each room
            DungeonRooms dungeonEntrance = new DungeonRooms(ROOM_ID_DUNGEON_ENTRANCE, "Dungeon Entrance",
                "A black door stands before you. Terrible sounds can be heard inside.");

            DungeonRooms darkRoom = new DungeonRooms(ROOM_ID_DARK_ROOM, "Dark Room", 
                "Though the room is dark, you some light emitting from a gate in the distance." +
                "The ground is wet with some dark liquid...");
            darkRoom.QuestAvailableInRoom = QuestByID(QUEST_ID_DEFEAT_SKELETONS);

            DungeonRooms smallPrison = new DungeonRooms(ROOM_ID_SMALL_PRISON, "Small Prison", "A cramped room with jail cells. Are those skeletons?!");
            smallPrison.EnemyInRoom = EnemyByID(ENEMY_ID_SKELETON); 

            DungeonRooms gate = new DungeonRooms(ROOM_ID_GATE, "Gate", "You unlock the gate with the ruby key.", ItemByID(ITEM_ID_RUBY_KEY));

            DungeonRooms diningRoom = new DungeonRooms(ROOM_ID_DINING_ROOM, "Dining Room", "Surprisingly, you find a luxurious dining room. " +
                " An ornate crystal chandelier hangs above. You see a strange painting at the end of the room...");
            
            DungeonRooms strangeHallway = new DungeonRooms(ROOM_ID_STRANGE_HALLWAY, "Strange Hallway", "A green hallway with tattered books on shelves.");
            
            DungeonRooms alchemyRoom = new DungeonRooms(ROOM_ID_ALCHEMY_ROOM, "Alchemy Room", "Bubbling cauldrons and flashing lights fill this room. ");
            

            DungeonRooms marbleHallway = new DungeonRooms(ROOM_ID_MARBLE_HALLWAY, "Marble Hallway", "A sleak stone hallway leading to a metal door.");
            marbleHallway.QuestAvailableInRoom = QuestByID(QUEST_ID_DEFEAT_GUARDS);

            DungeonRooms armory = new DungeonRooms(ROOM_ID_ARMORY, "Armory", "Cruel looking swords and axes line the walls of the room." +
                " You see several guards with strangely blank eyes grab their weapons.");
            armory.EnemyInRoom = EnemyByID(ENEMY_ID_GUARD);

            DungeonRooms secretPassage = new DungeonRooms(ROOM_ID_SECRET_PASSAGE, "Secret Passage", "Behind the painting you find a dark pathway.");

            DungeonRooms hiddenPassage = new DungeonRooms(ROOM_ID_HIDDEN_PASSAGE, "Hidden Passage", "There's another secret nearby?");

            DungeonRooms superSecretPassage = new DungeonRooms(ROOM_ID_SUPER_SECRET_PASSAGE, "Super Secret Passage", "Where could this lead to...?!");

            DungeonRooms codersLair = new DungeonRooms(ROOM_ID_CODERS_LAIR, "Coder's Lair", "A sad looking programmer is curled up in the corner. " +
                "You can hear them whispering \"Real programmers only use Vim.\" Put them out of their misery.");
            codersLair.EnemyInRoom = EnemyByID(ENEMY_ID_SAD_CODER);

            DungeonRooms giantDoor = new DungeonRooms(ROOM_ID_GIANT_DOOR, "Giant Door", "An ominously large door stands before you." +
                " The sounds you heard at the dungeon entrance grow louder...", ItemByID(ITEM_ID_OBSIDIAN_KEY));
            

            DungeonRooms bossLair = new DungeonRooms(ROOM_ID_BOSS_LAIR, "Boss Lair", "A giant monster made of hundreds of lines of code and a dozen classes" +
                " sits on an obsidian throne. Time to slay it!");
            bossLair.EnemyInRoom = EnemyByID(ENEMY_ID_BOSS);


            // Connect the rooms
            dungeonEntrance.RoomForward = darkRoom;

            darkRoom.RoomForward = gate;
            darkRoom.RoomBack = dungeonEntrance;
            darkRoom.RoomRight = smallPrison;

            smallPrison.RoomLeft = darkRoom;

            gate.RoomForward = diningRoom;
            gate.RoomBack = darkRoom;
            
            diningRoom.RoomForward = secretPassage;
            diningRoom.RoomBack = gate;
            diningRoom.RoomLeft = marbleHallway;
            diningRoom.RoomRight = strangeHallway;

            strangeHallway.RoomLeft = diningRoom;
            strangeHallway.RoomRight = alchemyRoom;

            alchemyRoom.RoomLeft = strangeHallway;

            marbleHallway.RoomLeft = armory;
            marbleHallway.RoomRight = diningRoom;
            
            armory.RoomRight = marbleHallway;

            secretPassage.RoomForward = giantDoor;
            secretPassage.RoomBack = diningRoom; 

            giantDoor.RoomForward = bossLair;
            giantDoor.RoomBack = secretPassage;
            giantDoor.RoomRight = hiddenPassage;

            hiddenPassage.RoomLeft = secretPassage;
            hiddenPassage.RoomRight = superSecretPassage;

            superSecretPassage.RoomLeft = hiddenPassage;
            superSecretPassage.RoomRight = codersLair;

            codersLair.RoomLeft = superSecretPassage;

            // Note: Didn't link the boss lair so that you are forced to fight it once you enter. No escape!

            // Add the rooms to the Rooms list
            Rooms.Add(dungeonEntrance);
            Rooms.Add(darkRoom);
            Rooms.Add(smallPrison);            
            Rooms.Add(gate);
            Rooms.Add(diningRoom);
            Rooms.Add(strangeHallway);
            Rooms.Add(alchemyRoom);
            Rooms.Add(marbleHallway);
            Rooms.Add(armory);
            Rooms.Add(secretPassage);
            Rooms.Add(giantDoor);
            Rooms.Add(bossLair);
        }

        public static Item ItemByID(int id)
        {
            foreach (Item item in Items)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }

            return null;
        }

        public static Enemy EnemyByID(int id)
        {
            foreach (Enemy enemy in Enemies)
            {
                if (enemy.ID == id)
                {
                    return enemy;
                }
            }

            return null;
        }

        public static Quest QuestByID(int id)
        {
            foreach (Quest quest in Quests)
            {
                if (quest.ID == id)
                {
                    return quest;
                }
            }

            return null;
        }

        public static DungeonRooms RoomByID(int id)
        {
            foreach (DungeonRooms room in Rooms)
            {
                if (room.ID == id)
                {
                    return room;
                }
            }
            return null;
        }
    }
}
