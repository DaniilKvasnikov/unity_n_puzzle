using System.Collections.Generic;
using n_puzzle.Scripts.Web;
using UnityEngine;

namespace n_puzzle.Scripts.Puzzle
{
	public class RespawnBlock : MonoBehaviour
	{
		public GameObject prefab;
		public string invis_block_name = "15";
		public float step_size = 0.15f;
		public float scale = 0.15f;
		public Texture2D texture;
	
		private int currStep;

		Dictionary<string, Block> blocks = new Dictionary<string, Block>();
		Map map;

		private void Awake()
		{
			GetMapJson.GetMap += Respawn_blocks;
		}

		private void Respawn_blocks(Map map)
		{
			this.map = map;
			Debug.Log("Respawn_blocks");
			foreach (KeyValuePair<string, Block> kvp in blocks)
				Destroy(blocks[kvp.Key].gameObject);
			for (int i = 0; i < map.map_size; i++)
			{
				for (int j = 0; j < map.map_size; j++)
				{
					Vector3 pos = new Vector3(i * step_size, 0, j * step_size);
					GameObject cube = Instantiate(prefab, pos,
						Quaternion.identity, transform);
					cube.transform.localScale = new Vector3(scale, scale, scale);
					Block block = cube.GetComponent<Block>();
					block.x = i;
					block.y = j;
					block.pos = pos;
					block.name = map.map[0, i, j];
					block.invis = block.name == invis_block_name;
					block.sprite = Sprite.Create(texture, new Rect(texture.width / map.map_size * i,texture.height / map.map_size * j,texture.width / map.map_size,texture.height / map.map_size), new Vector2(1.0f, 1.0f));
					if (block.name == invis_block_name)
						block.sprite = null;
					blocks.Add(map.map[currStep, i, j], block);
				}
			}
		}

		public void NextStep()
		{
			if (currStep + 1 < map.map_count)
				currStep++;
			SetStep(currStep);
		}

		public void PrevStep()
		{
			if (currStep - 1 >= 0)
				currStep--;
			SetStep(currStep);
		}

		private void SetStep(int step)
		{
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
