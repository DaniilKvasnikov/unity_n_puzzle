using System.Collections.Generic;
using n_puzzle.Scripts.Web;
using UnityEditor;
using UnityEngine;

namespace n_puzzle.Scripts.Puzzle
{
	public class RespawnBlock : MonoBehaviour
	{
		public GameObject prefab;
		public Texture2D texture;
		public float full_width;
		[HideInInspector] public Map map;
		
		private float step_size = 0.15f;
		private float scale = 0.15f;
	

		Dictionary<int, Block> blocks = new Dictionary<int, Block>();

		private void Awake()
		{
			GetMapJson.GetMap += GetMap;
		}

		private void GetMap(Map map)
		{
			scale = full_width / (float)map.map_size;
			step_size = scale;
			int invis_block_name = 0;
			Debug.Log("invis_block_name " + invis_block_name);
			this.map = map;
			Debug.Log("Respawn_blocks");
			foreach (KeyValuePair<int, Block> kvp in blocks)
				Destroy(blocks[kvp.Key].gameObject);
			blocks.Clear();

			for (int i = 0; i < map.map_size; i++)
			{
				for (int j = 0; j < map.map_size; j++)
				{
					RespawnBlockXY(i, j, invis_block_name);
				}
			}
		}

		private void RespawnBlockXY(int i, int j, int invis_block_name)
		{
			Vector3 pos = GetPosition(i, j);
			GameObject cube = Instantiate(prefab, transform, false);
			cube.transform.localPosition = pos;
			cube.transform.localScale = new Vector3(scale, scale, scale);
			Block block = cube.GetComponent<Block>();
			block.pos = pos;
			block.num = map.map[0, i, j];
			block.invis = (block.num == invis_block_name);
			int x = block.num % map.map_size;
			int y = block.num / map.map_size;
			block.x = x;
			block.y = y;
			block.SetText(block.num == 0 ? "" : block.num.ToString());
			if (block.num == invis_block_name)
				block.sprite = null;
			blocks.Add(map.map[0, i, j], block);
		}

		public void SetStep(int step)
		{
			if (step >= map.map_count || step < 0) return;
			for (int i = 0; i < map.map_size; i++)
			{
				for (int j = 0; j < map.map_size; j++)
					blocks[map.map[step, i, j]].pos = GetPosition(i, j);
			}
		}

		private Vector3 GetPosition(int i, int j)
		{
			return new Vector3(i * step_size, step_size, (j + 1) * step_size);
		}
	}
}
