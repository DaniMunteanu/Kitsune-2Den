using UnityEngine;

public class AutoScroll : MonoBehaviour
{
    [SerializeField] public float speed; 

    public float currentSpeed;

    void Start()
    {
        currentSpeed = speed;
    }
    void Update()
    {
        transform.Translate( 0, currentSpeed, 0);
    }
}
