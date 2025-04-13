using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private PauseMenu _pauseMenu;
    [SerializeField] private WinMenu _winMenu;
    [SerializeField] private Player _player;
    [SerializeField] private string _nextScene;

    static private bool _isPaused = false;
    static public bool IsPaused => _isPaused;

    private IPauseable[] _pauseables;

    private void Awake()
    {
        _isPaused = false;
        _pauseables = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<IPauseable>().ToArray();
        _player.OnTreeCompleted += OnLevelCompleted;
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

    private void TogglePause()
    {
        _isPaused = !_isPaused;
        _pauseMenu.gameObject.SetActive(_isPaused);
        foreach(var pauseable in _pauseables)
        {
            pauseable.Pause(_isPaused);
        }
        Debug.Log("Toggle Pause: " + _isPaused);
    }

    private void OnLevelCompleted()
    {
        _winMenu.gameObject.SetActive(true);
        _winMenu.OnToNextLevel += OnNextScene;
    }

    private void OnNextScene() => SceneManager.LoadScene(_nextScene);


}