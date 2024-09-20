using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSystem : MonoBehaviour
{
    //タイマーのオブジェクト
    public GameObject TimerObject_;
    public Timer timer_;

    //オービスマネージャー
    public GameObject obisManagerObject_;
    private ObisManager obisManager_;

    //ゲームシステム
    public GameObject gameSystemObject_;
    private GameSystem gameSystem_;

    //現在のウェーブ数
    static public int currentWave_ = 0;

    //ウェーブテキスト
    [SerializeField]
    private GameObject textObject_;

    //ウェーブエフェクト
    [SerializeField]
    private GameObject nextWaveEffectPrefab_;

    //ウェーブが上がったときに待機する時間
    [SerializeField]
    private float nextWaveWaitTime_ = 2.0f;
    private float nextWaveWaitTimer_ = 0.0f;

    //１つのWaveで使用するパラメータ
    [System.Serializable]
    public struct WaveParameter
    {
        public float timeLimit_;//時間制限
        public float obisSetInterval_;//オービスを配置する間隔
        public float obisFirstPoint_;//１つめのオービスまでの距離

        //public float borderSpeed_;//違反速度

        public float obisSpawnArea_;//オービスの生成範囲（20の場合、本来生成される位置から前後２０以内に生成される）
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

        gameSystem_ = gameSystemObject_.GetComponent<GameSystem>();

        nextWaveWaitTimer_ = 0.0f;

        //ウェーブ１へ
        NextWave();
    }

    // Update is called once per frame
    void Update()
    {   
        //テキスト更新
        TextUiUpdate();

        //待機状態の更新
        UpdateWaitTime();
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
        obisManager_.spawnObisFirstPoint_ = wave.obisFirstPoint_;
        obisManager_.obisSpawnArea_ = wave.obisSpawnArea_;

        //オービスマネージャーからオービス設置
        obisManager_.SetObis();

        //エフェクト再生
        Instantiate(nextWaveEffectPrefab_, Vector2.zero, Quaternion.Euler(Vector3.zero));

        //待機タイマーリセット
        nextWaveWaitTimer_ = 0.0f;


        //ゲームシステムを待機へ
        gameSystem_.ToWaitMode();
    }

    //ウェーブをクリア 次のwaveがあるならfalse,ないならtrue
    public bool WaveClear()
    {
        // リザルトのスコア更新
        Result.SetResult(currentWave_, timer_.GetTimer());

        //次のウェーブ数を取得
        int newWave = currentWave_ + 1;

        //設定されているウェーブパラメータの要素数を越えるか判定
        if(waveParameters_.Length < newWave)
        {
            //TODO:越えるならゲームクリア
            //GameClear();

            complete_ = true;

            return true;
        }
        else
        {
            //越えないなら、次のウェーブへ
            NextWave();

            return false;
        }
    }

    //UI更新
    void TextUiUpdate()
    {
        Text waveText = textObject_.GetComponent<Text>();

        waveText.text = currentWave_.ToString();
    }

    void UpdateWaitTime()
    {
        //待機状態でないのなら処理しない
        if (!gameSystem_.waitMode_) return;

        if(nextWaveWaitTimer_ > nextWaveWaitTime_)
        {
            //待機を解除
            gameSystem_.WaitModeCancel();
        }

        nextWaveWaitTimer_ += Time.deltaTime;
    }
}
