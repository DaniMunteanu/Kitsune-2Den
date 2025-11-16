using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextBubbleUI : MonoBehaviour
{
    [SerializeField] 
    public TextMeshProUGUI lineText;
    public RectTransform rt;

    [SerializeField]
    public GameObject bubbleParent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        rt = bubbleParent.GetComponent<RectTransform>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
