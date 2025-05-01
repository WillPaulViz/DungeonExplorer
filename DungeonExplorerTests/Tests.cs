using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;

namespace DungeonExplorer
{
    [TestClass]
    public class DungeonExplorerTest
    {
        private Game game;
        public Player player;

        [TestInitialize]
        public void Setup_Test()
        {
            player = new Player("Test", 100, 10);
            game = new Game(player, 5);
        }
        [TestMethod]
        public void RoomInitialized_Test()
        {
            foreach (Room room in game.MapRooms)
            {
                Assert.IsNotNull(room);
            }
        }
        [TestMethod]
        public void TakeDMG_Test()
        {
            player.TakeDMG(100);
            Assert.AreEqual(player.Health, 0);
        }

        [TestMethod]
        public void AddItem_Test()
        {
            int before = player.Inventory.Count;
            player.AddToInv(new Potion("a", 10));
            int after = player.Inventory.Count;
            Assert.AreEqual(before, after-1);
        }
        [TestMethod]
        public void DelItems_Test()
        {
            int before = player.Inventory.Count;
            player.DelFromInvIndex(0);
            int after = player.Inventory.Count;
            Assert.AreEqual(before, after+1);
        }

    }
}