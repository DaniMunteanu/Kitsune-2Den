using UnityEditor.Il2Cpp;
using UnityEngine;
using UnityEngine.Rendering;

public class EventManager : MonoBehaviour
{
    [SerializeField]
    PlayerMovement player;

    [SerializeField]
    Minigame minigame;

    [SerializeField] public float normalScrollSpeed = 0f;
    public float currentScrollSpeed = 0f;
    public Minigame instantiatedMinigame;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentScrollSpeed = normalScrollSpeed;
        player.onMinigameStart.AddListener(StartMinigame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //pivotTheta.transform.localRotation = Quaternion.AngleAxis(theta * Mathf.Rad2Deg, Vector3.forward);

    void StartMinigame()
    {
        instantiatedMinigame = Instantiate(minigame);
        instantiatedMinigame.onMinigameEnd.AddListener(EndMinigame);
        currentScrollSpeed = 0;
        //minigame.onMinigameEnd.AddListener(EndMinigame);
    }

    void EndMinigame()
    {
        instantiatedMinigame.onMinigameEnd.RemoveListener(EndMinigame);
        Debug.Log("Gata cu joaca");
        player.transform.position += new Vector3(0f, 5f, 0f);
        
        player.OnEnable();

        currentScrollSpeed = normalScrollSpeed;

    }
}
