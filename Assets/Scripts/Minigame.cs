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
    public float currentRotationRate = 0f;
    public float currentFillAmmount = 0f;

    [SerializeField] Image winSpot; 
    [SerializeField] GameObject wheelParent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BuildWheel();
        OnEnable();
    }

    void BuildWheel()
    {
        wheelParent.transform.localRotation = Quaternion.Euler(0f, 0f, Random.Range(0.0f, 360.0f));
        arrowHandle.transform.localRotation = Quaternion.Euler(0f, 0f, Random.Range(0.0f, 360.0f));

        winSpot.fillAmount = currentFillAmmount;
    }

    void OnEnable()
    {
        interactControl.action.Enable();
        interactControl.action.performed += Interact;
    }

    void Interact(InputAction.CallbackContext context)
    {
        if(context.performed)
            currentRotationRate = 0f;
            interactControl.action.Disable();
            
            //coroutine = Wait(2.0f);
            //StartCoroutine(coroutine);


            Invoke(nameof(Check), 0.0f);
            
    }

   
    void Check()
    {
        if ((newRotationZ % 360.0f) <= winSpot.fillAmount * 360)
        {
            Debug.Log("Win");
            onMinigameWin.Invoke();
        }
        else
        {
            Debug.Log("Lose");
            onMinigameLose.Invoke();
        }
        onMinigameEnd.Invoke();

        Destroy(gameObject, 0.1f);

    }

    // Update is called once per frame
    void Update()
    {   
        newRotationZ += currentRotationRate;
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
