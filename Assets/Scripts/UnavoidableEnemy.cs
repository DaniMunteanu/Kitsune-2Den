using UnityEngine;

public class UnavoidableEnemy : MonoBehaviour
{
    protected Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //player = PlayerMovement.Instance;
    }

    protected virtual void OnTriggerEnter2D(Collider2D _other)
    {
        Debug.Log("Unavoidable enemy encountered");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
