using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using Unity.VisualScripting;
using System.Collections;
using UnityEngine.UI;

public class Minigame : MonoBehaviour
{
    [SerializeField]
    GameObject arrowHandle;
    
    [SerializeField]
    InputActionReference interactControl;
    public UnityEvent onMinigameEnd;
    public UnityEvent onMinigameLose;
    public UnityEvent onMinigameWin;
    public float newRotationZ = 0f;
    public float rotationRate = 0f;
    private IEnumerator coroutine;

    [SerializeField] Image winSpot; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotationRate = 1f;
        OnEnable();
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
            
            //coroutine = Wait(2.0f);
            //StartCoroutine(coroutine);


            Invoke(nameof(Check), 0.0f);
            
    }

   
    void Check()
    {
        if ((newRotationZ % 360.0f) <= winSpot.fillAmount * 360)
        {
            onMinigameWin.Invoke();
        }
        else
        {
            onMinigameLose.Invoke();
        }
        onMinigameEnd.Invoke();

        Destroy(gameObject, 0.1f);

    }

    // Update is called once per frame
    void Update()
    {   
        newRotationZ += rotationRate;
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
