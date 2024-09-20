using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObisManager : MonoBehaviour
{
    //各オービスを設置する際の間隔
    public float obisSetInterval_;

    //オービスの検知速度
    public float obisBorderSpeed_;

    //各速度違反計測点数
    [SerializeField]
    private float speeding4Score_ = 20.0f;
    [SerializeField]
    private float speeding6Score_ = 40.0f;

    //オービスの生成範囲
    public float obisSpawnArea_;

    //そのウェーブで最初に生成されるオービスの配置位置
    //プレイヤーから見た距離
    public float spawnObisFirstPoint_;

    //オービスを生成する際のX座標
    [SerializeField]
    private float spawnPosX_;

    //生成したオービスを登録していく
    [SerializeField]
    private List<Obis> obisList_;

    //オービスのプレハブ
    [SerializeField]
    private GameObject obisPrefab_; 

    //次に通過するオービスの要素数
    private int nextObisIndex_;

    //ウェーブシステム
    [SerializeField]
    private GameObject waveSystemObject_; 
    private WaveSystem waveSystem_;

    //ゲームシステム
    [SerializeField]
    private GameObject gameSystemObject_;
    private GameSystem gameSystem_;

    //プレイヤー
    [SerializeField]
    private GameObject playerObject_;

    // Start is called before the first frame update
    void Start()
    {
        obisList_.Clear();

        waveSystem_ = waveSystemObject_.GetComponent<WaveSystem>();
        gameSystem_ = gameSystemObject_.GetComponent<GameSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePassingObis();
    }

    //設定値を元にオービスを配置していく
    public void SetObis()
    {
        //初期化
        Initialize();

        float playerPosY = playerObject_.transform.position.y;

        //最初の一体目をスポーンさせる
        float spawnPosY = playerPosY + spawnObisFirstPoint_;

        //生成時の座標は１５で割ったぐらいが丁度いい
        AddObis(spawnPosY / 15.0f);

        float intervalSpawnPosY = spawnPosY;
        //ゴール地点を越えるまでループ処理
        while (true)
        {
            //生成位置を間隔分動かす
            intervalSpawnPosY += obisSetInterval_;

            spawnPosY = intervalSpawnPosY + Random.RandomRange(-obisSpawnArea_, obisSpawnArea_);

            //生成位置がゴールを越えているなら生成せずに、ループを抜ける
            float dist = spawnPosY - playerPosY;
            if(dist > gameSystem_.goalPoint_)
            {
                break;
            }

            //生成処理
            AddObis(spawnPosY / 15.0f);
        }
    }

    //初期化
    void Initialize()
    {
        nextObisIndex_ = 0;

        ListClear();
    }

    //リストを削除し、クリアする
    void ListClear()
    {
        foreach (var obis in obisList_)
        {
            GameObject.Destroy(obis);
        }
        obisList_.Clear();
    }

    void AddObis(float spawnPosY)
    {
        //オービス生成
        Vector2 spawnPos = new Vector2(spawnPosX_,spawnPosY);
        var obj = Instantiate(obisPrefab_, spawnPos, Quaternion.Euler(Vector3.zero));

        var obis = obj.GetComponent<Obis>();
        obis.borderSpeed = obisBorderSpeed_;
        obis.speeding4Score_ = speeding4Score_;
        obis.speeding6Score_ = speeding6Score_;

        //リストに登録
        obisList_.Add(obis);
    }

    //プレイヤーが通過したオービスを判定し、次のオービスを更新
    void UpdatePassingObis()
    {
        //要素数が越えていないか
        if (obisList_.Count >= nextObisIndex_) return;

        //通過しているなら次のオービスへ
        var obis = obisList_[nextObisIndex_];
        if(obis.passing_)
        {
            nextObisIndex_++;
        }
    }
}
