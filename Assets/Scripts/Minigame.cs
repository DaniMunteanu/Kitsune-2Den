using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using Unity.VisualScripting;
using System.Collections;
using UnityEngine.UI;
using System;

public class Minigame : MonoBehaviour
{
    [SerializeField]
    GameObject arrowHandle;
    
    [SerializeField]
    InputActionReference interactControl;
    [SerializeField]
    TextBubbleUI textBubbleUI;
    public String[] questions;
    public String[] angstyAnswers;
    public String[] honestAnswers;
    public UnityEvent onMinigameEnd;
    public UnityEvent onMinigameLose;
    public UnityEvent onMinigameWin;
    public float newRotationZ = 0f;
    public float currentRotationRate = 0f;
    public float currentFillAmmount = 0f;
    public int pickedLineIndex;
    public TextBubbleUI instantiatedQuestionTextBubbleUI;
    public TextBubbleUI instantiatedAnswerTextBubbleUI;

    [SerializeField] Image winSpot; 
    [SerializeField] GameObject wheelParent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pickedLineIndex = UnityEngine.Random.Range(0, 10);
        InitializeLines();
        BuildQuestionTextBubbleUI();
        BuildWheel();
        OnEnable();
    }

    void InitializeLines()
    {
        questions = new String[10];

        questions[0] = "What's the matter?";
        questions[1] = "Why the long face?";
        questions[2] = "Something's wrong. I can feel it.";
        questions[3] = "You're not your usual self...";
        questions[4] = "Are you alright?";
        questions[5] = "What happened, friend?";
        questions[6] = "Is everything fine? I'm worried.";
        questions[7] = "Come on, tell me what happened...";
        questions[8] = "Have I done something wrong?";
        questions[9] = "You need to talk to someone...";

        angstyAnswers = new String[10];

        angstyAnswers[0] = "It doesn't matter";
        angstyAnswers[1] = "My face is perfectly circular, thanks";
        angstyAnswers[2] = "That's because you're wrong";
        angstyAnswers[3] = "Nothing is ever usual";
        angstyAnswers[4] = "Why wouldn't I be?";
        angstyAnswers[5] = "Nothing";
        angstyAnswers[6] = "Don't";
        angstyAnswers[7] = "I don't give interviews";
        angstyAnswers[8] = "I'm just tired";
        angstyAnswers[9] = "You need to talk to someone else";

        honestAnswers = new String[10];

        honestAnswers[0] = "I've been feeling kinda down lately...";
        honestAnswers[1] = "I feel like everything is gonna go wrong...";
        honestAnswers[2] = "I think no one will understand me";
        honestAnswers[3] = "I feel like I missed out on the person I wanted to be";
        honestAnswers[4] = "All the chaos in the world disturbs me";
        honestAnswers[5] = "I feel like I can't be a good friend";
        honestAnswers[6] = "Sorry for making you worry, it's hard for me to open up";
        honestAnswers[7] = "Fine...";
        honestAnswers[8] = "I let some people down yesterday...";
        honestAnswers[9] = "You're probably right...";

    }

    void BuildQuestionTextBubbleUI()
    {
        instantiatedQuestionTextBubbleUI = Instantiate(textBubbleUI);
        instantiatedQuestionTextBubbleUI.rt.anchoredPosition = new Vector2(-500.0f, 220.0f);
        instantiatedQuestionTextBubbleUI.lineText.text = questions[pickedLineIndex];
    }

    void BuildAngstyAnswerTextBubbleUI()
    {
        instantiatedAnswerTextBubbleUI = Instantiate(textBubbleUI);
        instantiatedAnswerTextBubbleUI.lineText.text = angstyAnswers[pickedLineIndex]; 
    }
    void BuildHonestAnswerTextBubbleUI()
    {
        instantiatedAnswerTextBubbleUI = Instantiate(textBubbleUI);
        instantiatedAnswerTextBubbleUI.lineText.text = honestAnswers[pickedLineIndex]; 
    }
    void BuildWheel()
    {
        wheelParent.transform.localRotation = Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(0.0f, 360.0f));
        arrowHandle.transform.localRotation = Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(0.0f, 360.0f));

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
            
            interactControl.action.Disable();
            
            //coroutine = Wait(2.0f);
            //StartCoroutine(coroutine);


            Invoke(nameof(Check), 0.1f);
            Invoke(nameof(DestroyTextBubbles), 1.0f);
            Invoke(nameof(InvokeMinigameEnd), 1.0f);
            Destroy(gameObject, 1.0f);
    }

    void InvokeMinigameEnd()
    {
        onMinigameEnd.Invoke();
    }
    void DestroyTextBubbles()
    {
        instantiatedQuestionTextBubbleUI.SelfDestruct();
        instantiatedAnswerTextBubbleUI.SelfDestruct();
    }

    void Check()
    {
        currentRotationRate = 0f;
        if ((newRotationZ % 360.0f) <= winSpot.fillAmount * 360)
        {
            BuildAngstyAnswerTextBubbleUI();
            onMinigameWin.Invoke();
        }
        else
        {
            BuildHonestAnswerTextBubbleUI();
            onMinigameLose.Invoke();
        }
    
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
