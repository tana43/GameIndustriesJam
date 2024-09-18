using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 10.0f;
    public float rotation = 30.0f;
    public float rotateSpeed=1.0f;   //�ω�����p�x
    public float rotationTwo = 0;    //��̊p�x
    public float time = 0.0f;
    [SerializeField] float timespeed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        Vector3 angle = transform.eulerAngles;

        //��������
        //���ɓ���
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= speed * Time.deltaTime;
            time += timespeed * Time.deltaTime;
            angle.z = Mathf.Lerp(rotationTwo, rotation, time);
            //angle.z = rotation;
        }
        //�E�ɓ���
        else if (Input.GetKey(KeyCode.D))
        {
            pos.x += speed * Time.deltaTime;
            time += timespeed * Time.deltaTime;
            angle.z = Mathf.Lerp(rotationTwo, -rotation, time);
            //angle.z = -rotation;
        }
        //�����L�[��������Ă��Ȃ���
        else { angle.z = 0;time = 0; }

        transform.position = pos;
        transform.eulerAngles = angle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit");
    }
}
