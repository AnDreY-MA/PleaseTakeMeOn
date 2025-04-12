using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private string _loadScene;
    [SerializeField] private ButtonBase _startButton;
    [SerializeField] private ButtonBase _quitButton;

    private void Awake()
    {
        _startButton.OnClick += OnStarted;
        _quitButton.OnClick += OnQuited;
    }

    private void OnStarted()
    {
        SceneManager.LoadScene(_loadScene);
    }

    private void OnQuited()
    {
        Application.Quit();
    }
}
