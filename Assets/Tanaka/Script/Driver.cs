using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    //�̗́i�ᔽ�_���@6�_�܂Łj
    public int hp_ = 0;

    //����ł��邩
    public bool die_ = false;

    //�Ƌ���~�܂ł̃X�R�A
    private const int licenseSuspensionScore = 6;

    // Start is called before the first frame update
    void Start()
    {
        die_ = false;
    }

    // Update is called once per frame
    void Update()
    {
        //�Ƌ���~�������o
        
    }

    void DieUpdate()
    {
        //�ƒ�ɂȂ��Ă��Ȃ���
        if(hp_ >= licenseSuspensionScore)
        {

        }
    }
}
