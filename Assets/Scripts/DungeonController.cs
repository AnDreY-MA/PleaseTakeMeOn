using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DungeonController : MonoBehaviour
{
    [SerializeField] private float _speedMovement = 2.0f;

    private Rigidbody2D _rigidbody;

    private void Awake() => _rigidbody = GetComponent<Rigidbody2D>();

    private void FixedUpdate()
    {
        if(InputManager.Movement != Vector2.zero)
        {
            Vector2 position = (Vector2)transform.position + _speedMovement * Time.fixedDeltaTime * InputManager.Movement;
            _rigidbody.MovePosition(position);
        }

    }
}