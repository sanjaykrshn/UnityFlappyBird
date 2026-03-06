using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    
    public float blinkInterval = 0.5f;

    private Image img;
    private float timer;

    

    void Awake()
    {
        img = GetComponent<Image>();
    }


    void Update()
    {
        if (gameObject.activeSelf)
        {
            timer += Time.unscaledDeltaTime;
            if (timer >= blinkInterval)
            {
                img.enabled = !img.enabled;
                timer = 0f;
            }
        } 
        
    }

}
