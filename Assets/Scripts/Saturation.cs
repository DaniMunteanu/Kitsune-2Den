using UnityEngine;
using System;

public class Saturation : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.Rendering.Universal.FullScreenPassRendererFeature feature;
    private float passedTime = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        passedTime += Time.deltaTime;
        // Debug.Log(passedTime);
        feature.passMaterial.SetFloat("_Saturation", passedTime % 1.0f); // 0 to 1
    }

    public void SetSaturation (float sat)
    {
        feature.passMaterial.SetFloat("_Saturation", sat); // 0 to 1
    }
}
