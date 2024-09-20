using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedOverUI : MonoBehaviour
{
    [SerializeField]
    private GameObject obisManagerObject_;

    [SerializeField]
    private Sprite[] sprites_;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ObisManager obisManager = obisManagerObject_.GetComponent<ObisManager>();
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        float speed = SpeedSystem.generalSpeed_;
        if (speed > obisManager.obisBorderSpeed_ + obisManager.speeding6Score_)
        {
            renderer.enabled = true;
            renderer.sprite = sprites_[2];

        }
        else if(speed > obisManager.obisBorderSpeed_ + obisManager.speeding4Score_)
        {
            renderer.enabled = true;
            renderer.sprite = sprites_[1];
        }
        else if(speed > obisManager.obisBorderSpeed_)
        {
            renderer.enabled = true;
            renderer.sprite = sprites_[0];
        }
        else
        {
            renderer.enabled = false;
            
        }
    }
}
