using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private ButtonBase _resumeButton;
    [SerializeField] private ButtonBase _restartButton;
    [SerializeField] private ButtonBase _mainMenuButton;
    [SerializeField] private ButtonBase _quitButton;

    public Action OnGameResumed;

    private void Start() => gameObject.SetActive(false);

    private void OnEnable()
    {
        _resumeButton.OnClick += OnResumed;
        _restartButton.OnClick += OnRestart;

        _mainMenuButton.OnClick += OnMainMenu;
        _mainMenuButton.OnClick += OnQuited;
        
    }

    private void OnDisable()
    {
        _resumeButton.OnClick -= OnResumed;
        _restartButton.OnClick -= OnRestart;

        _mainMenuButton.OnClick -= OnMainMenu;
        _mainMenuButton.OnClick -= OnQuited;
    }

    private void OnResumed()
    {
        OnGameResumed?.Invoke();
    }

    private void OnRestart() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    private void OnMainMenu() => SceneManager.LoadScene("MainMenuScene");

    private void OnQuited() => Application.Quit();
}
