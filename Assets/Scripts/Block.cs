using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	public int x, y;
	public string name;
	public Vector3 pos;
	public float speed = 1;

	private void Start()
	{
		var cubeRenderer = gameObject.GetComponentInChildren<Renderer>();
		cubeRenderer.material.SetColor("_Color",
				new Color(
					Random.Range(0f, 1f),
					Random.Range(0f, 1f),
					Random.Range(0f, 1f)
				));
	}

	private void Update()
	{
		transform.position = Vector3.Lerp(transform.position, pos, 0.1f);
	}
}
