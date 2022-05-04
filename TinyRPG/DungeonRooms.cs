using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class DungeonRooms
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Item ItemRequiredForEntry { get; set; }
        public Quest QuestAvailableInRoom { get; set; }
        public Enemy EnemyInRoom { get; set; }
        public DungeonRooms RoomForward { get; set; }
        public DungeonRooms RoomRight { get; set; }
        public DungeonRooms RoomBack { get; set; }
        public DungeonRooms RoomLeft { get; set; }

        public DungeonRooms(int id, string name, string description, 
            Item itemRequiredForEntry = null, Quest questAvailableInRoom = null, 
            Enemy monsterLivingHere = null)
        {
            ID = id;
            Name = name;
            Description = description;
            ItemRequiredForEntry = itemRequiredForEntry;
            QuestAvailableInRoom = questAvailableInRoom;
            EnemyInRoom = monsterLivingHere;
        }
    }
}
