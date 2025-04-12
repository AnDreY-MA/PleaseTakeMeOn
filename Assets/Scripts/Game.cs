using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private PauseMenu _pauseMenu;

    static private bool _isPaused = false;
    static public bool IsPaused => _isPaused;

    private void Awake()
    {
        _isPaused = false;
    }

    private void OnEnable()
    {
        _pauseMenu.OnGameResumed += TogglePause;
        InputManager.OnPausedPressed += TogglePause;
    }

    private void OnDisable()
    {
        _pauseMenu.OnGameResumed -= TogglePause;
        InputManager.OnPausedPressed -= TogglePause;
    }

    void TogglePause()
    {
        _isPaused = !_isPaused;
        _pauseMenu.gameObject.SetActive(_isPaused);
        Debug.Log("Toggle Pause: " + _isPaused);
    }
}
