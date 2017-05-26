using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioListener), typeof(Camera))]
public class GameController : MonoBehaviour
{
    private AudioListener _audioListener;
    private Camera _camera;

    public bool IsMusicEnabled
    {
        get { return _audioListener.enabled; }
        set { _audioListener.enabled = value; }
    }

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        _audioListener = GetComponent<AudioListener>();
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetMusicEnabled(bool enabled)
    {
        IsMusicEnabled = enabled;
    }
}