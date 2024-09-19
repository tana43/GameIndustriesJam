using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedSystem : MonoBehaviour
{
    //プレイヤーの速度が入る
    public static float generalSpeed_;

    //インスペクター上で動かすための仮の速度
    [SerializeField]
    private float protoSpeed_ = 0.0f;


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
        
    }

    private void LateUpdate()
    {
        generalSpeed_ = protoSpeed_;
    }
}
