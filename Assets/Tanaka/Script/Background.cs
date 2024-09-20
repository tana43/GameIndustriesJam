using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    //Šeí”wŒi‚ğ“o˜^
    [SerializeField]
    private Sprite[] backSprites;

    private SpriteRenderer renderer_;

    // Start is called before the first frame update
    void Start()
    {
        renderer_ = GetComponent<SpriteRenderer>();

        //‰Šú”wŒi‚ğİ’è
        int rand = Random.Range(0, backSprites.Length);
        renderer_.sprite = backSprites[rand];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
