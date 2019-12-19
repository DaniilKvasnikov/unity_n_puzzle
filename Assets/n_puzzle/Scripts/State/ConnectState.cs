using System;
using System.IO;
using n_puzzle.Scripts.Puzzle;
using n_puzzle.Scripts.Web;
using UnityEngine;

namespace n_puzzle.Scripts.State
{
    public class ConnectState : global::State
    {
        public ConnectView view;
        public GetFilesList getFilesList;

        public string filesURL = "files";

        private void Awake()
        {
            view.Connect += Connect;
            GetMapJson.GetMap += GetMap;
        }

        private void GetMap(Map obj)
        {
            stateSwitcher.SwitchState<PuzzleState>();
        }

        private void Connect(string url)
        {
            WebController.URL = url;
            getFilesList.UpdateMap(Path.Combine(WebController.URL, filesURL));
        }
    }
}
