using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    //scene array
    //player handle

	// Use this for initialization
	void Start () {
        //show the game intro
		//detect first scene
        //activate first scene
	}

    public void PlayerHasReachedEndOfLevel(int LevelNumber)
    {
        //deactivate [LevelNumber]
        //move player to next start location
        //if [LevelNumber + 1] exists
            //activate [LevelNumber]
        //else win the game
    }

    public void PlayerHasReachedEndOfGame()
    {
        //trigger end sequence
    }

	// Update is called once per frame
	void Update () {
        //if (PlayerHandle.health <= 0) dont respawn, its a levelcontroller thing not scenecontroller
        //{
            //RespawnPlayer();
        //}
    }
}
