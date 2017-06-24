using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public AudioListener _audioListener;
    public Camera _camera;

	private int _level = 1;

    public bool IsMusicEnabled
    {
        get { return _audioListener.enabled; }
        set { _audioListener.enabled = value; }
    }

    void Start()
    {
		DontDestroyOnLoad (gameObject);

		SceneManager.sceneLoaded += HandleSceneLoad;
    }

    public void SetMusicEnabled(bool enabled)
    {
        IsMusicEnabled = enabled;
    }

	private void LoadLevel(int level)
	{
		Debug.Log("Loading level " + level);
		SceneManager.LoadScene ("game_level_" + level);
	}

    public void StartGame()
    {
        Debug.Log("StartGame()");
		_level = 1;
		LoadLevel (_level);
    }

	private void HandleSceneLoad(Scene scene, LoadSceneMode mode)
	{
		if (scene.name.StartsWith ("game_level"))
		{
			SetupLevel ();
		}
	}

	private void SetupLevel()
	{
		GameObject endpoint = GameObject.FindGameObjectWithTag ("Endpoint");
		EndpointController endpointController = endpoint.GetComponent<EndpointController> ();

		endpointController.OnTriggerEntered += LoadNextLevel;
		endpointController.OnTriggerEntered += AddPlayerScore;

		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		PlayerMoveController playerController = endpoint.GetComponent<PlayerMoveController> ();
		playerController.OnPlayerDeath += () => {
			Debug.Log("player death from game controller");	
		};
	}

	private void AddPlayerScore()
	{
		Debug.Log ("adding score to player");
	}

	private void LoadNextLevel()
	{
		_level += 1;
		LoadLevel (_level);
	}

    public void ExitGame()
    {
        Debug.Log("ExitGame()");
        Application.Quit();
    }
}