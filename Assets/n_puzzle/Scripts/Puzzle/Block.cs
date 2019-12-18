using UnityEngine;

namespace n_puzzle.Scripts.Puzzle
{
	public class Block : MonoBehaviour
	{
		public int x, y;
		public int num;
		public Vector3 pos;
		public float speed = 0.1f;
		public bool invis = false;
		public Sprite sprite;
		public SpriteRenderer spriteR;

		private void Start()
		{
			var cubeRenderer = gameObject.GetComponentInChildren<Renderer>();
			cubeRenderer.material.SetColor("_Color",
				new Color(
					Random.Range(0f, 1f),
					Random.Range(0f, 1f),
					Random.Range(0f, 1f)
				));
			spriteR.sprite = sprite;
			cubeRenderer.enabled = !invis;
		}

		private void Update()
		{
			transform.position = Vector3.Lerp(transform.position, pos, speed);
		}
	}
}
