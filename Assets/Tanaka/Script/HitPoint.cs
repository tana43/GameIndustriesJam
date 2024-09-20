using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitPoint : MonoBehaviour
{
    //ドライバーオブジェクト
    public GameObject driverObject_;
    private Driver driverScript_;

    public GameObject hpTextObject_ = null;//テキストオブジェクト

    // Start is called before the first frame update
    void Start()
    {
        driverScript_ = driverObject_.GetComponent<Driver>();
    }

    // Update is called once per frame
    void Update()
    {
        Text timerText = hpTextObject_.GetComponent<Text>();

        //HPを表示
        timerText.text = driverScript_.hp_.ToString();

        //死んでたらテキスト赤にする
        if(driverScript_.die_)
        {
            timerText.color = Color.red;
        }
    }
}
