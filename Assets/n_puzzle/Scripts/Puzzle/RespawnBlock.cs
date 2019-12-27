using System.Collections.Generic;
using n_puzzle.Scripts.Web;
using UnityEditor;
using UnityEngine;

namespace n_puzzle.Scripts.Puzzle
{
	public class RespawnBlock : MonoBehaviour
	{
		public GameObject prefab;
		public float step_size = 0.15f;
		public float scale = 0.15f;
		public Texture2D texture;
		[HideInInspector] public Map map;
	

		Dictionary<int, Block> blocks = new Dictionary<int, Block>();

		private void Awake()
		{
			GetMapJson.GetMap += GetMap;
		}

		private void GetMap(Map map)
		{
			int invis_block_name = map.map_size * map.map_size - 1;
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
					Vector3 pos = new Vector3(i * step_size, 0, j * step_size);
					GameObject cube = Instantiate(prefab, pos,
						Quaternion.identity, transform);
					cube.transform.localScale = new Vector3(scale, scale, scale);
					Block block = cube.GetComponent<Block>();
					block.pos = pos;
					block.num = map.map[0, i, j];
					block.invis = (block.num == invis_block_name);
					int x = block.num % map.map_size;
					int y = block.num / map.map_size;
					block.x = x;
					block.y = y;
					block.sprite = Sprite.Create(texture, new Rect(texture.width / map.map_size * x,texture.height / map.map_size * (map.map_size - 1 - y),texture.width / map.map_size,texture.height / map.map_size), new Vector2(1.0f, 1.0f));
					if (block.num == invis_block_name)
						block.sprite = null;
					blocks.Add(map.map[0, i, j], block);
				}
			}
		}

		public void SetStep(int step)
		{
			if (step >= map.map_count || step < 0) return;
			Debug.Log("SetStep");
			for (int i = 0; i < map.map_size; i++)
			{
				for (int j = 0; j < map.map_size; j++)
				{
					blocks[map.map[step, i, j]].pos =
						new Vector3(i * step_size, 0, j * step_size);
				}
			}
		}
	}
}
