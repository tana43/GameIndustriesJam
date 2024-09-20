using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carbluemove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 postion = transform.position;
        postion.x += 7 * Time.deltaTime;
        transform.position = postion;
    }
}
