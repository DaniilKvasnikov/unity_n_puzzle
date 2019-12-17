using UnityEngine;

namespace n_puzzle.Scripts.Web
{
    public class WebController : MonoBehaviour
    {
        public GetMapJson getMapJson;
        
        private string url;
        public void Connect(string newUrl)
        {
            url = newUrl;
            Debug.Log("Connect to " + url);
            getMapJson.UpdateMap(url);
        }
    }
}
