using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obis : MonoBehaviour
{
    public float borderSpeed = 90.0f;

    //エフェクトプレハブ
    public GameObject flashEffectPrefab_;

    // Start is called before the first frame update
    void Start()
    {

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
        // 速度が20km未満なら
        if (speed < 20)
        {
            Debug.Log("１点");
            return 1;
            //HP-=1;
        }

        // 速度が20km以上かつ、25km未満なら
        if (speed >= 20 && speed < 25)
        {
            Debug.Log("２点");
            //HP-=2;
        }

        // 速度が25km以上かつ、40km未満なら
        if (speed >= 25 && speed < 40)
        {
            Debug.Log("３点");
            //HP-=3;
        }

        // 速度が40km以上かつ、50km未満なら
        if (speed >= 40 && speed < 50)
        {
            Debug.Log("５点");
            //HP-=5;
        }

        return 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float carSpeed = collision.gameObject.GetComponent<Player>().speed;

        float scoreSpeed = carSpeed - borderSpeed;

        if (scoreSpeed <= 0)
        {
            return;
        }

        int HP = 6;

        int score = CheckSpeed(scoreSpeed);
        if (score > 0)
        {
            HP -= score;

            //flasheffect生成
            Instantiate(flashEffectPrefab_, transform.position, Quaternion.Euler(Vector3.zero));
        }
    }
}
