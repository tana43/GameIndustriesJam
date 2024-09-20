using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Driver : MonoBehaviour
{
    //体力（違反点数　6点まで）
    public int hp_ = 0;

    //死んでいるか
    public bool die_ = false;

    //免許停止までのスコア
    private const int licenseSuspensionScore = 6;

    //免停エフェクトのプレハブ
    [SerializeField]
    private GameObject LatterEffectPrefab_;

    //エフェクトは再生済か
   private bool playedEffect_ = false;
 
    // Start is called before the first frame update
    void Start()
    {
        die_ = false;
    }

    // Update is called once per frame
    void Update()
    {
        LicenseSuspensionUpdate();
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

    //免停演出
    async void LicenseSuspensionUpdate()
    {
        if (!die_) return;

        //Time.timeScale -= Time.deltaTime;
        //if (Time.timeScale < 0.1f)
    
        if(!playedEffect_)
        {
            Instantiate(LatterEffectPrefab_);
            playedEffect_ = true;

            await Task.Delay(200);  //暗転するまで待つ
            // 暗転してリザルト画面へ
            GameObject.Find("Fade").GetComponent<FadeController>().PlayFadeOut();
        }
    }
}
