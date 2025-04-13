using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBase : MonoBehaviour
{
    [SerializeField] private AudioClip _pressSound;

    private Button _button;

    public Action OnClick;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = FindFirstObjectByType<AudioSource>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        _audioSource.PlayOneShot(_pressSound);
        OnClick?.Invoke();
    }
}
