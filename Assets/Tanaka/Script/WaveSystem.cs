using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSystem : MonoBehaviour
{
    //目標地点までの距離
    [SerializeField]
    private float goalPoint_;

    //進行距離
    static public float distanceTraveled_;

    //静的変数確認用
    [SerializeField]
    private float distTravelMonitoring_;

    //ゴールまでの距離
    [SerializeField]
    private float goalDistance_;

    //タイマーのオブジェクト
    public GameObject TimerObject_;
    private Timer timer_;

    //オービスマネージャー
    public GameObject obisManagerObject_;
    private ObisManager obisManager_;

    //現在のウェーブ数
    [SerializeField]
    private int currentWave_ = 0;

    //ウェーブテキスト
    [SerializeField]
    private GameObject textObject_;

    //１つのWaveで使用するパラメータ
    [System.Serializable]
    public struct WaveParameter
    {
        public float timeLimit_;//時間制限
        public float obisSetInterval_;//オービスを配置する間隔
        public float obisFirstPoint_;//１つめのオービスまでの距離
    }

    //各ウェーブでの設定値を保持させておく
    [SerializeField]
    private WaveParameter[] waveParameters_;

    //ウェーブを全て乗り越えたか
    public bool complete_ = false;

    // Start is called before the first frame update
    void Start()
    {
        complete_ = false;

        currentWave_ = 0;

        timer_ = TimerObject_.GetComponent<Timer>();

        obisManager_ = obisManagerObject_.GetComponent<ObisManager>();

        //ウェーブ１へ
        NextWave();
    }

    // Update is called once per frame
    void Update()
    {
        //距離の更新
        TraveledUpdate();

        //ウェーブ更新
        WaveUpdate();

        //テキスト更新
        TextUiUpdate();
    }

    //進行距離の更新
    void TraveledUpdate()
    {
        //現在の進行距離
        float speed = SpeedSystem.generalSpeed_ * Time.deltaTime;

        //合計の進行距離を更新
        distanceTraveled_ += speed;

        //インスペクターで見るために確認用の変数へ
        distTravelMonitoring_ = distanceTraveled_;

        //ゴールまでの距離を計算
        goalDistance_ -= speed;
    }

    //次のウェーブへいくときに呼ばれる関数
    public void NextWave()
    {
        //ウェーブを進めて
        currentWave_++;

        //今回のウェーブの設定を取得
        var wave = waveParameters_[currentWave_ - 1];

        //各種設定を反映
        timer_.SetTimer(wave.timeLimit_);

        //オービスの設定
        obisManager_.obisSetInterval_ = wave.obisSetInterval_;

        //ゴールまでの距離をリセット
        goalDistance_ = goalPoint_;
    }

    //ウェーブ更新処理
    void WaveUpdate()
    {
        //タイマーが切れるまでに
        //ゴールまでの距離が０以下ならクリア
        if(goalDistance_ <= 0)
        {
            //次のウェーブ数を取得
            int newWave = currentWave_ + 1;

            //設定されているウェーブパラメータの要素数を越えるか判定
            if(waveParameters_.Length < newWave)
            {
                //TODO:越えるならゲームクリア
                //GameClear();

                complete_ = true;
            }
            else
            {
                //越えないなら、次のウェーブへ
                NextWave();
            }
        }
    }

    //UI更新
    void TextUiUpdate()
    {
        Text waveText = textObject_.GetComponent<Text>();

        waveText.text = "Wave" + currentWave_.ToString();
    }
}
