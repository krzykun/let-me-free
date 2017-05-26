using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour {

	public float velCoeff = 1.0f;
	public int health = 6;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * velCoeff;
		var y = Input.GetAxis("Vertical") * Time.deltaTime * velCoeff;

		//var x = Input.GetAxis("Horizontal") * 20.0f;
		//var y = Input.GetAxis("Vertical") * 20.0f;

		//if (x > )
		transform.Translate(x, y, 0);
		//tmp.AddForce(new Vector2(x, y), ForceMode2D.Impulse);
		if (health == 0)
		{
			health = 6; //TODO This is the defeat condition
		}
	}

	void OnCollisionEnter2D(Collision2D collObj)
	{
		if (collObj.gameObject.tag == "hen")
		{
			transform.position = new Vector2(-2.0f, 3.0f);
			health--;
			Debug.Log("PRZEGRYW" + health); //TODO lose life, reset position function
		}
	}
}
