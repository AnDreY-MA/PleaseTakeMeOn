using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBase : MonoBehaviour
{
    private Button _button;

    public Action OnClick;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        Debug.Log("OnButtonClick");
        OnClick?.Invoke();
    }
}
