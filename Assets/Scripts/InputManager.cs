using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private InputSystem_Actions _inputActions;

    static private Vector2 _movement;
    static private float _angleRotation;

    static public Vector2 Movement => _movement;
    static public float AngleRotation => _angleRotation;

    static public Action OnPausedPressed;

    private void Awake()
    {
        _inputActions = new InputSystem_Actions();
        _inputActions.Enable();
        _inputActions.Player.Pause.performed += OnPausePressed;

        _movement = Vector2.zero;
    }

    private void OnPausePressed(UnityEngine.InputSystem.InputAction.CallbackContext obj) => OnPausedPressed?.Invoke();

    private void OnDisable() => _inputActions.Disable();

    private void Update()
    {
        if (Game.IsPaused) return;

        _movement = _inputActions.Player.Move.ReadValue<Vector2>();
        _angleRotation = _inputActions.Player.Rotate.ReadValue<float>() * -1;
    }

}
