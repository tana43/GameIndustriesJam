using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flash : MonoBehaviour
{
    [SerializeField] Text[] texts;
    [SerializeField] float sinSpeed = 10.0f;

    float alpha = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        alpha = Mathf.Sin(Time.time * sinSpeed);

        foreach (var text in texts)
        {
            Color rgb = text.color;
            text.color = new Color(rgb.r, rgb.g, rgb.b, alpha);
        }
    }
}
