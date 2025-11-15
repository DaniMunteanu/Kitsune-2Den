using UnityEngine;

public class AutoScroll : MonoBehaviour
{
    [SerializeField] EventManager eventManager;

    public float currentSpeed;

    void Update()
    {
        currentSpeed = eventManager.currentScrollSpeed;
        transform.Translate( 0, currentSpeed, 0);
    }
}
