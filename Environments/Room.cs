namespace IntelligentVacuum.Environments
{
    using System;
    public class Room
    {
        public int XAxis { get; set; }
        public int YAxis { get; set; }
        public bool IsDirty { get; set; }

        public Room(int x, int y)
        {
            this.XAxis = x;
            this.YAxis = y;
        }
    }
}