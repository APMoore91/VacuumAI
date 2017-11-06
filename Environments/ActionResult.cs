namespace IntelligentVacuum.Environments
{
    using System;
    using System.Collections.Generic;

    public class ActionResult
    {
        public bool ActionSuccess { get; set; }
        public Room LookResultRoom { get; set; }
        public Room CurrentRoom { get; set; }
        public AgentAction CurrentAction { get; set; }

        public ActionResult(Room currentRoom)
        {
            this.CurrentRoom = currentRoom;
        }
    }
}