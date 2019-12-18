using System;
using n_puzzle.Scripts.Puzzle;
using n_puzzle.Scripts.Web;
using UnityEngine;

namespace n_puzzle.Scripts.State
{
    public class PuzzleState : global::State
    {
        public PuzzleView view;
        public RespawnBlock respawn;
        
        private int currStep;

        private void Awake()
        {
            view.Prev += PrevStep;
            view.Next += NextStep;
        }
        
        public void NextStep()
        {
            if (currStep + 1 < respawn.map.map_count)
                currStep++;
            respawn.SetStep(currStep);
            view.SetStep(currStep);
        }

        public void PrevStep()
        {
            if (currStep - 1 >= 0)
                currStep--;
            respawn.SetStep(currStep);
            view.SetStep(currStep);
        }

    }
}
