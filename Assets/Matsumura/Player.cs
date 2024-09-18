using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

    public float speed = 10.0f;                         //x軸の変化量
    public float rotation = 30.0f;                      //角度
    public float startRotation = 0;                     //角度の初期値
    private float oldRotation = 0.0f;                   //前回の回転値
    private float moveRateVolume = 0.0f;                //ボタンが押されている際の回転値
    private float stopRateVolume = 0.0f;　              //ボタンが押されていない時の回転値
    [SerializeField] float moveRotationSpeed = 3.0f;　  //ボタンが押された際の回転スピード
    [SerializeField] float ReturnRotationSpeed = 5.0f;  //ボタンが押されていない時の回転スピード
    [SerializeField] float rate = 0.0f;               　//回転補完計算結果

    // Start is called before the first frame update
    void Start()
    {
        startRotation = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        Vector3 angle = transform.eulerAngles;

        //ボタンが押された場合
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            //lerpの割合を更新
            rate = Mathf.Clamp01(moveRateVolume += moveRotationSpeed * Time.deltaTime);
        }

        //動く処理
        //同時に押された場合
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            angle.z = PlayerReturnRotation();
        }
        //左に動く
        else if (Input.GetKey(KeyCode.A))
        {
            pos.x -= speed * Time.deltaTime;
            angle.z = PlayerLeftRotation();
        }
        //右に動く
        else if (Input.GetKey(KeyCode.D))
        {
            pos.x += speed * Time.deltaTime;
            angle.z = PlayerRightRotation();
        }
        //何もキーが押されていない時
        else
        {
            angle.z = PlayerReturnRotation();
        }

        transform.position = pos;
        transform.eulerAngles = angle;
    }

    //右の回転処理
    float PlayerRightRotation()
    {
        oldRotation = -rotation;
        stopRateVolume = 0.0f;
        return Lerp(startRotation, -rotation);
    }
    //左の回転処理
    float PlayerLeftRotation()
    {
        oldRotation = rotation;
        stopRateVolume = 0.0f;
        return Lerp(startRotation, rotation);
    }
    //正面に戻る回転処理
    float PlayerReturnRotation()
    {
        moveRateVolume = 0;
        rate = Mathf.Clamp01(stopRateVolume += ReturnRotationSpeed * Time.deltaTime);
        return Lerp(oldRotation, 0.0f);
    }

    //補完計算関数
    float Lerp(float pos, float inverse)
    {
        return Mathf.Lerp(pos, 1.0f * inverse, rate);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit");
    }
}
