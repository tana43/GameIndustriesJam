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
    public GameObject driverObject_;
    private Driver driverScript_;

    // Start is called before the first frame update
    void Start()
    {
        driverScript_ = driverObject_.GetComponent<Driver>();
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
        // ���x��20km�����Ȃ�
        if (speed < 20)
        {
            Debug.Log("�P�_");
            return 1;
            //HP-=1;
        }

        // ���x��20km�ȏォ�A25km�����Ȃ�
        if (speed >= 20 && speed < 25)
        {
            Debug.Log("�Q�_");
            //HP-=2;
            return 2;
        }

        // ���x��25km�ȏォ�A40km�����Ȃ�
        if (speed >= 25 && speed < 40)
        {
            Debug.Log("�R�_");
            //HP-=3;
            return 3;
        }

        // ���x��40km�ȏォ�A50km�����Ȃ�
        if (speed >= 40 && speed < 50)
        {
            Debug.Log("�T�_");
            return 5;
            //HP-=5;
        }

        return 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float carSpeed = collision.gameObject.GetComponent<Player>().speedY;

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
            //�h���C�o�[�Ɉᔽ�_�����Ȃ�
            driverScript_.Violation(score);
        }
    }
}
