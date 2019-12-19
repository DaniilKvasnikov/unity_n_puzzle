using System;
using UnityEngine;

namespace n_puzzle.Scripts.Web
{
    public class WebController : MonoBehaviour
    {
        public GetMapJson getMapJson;
        public event Action<string> EndConnect;
        
        public static string URL;
        public void Connect(string newUrl)
        {
            URL = newUrl;
            Debug.Log("Connect to " + URL);
            getMapJson.UpdateMap(URL);
        }

        public virtual void OnEndConnect(string url)
        {
            EndConnect?.Invoke(url);
        }
    }
}
