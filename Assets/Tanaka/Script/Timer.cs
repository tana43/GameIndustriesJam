using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    //タイマー
    private float timer_;

    //タイマーがスタートしているか
    public bool timerStart_;

    public GameObject timerObject_ = null;//テキストオブジェクト

    // Start is called before the first frame update
    void Start()
    {
        timerStart_ = true;
    }

    // Update is called once per frame
    void Update()
    {
        Text timerText = timerObject_.GetComponent<Text>();

        //タイマー更新
        if (timerStart_)
        {
            timer_ += Time.deltaTime;
        }

        //00:00:00　こんな感じになるようにする
        //タイマー表示を二桁ずつ取得

        //下２桁
        int intTimer = (int)(timer_ * 100.0f);

        //６桁まで０埋め
        string time = intTimer.ToString();
        time = time.PadLeft(6, '0');
        time = time.Insert(4, ":");
        time = time.Insert(2, ":");

        //テキストの表示を入れ替える
        timerText.text = time;
    }

    //タイマー計測開始
    void StartTimer()
    {
        timerStart_ = true;
    }

    //タイマー計測終了
    void StopTimer()
    {
        timerStart_ = false;
    }

    //タイマーリセット
    void ResetTimer()
    {
        timer_ = 0;
        timerStart_ = false;
    }
}
