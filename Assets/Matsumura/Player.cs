using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;
using UnityEngine.UIElements;
using Cinemachine;

public class Player : MonoBehaviour
{
    public float acceleration = 10;                     //加速度      
    public float initialVelocity = 60;                  //初速
    public float speedX = 10.0f;                        //x軸の変化量
    public float speedY = 0;                            //道路の速度変化量
    public float deceleration = 3.0f;                   //減速
    public float rotation = 30.0f;                      //角度
    public float startRotation = 0;                     //角度の初期値
    private float brake = 18;                           //ブレーキ用
    private float oldRotation = 0.0f;                   //前回の回転値
    private float moveRateVolume = 0.0f;                //ボタンが押されている際の回転値
    private float stopRateVolume = 0.0f;　              //ボタンが押されていない時の回転値
    private float musicLength = 3.318f;                 //SE(ブレーキ音)の長さ
    private float SEbrakeLength = 2.200f;               //SE(軽いブレーキ)の長さ
    private float SEacceleLength = 3.180f;              //SE(アクセル)の長さ
    [SerializeField] float moveRotationSpeed = 3.0f;　  //ボタンが押された際の回転スピード
    [SerializeField] float ReturnRotationSpeed = 5.0f;  //ボタンが押されていない時の回転スピード
    [SerializeField] float rate = 0.0f;                 //回転補完計算結果
    [SerializeField] GameObject came;
    bool cameraChine = false;
    bool playingSound = false;
    bool acceleSound = false;
    bool brakeSound = false;
    public float SEtimer=0;
    float SEkaiten = 0;

    public float test = 0;                              //generalSpeed_の値を確認する用

    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        startRotation = 0.0f;
        speedY = 60;
        //Component取得
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        audioSource.Play();

        Vector2 pos = transform.position;
        Vector3 angle = transform.eulerAngles;

        //ボタンが押された場合
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {

            if (brakeSound == false)
            {
                audioSource.PlayOneShot(sound2);
                brakeSound = true;
                SEkaiten = 0;
            }
            if (SEbrakeLength >= SEkaiten)
                brakeSound = false;
            //lerpの割合を更新
            rate = Mathf.Clamp01(moveRateVolume += moveRotationSpeed * Time.deltaTime);
        }
        //同時に押された場合
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            angle.z = PlayerReturnRotation();
        }
        //左に動く
        else if (Input.GetKey(KeyCode.A))
        {
            pos.x -= speedX * Time.deltaTime;
            angle.z = PlayerLeftRotation();
        }
        //右に動く
        else if (Input.GetKey(KeyCode.D))
        {
            pos.x += speedX * Time.deltaTime;
            angle.z = PlayerRightRotation();
        }
        //何もキーが押されていない時
        else
        {
            brakeSound = false;
            angle.z = PlayerReturnRotation();
        }
        //スピード０の時X軸移動、回転できない
        if (speedY <= 20)
        {
            speedX = 5;
            if (speedY <= 0)
            {
                brakeSound = true;
                speedX = 0;
                angle.z = 0;
            }
        }
        else
        {
            speedX = 10;
        }

        // 左マウスを押して加速　アクセル
        if (Input.GetMouseButton(0))
        {
            Debug.Log("加速");
           
            if (acceleSound==false)
            {
                audioSource.PlayOneShot(sound3);
                acceleSound = true;
                SEtimer = 0;
            }
            if (SEtimer >= SEacceleLength)
                acceleSound = false;
            
            if (speedY <= 50)
            {
                acceleration = 20;
            }
            else
                acceleration = 10;
            speedY += VelocityVariation();
        }
        //右マウス減速　ブレーキ
        else if(Input.GetMouseButton(1))
        {
            //audioSource.Play();
            if (playingSound==false&&speedY>0)
            {
                playingSound = true;
                audioSource.PlayOneShot(sound1);
                SEtimer = 0;
            }
            if(SEtimer>=musicLength)
            {
                playingSound = false;
            }
            speedY -= VelocityVariation(brake);
            speedY = Mathf.Max(speedY, 0);
        }
        //自然減速
        else
        {
            audioSource.Stop();
            playingSound = false;
            acceleSound = false;
            speedY -= VelocityVariation();
            speedY = Mathf.Max(speedY, 0);
        }
        transform.position = pos;
        transform.eulerAngles = angle;
        SpeedSystem.generalSpeed_ = speedY;

        test = SpeedSystem.generalSpeed_;

        SEtimer += Time.deltaTime;
        SEkaiten += Time.deltaTime;
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
    //車の加減速
    float VelocityVariation(float brake = 0)
    {
        float carSpeed = 0;
        carSpeed = (acceleration+brake) * Time.deltaTime;
        return carSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit");
    }
    //壁にあたる判定
    public void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("当たり！");
        //カメラシェイク
        var inpulseSource = came.GetComponent<CinemachineImpulseSource>();
        inpulseSource.GenerateImpulse();
        //減速
        speedY -= (acceleration+30 )* Time.deltaTime;
        speedY = Mathf.Max(speedY, 0);
    }
}
