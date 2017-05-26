using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HenMoveController : MonoBehaviour {

	public Transform[] waypoints;
	public bool goingLeft = false; // Tells us if the hen is going right (1) or left (0)
	public float speed = 1.0f; // The amount given to Translate function on every update
	private int counter = 0;
	private SpriteRenderer rend;

	// Use this for initialization
	void Start () {
		rend = this.GetComponent<SpriteRenderer>();
	}
	
	void switchDirection()
	{
		speed *= -1;
		goingLeft = !goingLeft;
		rend.flipX = goingLeft;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (counter > 30)
		{
			switchDirection();
			counter = 0;
		}
		transform.Translate(speed, 0, 0);

		counter++;
	}
	
}
