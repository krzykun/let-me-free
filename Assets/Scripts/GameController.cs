using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Canvas MainCanvas;
    public Canvas PanelCanvas;

    public ImageSwitcher ImageSwitcher;
    
    public AudioListener _audioListener;
    public Camera _camera;
    PlayerMoveController playerController;
    private int GameplayScenesCount;

    private int _level = 1;
    private int _introScreen;

    public bool IsMusicEnabled
    {
        get { return _audioListener.enabled; }
        set { _audioListener.enabled = value; }
    }

    void Start()
    {
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
        
	    _introScreen = 0;
	    MainCanvas.gameObject.SetActive(false);
	    PanelCanvas.gameObject.SetActive(true);
        LoadNextIntroductionScreen();
    }

    public void LoadNextIntroductionScreen()
    {
	    if (_introScreen < ImageSwitcher.Sprites.Length)
	    {
		    ImageSwitcher.SwitchImage(++_introScreen);
	    }
	    else
	    {
			MainCanvas.gameObject.SetActive(true);
		    PanelCanvas.gameObject.SetActive(false);
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