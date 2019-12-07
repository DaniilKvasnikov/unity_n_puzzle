using SimpleJSON;
using System;

[Serializable]
public class Map
{
	public int map_size;
	public int map_count;
	public string[,,] map;

	public Map(string savedData)
	{
		Load(savedData);
	}

	private int Load(string savedData)
	{
		var N = JSON.Parse(savedData);
		if (N["map_size"] != null)
			map_size = N["map_size"].AsInt;
		else
			return ErrorMap();
		if (N["map_count"] != null)
			map_count = N["map_count"].AsInt;
		else
			return ErrorMap();
		map = new string[map_count, map_size, map_size];
		for (int i = 0; i < map_count; i++)
		{
			for (int j = 0; j < map_size; j++)
			{
				for (int k = 0; k < map_size; k++)
				{
					if (N["map"][i][j][k] != null)
						map[i, j, k] = N["map"][i][j][k].Value;
					else
						return ErrorMap();
				}
			}
		}
		return (0);
	}

	private int ErrorMap()
	{
		map_size = 0;
		map_count = 0;
		return (1);
	}
}
