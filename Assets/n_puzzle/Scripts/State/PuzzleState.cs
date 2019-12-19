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
        public GetFilesList getFilesList;
        public WebController webController;

        public string filesURL = "files";
        
        private int currStep;

        private void Awake()
        {
            view.Prev += PrevStep;
            view.Next += NextStep;
            getFilesList.OnGetFilesList += OnGetFilesList;
            webController.EndConnect += EndConnect;
        }

        private void EndConnect(string obj)
        {
            getFilesList.UpdateMap(Path.Combine(WebController.URL, filesURL));
        }

        private void OnGetFilesList(string[] files)
        {
            foreach (var file in files)
                view.AddFile(file);
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
