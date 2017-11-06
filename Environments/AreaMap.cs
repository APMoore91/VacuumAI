namespace IntelligentVacuum.Environments
{
    using System;
    using System.Collections.Generic;

    public class AreaMap
    {

        public Room[,] Rooms;

        public Room AgentRoom;

        public AreaMap(int xSize, int ySize, float dirtProbability)
        {
            var rnd = new Random();
            this.Rooms = new Room[xSize, ySize];
            for (int x = 0; x < xSize; x++)
            {
                for (int y = 0; y < ySize; y++)
                {
                    Room room = new Room(x, y);
                    this.Rooms[x,y] = room;

                    if(rnd.Next(0, 100) < (int)(dirtProbability*100))
                    {
                        room.IsDirty = true;
                    }
                    else
                    {
                        // IsDirty is false
                    }
                }
            }
            AgentRoom = Rooms[0,0];
        }

        public int GetDirtCount()
        {
            int dirt = 0;
            for (int x = 0; x < this.Rooms.GetLength(0); x++)
            {
                for (int y = 0; y < this.Rooms.GetLength(1); y++)
                {
                    dirt += Convert.ToInt32(this.Rooms[x,y].IsDirty);
                }
            }
            return dirt;
        }
    }
}
