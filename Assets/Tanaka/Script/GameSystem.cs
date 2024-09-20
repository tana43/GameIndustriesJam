using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    //ゲームクリア
    static public bool gameClear_;

    //ウェーブシステム
    public GameObject waveSystemObject_;
    private WaveSystem waveSystem_;

    //エネミースポーンシステム
    public GameObject enemySpawnSystemObject_;

    public WaveSystem GetWaveSystem()
    {
        return waveSystem_;
    }

    //ゴールまでの設定距離
    public float goalPoint_;

    //進行距離
    static public float distanceTraveled_;

    //静的変数確認用
    [SerializeField]
    private float distTravelMonitoring_;

    //現在のゴールまでの距離
    [SerializeField]
    private float goalDistance_;

    //待機時間（タイマーや距離の更新をしない状態）
    public bool waitMode_ = false;

    //クリアエフェクト
    public GameObject clearEffectPrefab_;

    // Start is called before the first frame update
    void Start()
    {
        gameClear_ = false;

        waveSystem_ = waveSystemObject_.GetComponent<WaveSystem>();

        goalDistance_ = goalPoint_;
    }

    // Update is called once per frame
    void Update()
    {
        //ウェーブの更新
        WaveUpdate();

        //距離の更新
        if (!waitMode_)
        {
            TraveledUpdate();
        }
    }

    void GameClear()
    {
        gameClear_ = true;

        //敵の生成を停止する
        var spawnSystem = enemySpawnSystemObject_.GetComponent<enemysponescript>();
        spawnSystem.enabled = false;

        //クリアエフェクト
        Instantiate(clearEffectPrefab_);
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

    //ウェーブ更新
    void WaveUpdate()
    {
        //タイマーが切れるまでに
        //ゴールまでの距離が０以下ならクリア
        if (goalDistance_ <= 0)
        {
            bool waveEnd = waveSystem_.WaveClear();

            if (waveEnd)//全てのwaveが終了
            {
                GameClear();
            }
            else//次のwaveへ進んだ
            {
                //ゴールまでの距離をリセット
                goalDistance_ = goalPoint_;
            }
        }
    }
    //待機状態へ
    public void ToWaitMode()
    {
        waitMode_ = true;

        waveSystem_.timer_.StopTimer();
    }

    //待機状態解除
    public void WaitModeCancel()
    {
        waitMode_ = false;

        waveSystem_.timer_.StartTimer();
    }
}
