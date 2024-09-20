using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carbluemove : MonoBehaviour
{
    bool isMove = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            isMove = true;
        }

        if (isMove)
        {
            Vector2 postion = transform.position;
            postion.x += 7 * Time.deltaTime;
            transform.position = postion;
        }

        if (transform.position.x > 10)
        {
            GameObject.Find("Fade").GetComponent<FadeController>().PlayFadeOut();
        }
    }
}
