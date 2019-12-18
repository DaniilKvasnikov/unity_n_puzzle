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
		public int[,,] map;

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
			map = new int[map_count, map_size, map_size];
			for (int step = 0; step < map_count; step++)
			{
				for (int j = 0; j < map_size; j++)
				{
					for (int k = 0; k < map_size; k++)
					{
						if (jsonRes["map"][step][j][k] != null)
						{
							if (!Int32.TryParse(jsonRes["map"][step][j][k].Value, out map[step, j, k]))
								return ErrorMap("element cannot convert to int");
						}
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
