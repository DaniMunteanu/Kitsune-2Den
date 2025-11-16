using System;
using UnityEditor.Il2Cpp;
using UnityEngine;
using UnityEngine.Rendering;

public class EventManager : MonoBehaviour
{
    [SerializeField]
    PlayerMovement player;

    [SerializeField]
    Minigame minigame;

    [SerializeField]
    GameOver gameOver;

    [SerializeField]
    Saturation saturation;

    [SerializeField]
    GameObject gameplayText; 

    [SerializeField] public float normalScrollSpeed = 0f;
    public float currentScrollSpeed = 0f;
    public int lives = 10;
    public float saturationStep = 0.1f;
    public int totalMinigames = 10;
    public float[] levelRotationRate;
    public float[] levelFillAmount;
    public int minigameCount = 0;
    public Minigame instantiatedMinigame;
    public GameOver instantiatedGameOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        saturation.SetSaturation(0.0f);
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
        gameplayText.SetActive(false);
        instantiatedMinigame = Instantiate(minigame);
        instantiatedMinigame.currentRotationRate = levelRotationRate[Math.Min(minigameCount, totalMinigames - 1)];
        instantiatedMinigame.currentFillAmmount = levelFillAmount[Math.Min(minigameCount, totalMinigames - 1)];
        instantiatedMinigame.onMinigameEnd.AddListener(EndMinigame);
        instantiatedMinigame.onMinigameWin.AddListener(OnMinigameWon);
        instantiatedMinigame.onMinigameLose.AddListener(OnMinigameLost);
        currentScrollSpeed = 0;
        //minigame.onMinigameEnd.AddListener(EndMinigame);
    }

    void EndMinigame()
    {
        gameplayText.SetActive(true);
        instantiatedMinigame.onMinigameEnd.RemoveListener(EndMinigame);
        instantiatedMinigame.onMinigameWin.RemoveListener(OnMinigameWon);
        instantiatedMinigame.onMinigameLose.RemoveListener(OnMinigameLost);
        
        player.transform.position += new Vector3(0f, 4f, 0f);
        
        player.OnEnable();

        currentScrollSpeed = normalScrollSpeed;
        minigameCount++;

        if (lives == 0)
            GameDefeat();
    }

    void OnMinigameWon()
    {
        
    }

    void OnMinigameLost()
    {
        lives--;
        saturation.SetSaturation(1 - (lives * saturationStep));
    }

    void GameDefeat()
    {
        instantiatedGameOver = Instantiate(gameOver);
        currentScrollSpeed = 0;
    }
}
