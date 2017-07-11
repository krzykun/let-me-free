using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public AudioListener _audioListener;
    public Camera _camera;
    public GameObject[] introScenes;
    PlayerMoveController playerController;
    private int GameplayScenesCount;

    private int _level = 1;
    private int _introScreen = 1;

    public bool IsMusicEnabled
    {
        get { return _audioListener.enabled; }
        set { _audioListener.enabled = value; }
    }

    void Start()
    {
        foreach (GameObject introSplashScreen in introScenes)
        {
            introSplashScreen.SetActive(false);
        }
		DontDestroyOnLoad (gameObject);

		SceneManager.sceneLoaded += HandleSceneLoad;
        GameplayScenesCount = SceneManager.sceneCountInBuildSettings - 3;
        Debug.Log(GameplayScenesCount);
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

    public void IntroductionStorySetup()
    {
        Debug.Log("IntroductionStorySetup()");
        //hide previous UI
        //show button
        LoadNextIntroductionScreen();
    }

    public void LoadNextIntroductionScreen()
    {
        for (int i = 0; i < introScenes.Length; i++)
        {
            if (i != _introScreen)
            {
                introScenes[i].GetComponent<Renderer>().enabled = false;
            }
            else
            {
                introScenes[i].GetComponent<Renderer>().enabled = true;
            }
        }
        _introScreen++;
        if (_introScreen > 5)
        {
            //start the game after all introduction boards have been shown
            StartGame();
        }
    }

    public void StartGame()
    {
        Debug.Log("StartGame()");
		_level = 1;
		LoadLevel (_level);
    }

	private void HandleSceneLoad(Scene scene, LoadSceneMode mode)
	{
        Debug.Log("HandleSceneLoad");
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

		GameObject playerObjectHandle = GameObject.FindGameObjectWithTag ("Player");
		playerController = playerObjectHandle.GetComponent<PlayerMoveController> ();
		playerController.OnPlayerDeath += ondeath;
        playerController.SetIsGamePlayed(true);
    }

    public void ondeath()
    {
        bool IsGamePlayed = false;
        playerController.SetIsGamePlayed(IsGamePlayed);
        Debug.Log("player death from game controller");
        SceneManager.LoadScene("endlose");
    }

    private void PlayerWonTheGame()
    {
        Debug.Log("GameController.PlayerWonTheGame");
        bool IsGamePlayed = false;
        playerController.SetIsGamePlayed(IsGamePlayed);
        SceneManager.LoadScene("endwin");
    }

	private void AddPlayerScore()
	{
		Debug.Log ("adding score to player");
	}

	private void LoadNextLevel()
    {
        _level += 1;
        if ( _level <= GameplayScenesCount)
        {
            LoadLevel(_level);
        }
        else
        {
            PlayerWonTheGame();
        }
	}

    public void ExitGame()
    {
        Debug.Log("ExitGame()");
        Application.Quit();
    }
}