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

    }

    //違反行為をした
    public void Violation(int score)
    {
        //既に免停か 
        if (die_) return;

        hp_ += score;

        //免停していないか
        DieCheck();
    }

    //死亡しているか
    void DieCheck()
    {
        //免停になっていないか
        if (hp_ >= licenseSuspensionScore)
        {
            Die();
        }
    }

    //死亡
    void Die()
    {
        die_ = true;


    }
}
