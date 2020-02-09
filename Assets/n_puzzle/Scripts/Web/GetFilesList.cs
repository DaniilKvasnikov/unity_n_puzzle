using System;
using System.Collections.Generic;
using BestHTTP;
using n_puzzle.Scripts.State;
using SimpleJSON;
using UnityEngine;

namespace n_puzzle.Scripts.Web
{
    public class GetFilesList : MonoBehaviour
    {
        public PuzzleState puzzleState;
        private void Awake()
        {
            OnGetFilesList += puzzleState.OnGetFilesList;
        }

        public event Action<string[]> OnGetFilesList;
    
        public void UpdateMap(string url)
        {
            Uri uriResult;

            bool correctURL = Uri.TryCreate(url, UriKind.Absolute, out uriResult) 
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            if (!correctURL)
            {
                Debug.Log("Incorrect url");
                return;
            }
            HTTPRequest request = new HTTPRequest(uriResult, OnRequestFinished);
            request.Send();
        }

        private void OnRequestFinished(HTTPRequest request, HTTPResponse response)
        {
            switch (request.State)
            {
                case HTTPRequestStates.Finished:
                    Debug.Log("HTTPRequestStates.Finished");
                    string json = response.DataAsText;
                    JSONNode jsonRes = JSON.Parse(json);
                    List<string> files = new List<string>();
                    for (int i = 0; i < jsonRes.Count; i++)
                        files.Add(jsonRes[i]);
                    Debug.Log("files.size=" + files.Count);
                    if (files.Count == 0)
                    {
                        Debug.Log("Files not found");
                        return;
                    }
                    OnGetFilesList?.Invoke(files.ToArray());
                    break;

                case HTTPRequestStates.Error:
                    Debug.Log("Request Finished with Error! " + (request.Exception != null ? (request.Exception.Message + "\n" + request.Exception.StackTrace) : "No Exception"));
                    break;
                    
                case HTTPRequestStates.Aborted:
                    Debug.Log("Request Aborted!");
                    break;

                case HTTPRequestStates.ConnectionTimedOut:
                    Debug.Log("Connection Timed Out!");
                    break;

                case HTTPRequestStates.TimedOut:
                    Debug.Log("Processing the request Timed Out!");
                    break;
            }
        }
    }
}
