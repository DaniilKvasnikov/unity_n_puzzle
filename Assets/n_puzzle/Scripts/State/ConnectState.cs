using System;
using n_puzzle.Scripts.Puzzle;
using n_puzzle.Scripts.Web;
using UnityEngine;

namespace n_puzzle.Scripts.State
{
    public class ConnectState : global::State
    {
        public ConnectView view;
        public WebController webController;

        private void Awake()
        {
            view.Connect += Connect;
            GetMapJson.GetMap += GetMap;
        }

        private void GetMap(Map obj)
        {
            Debug.Log("Getting Map");
        }

        private void Connect(string url)
        {
            webController.Connect(url);
        }
    }
}
