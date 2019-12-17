using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Get_Map_json : MonoBehaviour
{
	public string url = "http://96c945b1.eu.ngrok.io/";
	public static event Action<Map> Get_map;

	private Map map;

	private void Start()
	{
		UpdateMap();
	}

	public void UpdateMap()
	{
		StartCoroutine(GetRequest(url));
	}

	private IEnumerator GetRequest(string uri)
	{
		using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
		{
			yield return webRequest.SendWebRequest();

			if (!webRequest.isNetworkError)
			{
				string json = webRequest.downloadHandler.text;
				Map new_map = new Map(json);
				if (new_map.map_size != 0 && new_map.map_count != 0)
				{
					map = new_map;
					Debug.Log("map_size = " + map.map_size);
					Debug.Log("map_count = " + map.map_count);
					Get_map?.Invoke(map);
				}
				else
					Debug.Log("Map error\n" + json);
			}
		}
	}
}
