namespace IntelligentVacuum.Client
{
    using System;
    using Environments;

    public class Gamification
    {
        public Gamification()
        {
            
        }
        public int TotalScore { get; set; }
        public int NumberOfTurns { get; set; }

        public int KeepScore(AgentAction action, ActionResult actionResult, AreaMap map)
        {
            var CurrentActionCost = GetCurrentActionCost(action);
            if(!actionResult.ActionSuccess)
            {
                CurrentActionCost += 15;
            }
            TotalScore += CurrentActionCost;
            foreach(Room room in map.Rooms)
            {
                if(room.IsDirty)
                {
                    TotalScore += 1;
                }
            }
            return CurrentActionCost;
        }

        public int GetCurrentActionCost(AgentAction actions)
        {
            int actionCost = 0;
            switch (actions)
            {
                case AgentAction.MOVE_UP:
                    actionCost = 5;
                    break;
                case AgentAction.MOVE_DOWN:
                    actionCost = 5;
                    break;
                case AgentAction.MOVE_LEFT:
                    actionCost = 5;
                    break;
                case AgentAction.MOVE_RIGHT:
                    actionCost = 5;
                    break;
                case AgentAction.CLEAN:
                    actionCost = -10;
                    break;
                case AgentAction.LOOK_UP:
                    actionCost = 3;
                    break;
                case AgentAction.LOOK_DOWN:
                    actionCost = 3;
                    break;
                case AgentAction.LOOK_RIGHT:
                    actionCost = 3;
                    break;
                case AgentAction.LOOK_LEFT:
                    actionCost = 3;
                    break;
                case AgentAction.NONE:
                    actionCost = 0;
                    break;
                default:
                    actionCost = 15;
                    break;
            }
            return actionCost;
        }
        public int GetFinalScore(int x, int y, int rounds)
        {
            return TotalScore = (TotalScore/(x*y*3));
        }
    }
}