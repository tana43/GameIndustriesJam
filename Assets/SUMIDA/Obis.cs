using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obis : MonoBehaviour
{
    public float borderSpeed = 90.0f;
    private bool collisionflag = false;

    //エフェクトプレハブ
    public GameObject flashEffectPrefab_;

    //ドライバー
    private GameObject driverObject_;
    private Driver driverScript_;

    //各速度違反計測点数
    public float speeding4Score_ = 20.0f;
    
    public float speeding6Score_ = 40.0f;

    //プレイヤーは通過したか
    public bool passing_;

    // Start is called before the first frame update
    void Start()
    {
        driverObject_ = GameObject.Find("Driver");
        driverScript_ = driverObject_.GetComponent<Driver>();
        passing_ = false;
    }

    // Update is called once per frame
    void Update()
    {
        //速度に合わせてオービスを下へ動かしていく
        var pos = transform.position;
        pos.y -= RoadCommander.generalScrollSpeed_;
        transform.position = pos;

        //effectテスト
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //flasheffect生成
            Instantiate(flashEffectPrefab_, transform.position, Quaternion.Euler(Vector3.zero));
        }
    }

    private int CheckSpeed(float speed) 
    {
        // 違反速度を計測
        if (speed < speeding4Score_)
        {
            Debug.Log("2点");
            return 2;
            //HP-=1;
        }
        else if (speed < speeding6Score_)
        {
            Debug.Log("4点");
            //HP-=2;
            return 4;
        }

        // 速度が25km以上かつ、40km未満なら
        //if (speed >= 25 && speed < 40)
        //{
        //    Debug.Log("３点");
        //    //HP-=3;
        //    return 3;
        //}

        // 速度が40km以上なら
        //if (speed >= 40)
        //{
        //    Debug.Log("6点");
        //    return 6;
        //    //HP-=5;
        //}

        Debug.Log("6点");

        return 6;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if(!player)return;

        float carSpeed = collision.gameObject.GetComponent<Player>().speedY;

        //プレイヤーの通過を検知
        PlayerPassing();

        float scoreSpeed = carSpeed - borderSpeed;

        if (scoreSpeed <= 0)
        {
            return;
        }

        int score = CheckSpeed(scoreSpeed);
        if (score > 0)
        {
            //flashEffect生成
            Instantiate(flashEffectPrefab_, transform.position, Quaternion.Euler(Vector3.zero));
        }

        if (collision.gameObject.tag == "enemycar")
        {
            Debug.Log("hit");
            collisionflag = true;
        }

        //ドライバーに違反点数を科す
        driverScript_.Violation(score);
    }

    //プレイヤーが通過した
    void PlayerPassing()
    {
        passing_ = true;

        //センサーバーの色を変更
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
