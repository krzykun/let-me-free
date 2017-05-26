using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour {

	public float velCoeff = 1.0f;

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
	}
}
