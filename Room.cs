using System.Collections.Generic;

namespace DungeonExplorer
{
    /// <summary>
    /// room object in the game
    /// </summary>
    public class Room
    {
        private string roomType;
        private List<string> items;
        private List<string> monsters;

        /// <summary>
        /// initialize entities in the room
        /// </summary>
        /// <param name="roomType">The type of room, eg normal/trasure</param>
        /// /// <param name="items">List of items in the room</param>
        /// /// <param name="monsters">List of monsters in the room</param>
        public Room(string roomType, List<string> items, List<string> monsters)
        {
            this.roomType = roomType;
            this.items = items;
            this.monsters = monsters;
        }
        public List<string> GetItems()
        {
            return items;
        }
        public bool DeleteItem(string item)
        {
            return items.Remove(item);
        }
        public string ItemsContents()
        {
            return string.Join(", ", items);
        }
        public string MonstersContents()
        {
            return string.Join(", ", monsters);
        }

        /// <summary>
        /// adds all entities names into a string to print
        /// </summary>
        public string GetDescription()
        {
            string roomText = "This is a " + roomType + " Room.";
            if (items.Count != 0)
            {
                roomText += "\nContains items:" + ItemsContents();
            }
            if (monsters.Count != 0)
            {
                roomText += "\nContains monsters:" + MonstersContents();
            }
            return roomText;
        }
    }
}