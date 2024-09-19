using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedMeter : MonoBehaviour
{
    public GameObject speedMeterObject_ = null;//テキストオブジェクト

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //テキスト
        Text timerText = speedMeterObject_.GetComponent<Text>();

        float speed = SpeedSystem.generalSpeed_;

        //速度
        int speedInt = (int)(speed * 10);
        speedInt = System.Math.Max(0, speedInt);
        string text = speedInt.ToString();
        text = text.PadLeft(2, '0');
        text = text.Insert(text.Length - 1, ".");
        timerText.text = text;
    }
}
