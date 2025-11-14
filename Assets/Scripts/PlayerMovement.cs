using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 5f;

    [SerializeField]
    InputActionReference moveControl;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnEnable()
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


}
