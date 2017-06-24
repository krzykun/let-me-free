using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public GameObject PlayerHandle;
    //scene array
    //player handle
    private GameObject[] StartLocations; // not needed?
    //private GameObject[] RespawnLocations;
    private GameObject[] EndLocations;  //use these with GameObject.FindGameObjectsWithTag("Respawn");
    private int CurrentLevel;

    // Use this for initialization
    void Start ()
    {
        //Application.LoadLevel(0); load the main menu
        //show the game intro
        //detect first scene
        for (int i = 0; i < 4; i++)
        {
            SceneManager.LoadScene(i, LoadSceneMode.Additive);   
            //StartLocations.
        }

        if (StartLocations == null)
        {
            StartLocations = GameObject.FindGameObjectsWithTag("StartLocation");
        }

        foreach (GameObject startlocation in StartLocations)
        {
            Debug.Log(startlocation.scene.name);
        }

        if (EndLocations == null)
        {
            EndLocations = GameObject.FindGameObjectsWithTag("StartLocation");
        }

        CurrentLevel = 0;   // TODO fill with proper value later
        PlayerHasReachedEndOfLevel(CurrentLevel);  // trigger first level
        //if (RespawnLocations == null)
        //{
        //    RespawnLocations = GameObject.FindGameObjectsWithTag("Respawn");
        //}
        //activate first scene
    }

    public void PlayerHasReachedEndOfLevel(int LevelNumber)
    {
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
        if (PlayerHandle.GetComponent<PlayerMoveController>().health <= 0)
        {
            EndLocations[CurrentLevel].GetComponent<LocationLevelEndController>().RespawnPlayer();
        }
    }
}
