﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour {

	public float velCoeff = 1.0f;
	public int health = 6;
    public Vector2 startPosition;
    public Vector2 endPosition;
    public int HenHitPenalty = 1;


	// Use this for initialization
	void Start () {
		
	}

    // TODO This is triggered once the player reaches endPosition
    void LevelWonTransition()
    {
        Debug.Log("LEVEL CLEARED - add transition here");
    }

    // TODO This is a trigger function for the 'game over' scene transition
    void GameOverTransition()
    {
        Debug.Log("GAME OVER - add transition here");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * velCoeff;
		var y = Input.GetAxis("Vertical") * Time.deltaTime * velCoeff;

        if (Input.GetKeyDown("space"))
        {
            jump();
        }

		//var x = Input.GetAxis("Horizontal") * 20.0f;
		//var y = Input.GetAxis("Vertical") * 20.0f;

		//if (x > )
		transform.Translate(x, y, 0);
		//tmp.AddForce(new Vector2(x, y), ForceMode2D.Impulse);
	}

    void jump()
    {
        //this.GetComponent<SpriteRenderer>().
    }

    public void TakeDamage(int DamageValue)
    {
        health -= DamageValue;
        Debug.Log("Player took "+DamageValue+" points of damage. Current health: " + health);
        if (health <= 0)
        {
            GameOverTransition();
            health = 6; //TODO This is the defeat condition
        }
        else
        {
            transform.position = startPosition;
        }
    }

	void OnCollisionEnter2D(Collision2D collObj)
	{
		if ((collObj.gameObject.tag == "hen") || (collObj.gameObject.tag == "deadly"))
		{
            TakeDamage(HenHitPenalty);
        }
	}
}
