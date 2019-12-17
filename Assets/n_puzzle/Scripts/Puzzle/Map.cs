using System;
using SimpleJSON;
using UnityEngine;

namespace n_puzzle.Scripts.Puzzle
{
	[Serializable]
	public class Map
	{
		public int map_size;
		public int map_count;
		public string[,,] map;

		public Map(string json)
		{
			Load(json);
		}

		private int Load(string json)
		{
			JSONNode jsonRes = JSON.Parse(json);
			if (jsonRes["map_size"] != null)
				map_size = jsonRes["map_size"].AsInt;
			else
				return ErrorMap("map_size");
			if (jsonRes["map_count"] != null)
				map_count = jsonRes["map_count"].AsInt;
			else
				return ErrorMap("map_count");
			map = new string[map_count, map_size, map_size];
			for (int i = 0; i < map_count; i++)
			{
				for (int j = 0; j < map_size; j++)
				{
					for (int k = 0; k < map_size; k++)
					{
						if (jsonRes["map"][i][j][k] != null)
							map[i, j, k] = jsonRes["map"][i][j][k].Value;
						else
							return ErrorMap("element not found");
					}
				}
			}
			return (0);
		}

		private int ErrorMap(string error)
		{
			map_size = 0;
			map_count = 0;
			Debug.LogError("Error: " + error);
			return (1);
		}
	}
}
