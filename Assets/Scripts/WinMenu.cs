using System;
using UnityEngine;

public class WinMenu : MonoBehaviour
{
    [SerializeField] private ButtonBase _nextLevelButton;
    [SerializeField] private ButtonBase _quitButton;

    public Action OnToNextLevel;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _nextLevelButton.OnClick += OnNextLevel;
        _quitButton.OnClick += OnQuited;
    }

    private void OnDisable()
    {
        _nextLevelButton.OnClick -= OnNextLevel;
        _quitButton.OnClick -= OnQuited;
    }

    private void OnNextLevel() => OnToNextLevel?.Invoke();

    private void OnQuited() => Application.Quit();
}
