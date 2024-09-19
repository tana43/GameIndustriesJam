using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//オービス
public class Orvis : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float scrollSpeed = SpeedSystem.generalSpeed_ * Time.deltaTime;

        //速度に合わせてオービスを下へ動かしていく
        var pos = transform.position;
        pos.y += scrollSpeed;
        transform.position = pos;
    }
}
