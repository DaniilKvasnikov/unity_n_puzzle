using System;
using System.Collections.Generic;
using BestHTTP;
using SimpleJSON;
using UnityEngine;

namespace n_puzzle.Scripts.Web
{
    public class GetFilesList : MonoBehaviour
    {
        public event Action<string[]> OnGetFilesList;
    
        public void UpdateMap(string url)
        {
            HTTPRequest request = new HTTPRequest(new Uri(url), OnRequestFinished);
            request.Send();
        }

        private void OnRequestFinished(HTTPRequest request, HTTPResponse response)
        {
            string json = response.DataAsText;
            JSONNode jsonRes = JSON.Parse(json);
            List<string> files = new List<string>();
            for (int i = 0; i < jsonRes.Count; i++)
                files.Add(jsonRes[i]);
            OnGetFilesList?.Invoke(files.ToArray());
        }
    }
}
