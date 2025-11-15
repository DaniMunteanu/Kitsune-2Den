using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using Unity.VisualScripting;
using System.Collections;

public class Minigame : MonoBehaviour
{
    [SerializeField]
    GameObject arrowHandle;
    
    [SerializeField]
    InputActionReference interactControl;
    public UnityEvent onMinigameEnd;
    public float newRotationZ = 0f;
    public float rotationRate = 0f;
    private IEnumerator coroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotationRate = 1f;
    }
    void OnEnable()
    {
        interactControl.action.Enable();
        interactControl.action.performed += Interact;
    }

    void Interact(InputAction.CallbackContext context)
    {
        if(context.performed)
            rotationRate = 0f;
            interactControl.action.Disable();

            Destroy(this,2);
            
    }

    // Update is called once per frame
    void Update()
    {   
        newRotationZ -= rotationRate;
        arrowHandle.transform.localRotation = Quaternion.Euler(0f, 0f, newRotationZ); 
    }

    private IEnumerator Wait(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
        }
    }

    void EndMinigame()
    {
        onMinigameEnd.Invoke();
    }
}
