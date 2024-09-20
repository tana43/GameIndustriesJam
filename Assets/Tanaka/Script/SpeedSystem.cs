using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedSystem : MonoBehaviour
{
    //プレイヤーの速度が入る
    public static float generalSpeed_;

    public static float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        //generalSpeed_ = protoSpeed_;

       
    }

    // Update is called once per frame
    void Update()
    { 
        if (maxSpeed < generalSpeed_)
        {
            maxSpeed = generalSpeed_;
        }
        
    }

    private void LateUpdate()
    {
        //generalSpeed_ = protoSpeed_;
    }
}
