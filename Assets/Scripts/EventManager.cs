using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField]
    PlayerMovement player;

    [SerializeField]
    Minigame minigame;

    [SerializeField]
    AutoScroll autoScroll;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player.onMinigameStart.AddListener(StartMinigame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //pivotTheta.transform.localRotation = Quaternion.AngleAxis(theta * Mathf.Rad2Deg, Vector3.forward);

    void StartMinigame()
    {
        Instantiate(minigame);
        autoScroll.currentSpeed = 0;
        //minigame.onMinigameEnd.AddListener(EndMinigame);
    }

    void EndMinigame()
    {
        //DestroyImmediate(this);
    }
}
