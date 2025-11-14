using UnityEngine;
using TMPro;
using System;

public class SpeechBubble : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer backing;
    [SerializeField]
    private TMP_Text text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //todo: change speech bubble size based on text?
    }

    // Update is called once per frame
    void Update()
    {
        text.text = DateTime.Now.ToString(); //lmao
    }
}
