using UnityEngine;
using UnityEngine.Events;

public class Minigame : MonoBehaviour
{
    public UnityEvent onMinigameEnd;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EndMinigame()
    {
        onMinigameEnd.Invoke();
    }
}
