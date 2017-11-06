namespace IntelligentVacuum.Agent
{
    using System;
    using System.Collections.Generic;
    using Environments;

    public class Agent
    {
        public Agent()
        {
        }

        int prevX = -1;                                             // Variables to remember coordinates of previous rooms
        int prevY = -1;                                             //      This allows the vacuum to see if it bumped into a wall
        int roomWidth = -1;                                         // Variable to remember where it was when it bumped into a wall
        bool left = false;                                          // Variable to toggle sweeping direction from right to left

        public AgentAction DecideAction(Room room)
        {
            AgentAction action = AgentAction.NONE;

            if(room.IsDirty){                                       // If the room needs to be cleaned
                action = AgentAction.CLEAN;                         //      Action = Clean
            }
            else{
                if(prevX == room.XAxis && prevY == room.YAxis && roomWidth < 1){
                                                                    // If the vacuum bumped into a wall for the first time
                    roomWidth = room.XAxis;                         //      Record the room width
                    left = !left;                                   //      Toggle sweep direction
                    action = AgentAction.MOVE_DOWN;                 //      Action = Move Down
                }
                else{                                               // If the vacuum has moved from its previous attempt
                    if(left){                                       //      If the vacuum is moving left
                        action = AgentAction.MOVE_LEFT;             //          Action = Move Left
                    }
                    else{                                           //      If the vacuum is moving right
                        action = AgentAction.MOVE_RIGHT;            //          Action = Move Right
                    }
                    if(roomWidth > 0 && ((0 == room.XAxis && prevX != room.XAxis) || (roomWidth == room.XAxis && prevX != room.XAxis))){
                                                                    //      If the vacuum is on the side of the room
                        left = !left;                               //          Toggle sweep direction
                        action = AgentAction.MOVE_DOWN;             //          Action = Move Down
                    }
                }
                        prevX = room.XAxis;                         // Record the previous X coordinate to memory
                        prevY = room.YAxis;                         // Record the previous Y coordinate to memory
            }
            return action;                                          // Return finalized action
        }
    }
}