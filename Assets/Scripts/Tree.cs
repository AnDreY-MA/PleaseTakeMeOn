using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private GameObject _smileSloth;

    private void Start()
    {
        _smileSloth.SetActive(false);
    }

    public void ApplySmileSloth()
    {
        _smileSloth.SetActive(true);
    }
}