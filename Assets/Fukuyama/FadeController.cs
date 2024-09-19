using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    bool isFadeIn  = false;
    bool isFadeOut = false;

    public float alpha    = 0.0f;
    public float fadeSpeed = 0.2f;

    public float red, green, blue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayFadeOut();
        }
    }

    public bool IsPlayFadeOut()
    {        
        if (!isFadeOut) return false;

        alpha += Time.deltaTime / fadeSpeed;
        this.GetComponent<Image>().color = new Color(red, green, blue, alpha);

        if (alpha < 1.0f) return false;

        isFadeOut = false;
        alpha = 1.0f;

        return true;
    }

    public bool IsPlayFadeIn()
    {
        if (!isFadeIn) return false;

        alpha -= Time.deltaTime / fadeSpeed;
        this.GetComponent<Image>().color = new Color(red, green, blue, alpha);

        if (alpha > 0.0f) return false;

        isFadeIn = false;
        alpha = 0.0f;

        return true;
    }

    // フェードイン
    public void PlayFadeIn()
    {
        isFadeIn  = true;
        isFadeOut = false;
    }

    public void PlayFadeOut()
    {
        isFadeOut = true;
        isFadeIn  = false;
    }

}
