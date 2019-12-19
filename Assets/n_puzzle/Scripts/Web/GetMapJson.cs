using System;
using BestHTTP;
using n_puzzle.Scripts.Puzzle;
using UnityEngine;

namespace n_puzzle.Scripts.Web
{
	public class GetMapJson : MonoBehaviour
	{
		public WebController webController;
		
		public static event Action<Map> GetMap;
		private string URL;

		public void UpdateMap(string url)
		{
			URL = url;
			HTTPRequest request = new HTTPRequest(new Uri(url), OnRequestFinished);
			request.Send();
		}

		private void OnRequestFinished(HTTPRequest request, HTTPResponse response)
		{
			string json = response.DataAsText;
			Map newMap = new Map(json);
			if (newMap.map_size != 0 && newMap.map_count != 0)
			{
				Debug.Log("map_size = " + newMap.map_size);
				Debug.Log("map_count = " + newMap.map_count);
				GetMap?.Invoke(newMap);
				webController.OnEndConnect(URL);
			}
			else
				Debug.LogError("Map error\n" + json);
		}
	}
}
