using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 10.0f;
    public float rotation = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        Vector3 angle = transform.eulerAngles;

        //“®‚­ˆ—
        //¶‚É“®‚­
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= speed * Time.deltaTime;
            angle.z += rotation * Time.deltaTime;
            if (angle.z > 30)
            {
                angle.z = 30;
            }
        }
        //‰E‚É“®‚­
        else if (Input.GetKey(KeyCode.D))
        {
            pos.x += speed * Time.deltaTime;
            angle.z -= rotation * Time.deltaTime;
        }

        //Vector2 pos = transform.position;
        //pos.y += speed * Time.deltaTime;
        //transform.position = pos;
        transform.position = pos;
        transform.eulerAngles = angle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit");
    }
}
