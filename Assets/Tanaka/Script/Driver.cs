using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    //体力（違反点数　6点まで）
    public int hp_ = 0;

    //死んでいるか
    public bool die_ = false;

    //免許停止までのスコア
    private const int licenseSuspensionScore = 6;

    // Start is called before the first frame update
    void Start()
    {
        die_ = false;
    }

    // Update is called once per frame
    void Update()
    {
        //免許停止処分演出
        
    }

    void DieUpdate()
    {
        //免停になっていないか
        if(hp_ >= licenseSuspensionScore)
        {

        }
    }
}
