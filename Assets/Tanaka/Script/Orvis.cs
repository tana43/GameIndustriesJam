using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�I�[�r�X
public class Orvis : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float scrollSpeed = SpeedSystem.generalSpeed_ * Time.deltaTime;

        //���x�ɍ��킹�ăI�[�r�X�����֓������Ă���
        var pos = transform.position;
        pos.y += scrollSpeed;
        transform.position = pos;
    }
}
