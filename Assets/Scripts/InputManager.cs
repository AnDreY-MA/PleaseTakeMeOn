using UnityEngine;

public class InputManager : MonoBehaviour
{
    private InputSystem_Actions _inputActions;

    static private Vector2 _movement;

    static public Vector2 Movement => _movement;

    private void Awake()
    {
        _inputActions = new InputSystem_Actions();
        _inputActions.Enable();

        _movement = Vector2.zero;
    }

    private void Update()
    {
        _movement = _inputActions.Player.Move.ReadValue<Vector2>();
    }

}
