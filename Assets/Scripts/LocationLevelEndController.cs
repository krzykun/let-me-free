using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationLevelEndController : MonoBehaviour {

    public GameObject LocationThisLevelRespawn;
    public LocationLevelEndController LocationNextLevelController;
    public PlayerMoveController PlayerHandle;
    private bool LevelActive = false;

    public void ActivateThisLevel()
    {
        PlayerHandle.transform.position = LocationThisLevelRespawn.transform.position;
        LevelActive = true;
    }

    private void RespawnPlayer()
    {
        PlayerHandle.transform.position = LocationThisLevelRespawn.transform.position;
    }

    private void EndLevel()
    {
        LevelActive = false;
        LocationNextLevelController.ActivateThisLevel();
    }

	// Use this for initialization
	void Start () {
        ActivateThisLevel();
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
