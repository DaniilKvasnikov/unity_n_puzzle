using System;
using System.IO;
using n_puzzle.Scripts.Puzzle;
using n_puzzle.Scripts.Web;
using UnityEngine;

namespace n_puzzle.Scripts.State
{
    public class PuzzleState : global::State
    {
        public PuzzleView view;
        public RespawnBlock respawn;
        public GetMapJson getMapJson;
        
        private int currStep;

        private void Awake()
        {
            view.Prev += PrevStep;
            view.Next += NextStep;
            view.MapUpdate += MapUpdate;
        }

        private void MapUpdate()
        {
            view.SetStep(currStep = 0);
        }

        public void OnGetFilesList(string[] files)
        {
            foreach (var file in files)
                view.AddFile(file);
            if (files.Length > 0)
                getMapJson.UpdateMap(Path.Combine(WebController.URL, "get", files[0]));
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
