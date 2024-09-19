using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float brake = 7;                             //ブレーキ用
    public float acceleration = 7;                   //加速度      
    public float initialVelocity = 60;                  //初速
    public float speed = 10.0f;                         //x軸の変化量
    public float speedY = 0;                            //道路の速度変化量
    public float deceleration = 3.0f;                  //減速
    public float rotation = 30.0f;                      //角度
    public float startRotation = 0;                     //角度の初期値
    private float oldRotation = 0.0f;                   //前回の回転値
    private float moveRateVolume = 0.0f;                //ボタンが押されている際の回転値
    private float stopRateVolume = 0.0f;　              //ボタンが押されていない時の回転値
    [SerializeField] float moveRotationSpeed = 3.0f;　  //ボタンが押された際の回転スピード
    [SerializeField] float ReturnRotationSpeed = 5.0f;  //ボタンが押されていない時の回転スピード
    [SerializeField] float rate = 0.0f;               　//回転補完計算結果

    public float test = 0;

    bool leftClick;
    bool rightClick;

    // Start is called before the first frame update
    void Start()
    {
        startRotation = 0.0f;
    }

    private void FixedUpdate()
    {
        // 左マウスを押して加速
        if (leftClick)
        {
            Debug.Log("加速");
            speedY += acceleration * Time.deltaTime;
        }
        //右マウス減速
        else if(rightClick)
        {
            speedY -= (deceleration+brake) * Time.deltaTime;
        }
        else
        {
            Debug.Log("減速");
            speedY -= deceleration * Time.deltaTime;
            speedY = Mathf.Max(speedY, 0);
        }

        SpeedSystem.generalSpeed_ = speedY;

        test = SpeedSystem.generalSpeed_;

        Vector2 pos = transform.position;
        Vector3 angle = transform.eulerAngles;

        leftClick = Input.GetMouseButton(0);
        rightClick = Input.GetMouseButton(1);

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

    // Update is called once per frame
    void Update()
    {
       
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
