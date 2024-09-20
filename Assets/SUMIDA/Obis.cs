using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obis : MonoBehaviour
{
    public float borderSpeed = 90.0f;
    private bool collisionflag = false;

    //�G�t�F�N�g�v���n�u
    public GameObject flashEffectPrefab_;

    //�h���C�o�[
    private GameObject driverObject_;
    private Driver driverScript_;

    //�e���x�ᔽ�v���_��
    public float speeding4Score_ = 20.0f;
    
    public float speeding6Score_ = 40.0f;

    //�v���C���[�͒ʉ߂�����
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
        //���x�ɍ��킹�ăI�[�r�X�����֓������Ă���
        var pos = transform.position;
        pos.y -= RoadCommander.generalScrollSpeed_;
        transform.position = pos;

        //effect�e�X�g
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //flasheffect����
            Instantiate(flashEffectPrefab_, transform.position, Quaternion.Euler(Vector3.zero));
        }
    }

    private int CheckSpeed(float speed) 
    {
        // �ᔽ���x���v��
        if (speed < speeding4Score_)
        {
            Debug.Log("2�_");
            return 2;
            //HP-=1;
        }
        else if (speed < speeding6Score_)
        {
            Debug.Log("4�_");
            //HP-=2;
            return 4;
        }

        // ���x��25km�ȏォ�A40km�����Ȃ�
        //if (speed >= 25 && speed < 40)
        //{
        //    Debug.Log("�R�_");
        //    //HP-=3;
        //    return 3;
        //}

        // ���x��40km�ȏ�Ȃ�
        //if (speed >= 40)
        //{
        //    Debug.Log("6�_");
        //    return 6;
        //    //HP-=5;
        //}

        Debug.Log("6�_");

        return 6;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if(!player)return;

        float carSpeed = collision.gameObject.GetComponent<Player>().speedY;

        //�v���C���[�̒ʉ߂����m
        PlayerPassing();

        float scoreSpeed = carSpeed - borderSpeed;

        if (scoreSpeed <= 0)
        {
            return;
        }

        int score = CheckSpeed(scoreSpeed);
        if (score > 0)
        {
            //flashEffect����
            Instantiate(flashEffectPrefab_, transform.position, Quaternion.Euler(Vector3.zero));
        }

        if (collision.gameObject.tag == "enemycar")
        {
            Debug.Log("hit");
            collisionflag = true;
        }

        //�h���C�o�[�Ɉᔽ�_�����Ȃ�
        driverScript_.Violation(score);
    }

    //�v���C���[���ʉ߂���
    void PlayerPassing()
    {
        passing_ = true;

        //�Z���T�[�o�[�̐F��ύX
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
