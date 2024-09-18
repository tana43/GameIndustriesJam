using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obis : MonoBehaviour
{
    public float borderSpeed = 90.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
        }

        // ���x��25km�ȏォ�A40km�����Ȃ�
        if (speed >= 25 && speed < 40)
        {
            Debug.Log("�R�_");
            //HP-=3;
        }

        // ���x��40km�ȏォ�A50km�����Ȃ�
        if (speed >= 40 && speed < 50)
        {
            Debug.Log("�T�_");
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

        HP-= CheckSpeed(scoreSpeed);
    }
}
