using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5f;

    [SerializeField]
    InputActionReference moveControl;

    public UnityEvent onMinigameStart;
    protected BoxCollider2D bc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    void DisableCollider()
    {
        bc.enabled = false;
    }

    public void OnEnable()
    {
        moveControl.action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = moveControl.action.ReadValue<float>();
        Vector2 movement = new Vector2(horizontalInput, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
            onMinigameStart.Invoke();
            moveControl.action.Disable();
    }

}
