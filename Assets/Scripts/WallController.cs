using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class WallController : MonoBehaviour
{
	private SpriteRenderer _renderer; 

	void Start ()
	{
		_renderer = GetComponent<SpriteRenderer> ();
		BoxCollider2D collider = gameObject.AddComponent<BoxCollider2D> () as BoxCollider2D;
		collider.size = _renderer.size;
	}
}
