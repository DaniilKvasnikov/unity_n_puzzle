using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBlock : MonoBehaviour
{
	public GameObject prefab;
	public float step = 0.15f;

	private List<Block> blocks = new List<Block>();

	private void Awake()
	{
		Get_Map_json.Get_map += Respawn_blocks;
	}

	private void Respawn_blocks(Map map)
	{
		Debug.Log("Respawn_blocks");
		while (blocks.Count > 0)
			Destroy(blocks[0].gameObject);
		for (int i = 0; i < map.map_size; i++)
		{
			for (int j = 0; j < map.map_size; j++)
			{
				GameObject cube = Instantiate(prefab,
												new Vector3(i * step, 0, j * step),
												Quaternion.identity, transform);
				Block block = cube.AddComponent<Block>();
				block.x = i;
				block.y = j;
				block.num = map.map[0, i, j];
				blocks.Add(block);
			}
		}
	}
}
