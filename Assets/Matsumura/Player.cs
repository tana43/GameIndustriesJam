using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

    public float speed = 10.0f;                         //x���̕ω���
    public float rotation = 30.0f;                      //�p�x
    public float startRotation = 0;                     //�p�x�̏����l
    private float oldRotation = 0.0f;                   //�O��̉�]�l
    private float moveRateVolume = 0.0f;                //�{�^����������Ă���ۂ̉�]�l
    private float stopRateVolume = 0.0f;�@              //�{�^����������Ă��Ȃ����̉�]�l
    [SerializeField] float moveRotationSpeed = 3.0f;�@  //�{�^���������ꂽ�ۂ̉�]�X�s�[�h
    [SerializeField] float ReturnRotationSpeed = 5.0f;  //�{�^����������Ă��Ȃ����̉�]�X�s�[�h
    [SerializeField] float rate = 0.0f;               �@//��]�⊮�v�Z����

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
