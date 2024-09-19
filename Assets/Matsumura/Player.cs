using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float brake = 7;                             //�u���[�L�p
    public float acceleration = 7;                   //�����x      
    public float initialVelocity = 60;                  //����
    public float speed = 10.0f;                         //x���̕ω���
    public float speedY = 0;                            //���H�̑��x�ω���
    public float deceleration = 3.0f;                  //����
    public float rotation = 30.0f;                      //�p�x
    public float startRotation = 0;                     //�p�x�̏����l
    private float oldRotation = 0.0f;                   //�O��̉�]�l
    private float moveRateVolume = 0.0f;                //�{�^����������Ă���ۂ̉�]�l
    private float stopRateVolume = 0.0f;�@              //�{�^����������Ă��Ȃ����̉�]�l
    [SerializeField] float moveRotationSpeed = 3.0f;�@  //�{�^���������ꂽ�ۂ̉�]�X�s�[�h
    [SerializeField] float ReturnRotationSpeed = 5.0f;  //�{�^����������Ă��Ȃ����̉�]�X�s�[�h
    [SerializeField] float rate = 0.0f;               �@//��]�⊮�v�Z����

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
        // ���}�E�X�������ĉ���
        if (leftClick)
        {
            Debug.Log("����");
            speedY += acceleration * Time.deltaTime;
        }
        //�E�}�E�X����
        else if(rightClick)
        {
            speedY -= (deceleration+brake) * Time.deltaTime;
        }
        else
        {
            Debug.Log("����");
            speedY -= deceleration * Time.deltaTime;
            speedY = Mathf.Max(speedY, 0);
        }

        SpeedSystem.generalSpeed_ = speedY;

        test = SpeedSystem.generalSpeed_;

        Vector2 pos = transform.position;
        Vector3 angle = transform.eulerAngles;

        leftClick = Input.GetMouseButton(0);
        rightClick = Input.GetMouseButton(1);

        //�{�^���������ꂽ�ꍇ
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            //lerp�̊������X�V
            rate = Mathf.Clamp01(moveRateVolume += moveRotationSpeed * Time.deltaTime);
        }

        //��������
        //�����ɉ����ꂽ�ꍇ
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            angle.z = PlayerReturnRotation();
        }
        //���ɓ���
        else if (Input.GetKey(KeyCode.A))
        {
            pos.x -= speed * Time.deltaTime;
            angle.z = PlayerLeftRotation();
        }
        //�E�ɓ���
        else if (Input.GetKey(KeyCode.D))
        {
            pos.x += speed * Time.deltaTime;
            angle.z = PlayerRightRotation();
        }
        //�����L�[��������Ă��Ȃ���
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

    //�E�̉�]����
    float PlayerRightRotation()
    {
        oldRotation = -rotation;
        stopRateVolume = 0.0f;
        return Lerp(startRotation, -rotation);
    }
    //���̉�]����
    float PlayerLeftRotation()
    {
        oldRotation = rotation;
        stopRateVolume = 0.0f;
        return Lerp(startRotation, rotation);
    }
    //���ʂɖ߂��]����
    float PlayerReturnRotation()
    {
        moveRateVolume = 0;
        rate = Mathf.Clamp01(stopRateVolume += ReturnRotationSpeed * Time.deltaTime);
        return Lerp(oldRotation, 0.0f);
    }

    //�⊮�v�Z�֐�
    float Lerp(float pos, float inverse)
    {
        return Mathf.Lerp(pos, 1.0f * inverse, rate);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit");
    }
}
