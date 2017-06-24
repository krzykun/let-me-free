using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndpointController : MonoBehaviour {

	public event Action OnTriggerEntered = delegate {};

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			OnTriggerEntered ();
		}
	}
}
