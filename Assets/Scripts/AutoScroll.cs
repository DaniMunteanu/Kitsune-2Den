using UnityEngine;

public class AutoScroll : MonoBehaviour
{
    [SerializeField] public float speed; 
    void Update()
    {
        transform.Translate( 0, speed, 0);
    }
}
