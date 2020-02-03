using TMPro;
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
		public TextMeshPro textOut;

		private void Start()
		{
			var cubeRenderer = gameObject.GetComponentInChildren<Renderer>();
			spriteR.sprite = sprite;
			cubeRenderer.enabled = !invis;
		}

		private void Update()
		{
			transform.localPosition = Vector3.Lerp(transform.localPosition, pos, speed);
		}

		public void SetText(string text)
		{
			textOut.text = text;
		}
	}
}
