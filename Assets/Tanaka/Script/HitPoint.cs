using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitPoint : MonoBehaviour
{
    //�h���C�o�[�I�u�W�F�N�g
    public GameObject driverObject_;
    private Driver driverScript_;

    public GameObject hpTextObject_ = null;//�e�L�X�g�I�u�W�F�N�g

    // Start is called before the first frame update
    void Start()
    {
        driverScript_ = driverObject_.GetComponent<Driver>();
    }

    // Update is called once per frame
    void Update()
    {
        Text timerText = hpTextObject_.GetComponent<Text>();

        //HP��\��
        timerText.text = driverScript_.hp_.ToString();

        //����ł���e�L�X�g�Ԃɂ���
        if(driverScript_.die_)
        {
            timerText.color = Color.red;
        }
    }
}
