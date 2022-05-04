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
        public const int ITEM_ID_PIECE_OF_FUR = 302;
        public const int ITEM_ID_SNAKE_FANG = 303;
        public const int ITEM_ID_SNAKESKIN = 304; 
        public const int ITEM_ID_SPIDER_FANG = 305;
        public const int ITEM_ID_SPIDER_SILK = 306;

        // 4XX ints for quest rewards
        public const int ITEM_ID_RUBY_KEY = 401;
        public const int ITEM_ID_OBSIDIAN_KEY = 402;

        public const int ENEMY_ID_SKELETON = 1;
        public const int ENEMY_ID_GUARD = 2;
        public const int ENEMY_ID_BOSS = 3;

        public const int QUEST_ID_CLEAR_ALCHEMIST_GARDEN = 1;
        public const int QUEST_ID_CLEAR_FARMERS_FIELD = 2;

        public const int ROOM_ID_DUNGEON_ENTRANCE = 1;
        public const int ROOM_ID_SMALL_PRISON = 2;
        public const int ROOM_ID_DARK_ROOM = 3;
        public const int ROOM_ID_GATE = 4;
        public const int ROOM_ID_DINING_ROOM = 5;
        public const int ROOM_ID_STRANGE_HALLWAY = 6;
        public const int ROOM_ID_ALCHEMY_ROOM = 7;
        public const int ROOM_ID_MARBLE_HALLWAY = 8;
        public const int ROOM_ID_ARMORY = 9;
        public const int ROOM_ID_SECRET_PASSAGE = 10;
        public const int ROOM_ID_GIANT_DOOR = 11;
        public const int ROOM_ID_BOSS_LAIR = 12;


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

            Items.Add(new HealingItem(ITEM_ID_HEALING_POTION, "Healing potion", "Healing potions", 5));

            Items.Add(new Item(ITEM_ID_UNDEAD_SKULL, "Undead skull", "Undead skulls"));
            Items.Add(new Item(ITEM_ID_PIECE_OF_FUR, "Piece of fur", "Pieces of fur"));
            Items.Add(new Item(ITEM_ID_SNAKE_FANG, "Snake fang", "Snake fangs"));
            Items.Add(new Item(ITEM_ID_SNAKESKIN, "Snakeskin", "Snakeskins"));   
            Items.Add(new Item(ITEM_ID_SPIDER_FANG, "Spider fang", "Spider fangs"));
            Items.Add(new Item(ITEM_ID_SPIDER_SILK, "Spider silk", "Spider silks"));

            Items.Add(new Item(ITEM_ID_RUBY_KEY, "Ruby key", "Ruby keys"));
            Items.Add(new Item(ITEM_ID_OBSIDIAN_KEY, "Obsidian key", "Obsidian keys"));
        }

        private static void AddEnemies()
        {
            Enemy skeleton = new Enemy(ENEMY_ID_SKELETON, "Skeleton", 2, 3, 10, 3, 3);
            skeleton.LootTable.Add(new LootItem(ItemByID(ITEM_ID_UNDEAD_SKULL), 75, false));
            skeleton.LootTable.Add(new LootItem(ItemByID(ITEM_ID_PIECE_OF_FUR), 75, true));

            Enemy guard = new Enemy(ENEMY_ID_GUARD, "Guard", 5, 3, 10, 3, 3);
            guard.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SNAKE_FANG), 75, false));
            guard.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SNAKESKIN), 75, true));

            Enemy boss = new Enemy(ENEMY_ID_BOSS, "BOSS", 300, 100, 100, 300, 300);
            boss.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SPIDER_FANG), 75, true));
            boss.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SPIDER_SILK), 25, false));

            Enemies.Add(skeleton);
            Enemies.Add(guard);
            Enemies.Add(boss);
        }

        private static void AddQuests()
        {
            Quest defeatSkeletons =
                new Quest(
                    QUEST_ID_CLEAR_ALCHEMIST_GARDEN,
                    "Clear the alchemist's garden",
                    "Kill rats in the alchemist's garden and bring back 3 rat tails. You will receive a healing potion and 10 gold pieces.", 20, 10);

            defeatSkeletons.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_UNDEAD_SKULL), 3));

            defeatSkeletons.RewardItem = ItemByID(ITEM_ID_HEALING_POTION);

            Quest defeatGuards =
                new Quest(
                    QUEST_ID_CLEAR_FARMERS_FIELD,
                    "Clear the farmer's field",
                    "Kill snakes in the farmer's field and bring back 3 snake fangs. You will receive an adventurer's pass and 20 gold pieces.", 20, 20);

            defeatGuards.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_SNAKE_FANG), 3));

            defeatGuards.RewardItem = ItemByID(ITEM_ID_OBSIDIAN_KEY);

            Quests.Add(defeatSkeletons);
            Quests.Add(defeatGuards);
        }

        private static void AddRooms()
        {
            // Create each room
            DungeonRooms dungeonEntrance = new DungeonRooms(ROOM_ID_DUNGEON_ENTRANCE, "Dungeon Entrance",
                "A black door stands before you. Terrible sounds can be heard inside.");

            DungeonRooms darkRoom = new DungeonRooms(ROOM_ID_DARK_ROOM, "Dark Room", 
                "Though the room is dark, you some light emitting from a gate in the distance." +
                "The ground is wet with some dark liquid...");

            DungeonRooms smallPrison = new DungeonRooms(ROOM_ID_SMALL_PRISON, "Small Prison", "A cramped room with jail cells. Are those skeletons?!");
            smallPrison.EnemyInRoom = EnemyByID(ENEMY_ID_SKELETON);
            // change rat to skeleton


            DungeonRooms gate = new DungeonRooms(ROOM_ID_GATE, "Gate", "You unlock the gate with the ruby key.", ItemByID(ITEM_ID_OBSIDIAN_KEY));
            // add Ruby Key

            DungeonRooms diningRoom = new DungeonRooms(ROOM_ID_DINING_ROOM, "Dining Room", "Surprisingly, you find a luxurious dining room. " +
                " An ornate crystal chandelier hangs above. You see a strange painting at the end of the room...");
            diningRoom.QuestAvailableInRoom = QuestByID(QUEST_ID_CLEAR_ALCHEMIST_GARDEN);
            // add new quest

            DungeonRooms strangeHallway = new DungeonRooms(ROOM_ID_STRANGE_HALLWAY, "Strange Hallway", "A green hallway with tattered books on shelves.");
            strangeHallway.EnemyInRoom = EnemyByID(ENEMY_ID_SKELETON);

            DungeonRooms alchemyRoom = new DungeonRooms(ROOM_ID_ALCHEMY_ROOM, "Alchemy Room", "Bubbling cauldrons and flashing lights fill this room.");
            alchemyRoom.QuestAvailableInRoom = QuestByID(QUEST_ID_CLEAR_FARMERS_FIELD);
            // get a health potion here

            DungeonRooms marbleHallway = new DungeonRooms(ROOM_ID_MARBLE_HALLWAY, "Marble Hallway", "A sleak stone hallway leading to a metal door.");
            marbleHallway.EnemyInRoom = EnemyByID(ENEMY_ID_GUARD);            

            DungeonRooms armory = new DungeonRooms(ROOM_ID_ARMORY, "Armory", "Cruel looking swords and axes line the walls of the room." +
                " You see several guards with strangely blank eyes grab their weapons.");

            DungeonRooms secretPassage = new DungeonRooms(ROOM_ID_SECRET_PASSAGE, "Secret Passage", "Behind the painting you find a dark pathway.");
            secretPassage.EnemyInRoom = EnemyByID(ENEMY_ID_BOSS);

            DungeonRooms giantDoor = new DungeonRooms(ROOM_ID_GIANT_DOOR, "Giant Door", "An ominously large door stands before you." +
                " The sounds you hear at the dungeon entrance grow louder...", ItemByID(ITEM_ID_OBSIDIAN_KEY));
            // Need to add KEY

            DungeonRooms bossLair = new DungeonRooms(ROOM_ID_BOSS_LAIR, "Boss Lair", "A giant monster made of hundreds of lines of code and a dozen classes" +
                " sits on an obsidian throne. Time to slay it!");
            secretPassage.EnemyInRoom = EnemyByID(ENEMY_ID_BOSS);


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
