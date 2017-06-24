using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationLevelEndController : MonoBehaviour {

    public GameObject LocationThisLevelRespawn;
    public LocationLevelEndController LocationNextLevelController; //remove, scenecontroller's job
    public PlayerMoveController PlayerHandle; //should be given by scenecontroller when activating scene
    private bool LevelActive = false;
    private SceneController ParentController;
    private int LevelNumber;

    public void ActivateThisLevel(int levelNumberParameter,  SceneController parentControllerParameter)
    {
        ParentController = parentControllerParameter;
        LevelNumber = levelNumberParameter;
        PlayerHandle.transform.position = LocationThisLevelRespawn.transform.position;
        LevelActive = true;
    }

    public void RespawnPlayer()
    {
        PlayerHandle.transform.position = LocationThisLevelRespawn.transform.position;
    }

    private void EndLevel()
    {
        LevelActive = false;
        //if (LocationNextLevelController != null)
        //{
        //    LocationNextLevelController.ActivateThisLevel(); //instead tell scenecontroller that level is over
        //}
        ParentController.PlayerHasReachedEndOfLevel(LevelNumber);
    }

	// Use this for initialization
	void Start () {
        //ActivateThisLevel(); //delete this
	}
	
	// Update is called once per frame
	void Update () {
        if (LevelActive)
        {
            if (PlayerHandle.health <= 0)
            {
                RespawnPlayer();
            }
        }
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            EndLevel();
        }
    }
}
