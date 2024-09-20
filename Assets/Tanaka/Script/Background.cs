using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    //�e��w�i��o�^
    [SerializeField]
    private Sprite[] backSprites;

    private SpriteRenderer renderer_;

    // Start is called before the first frame update
    void Start()
    {
        renderer_ = GetComponent<SpriteRenderer>();

        //�����w�i��ݒ�
        int rand = Random.Range(0, backSprites.Length);
        renderer_.sprite = backSprites[rand];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
