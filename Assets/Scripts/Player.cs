using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour, IPauseable
{
    private Rigidbody2D _rigidbody;

    public Action OnTreeCompleted;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Tree>(out Tree tree))
        {
            OnTreeCompleted?.Invoke();
            tree.ApplySmileSloth();
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            Debug.Log("Tree");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTreeCompleted?.Invoke();
        Debug.Log("Trigger: " + collision.gameObject.name);
    }

    public void Pause(bool isPaused) 
    {
        _rigidbody.simulated = !isPaused;
    }
}
