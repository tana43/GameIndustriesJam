using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    //�^�C�}�[
    private float timer_;

    //�^�C�}�[���X�^�[�g���Ă��邩
    public bool timerStart_;

    public GameObject timerObject_ = null;//�e�L�X�g�I�u�W�F�N�g

    // Start is called before the first frame update
    void Start()
    {
        timerStart_ = true;
    }

    // Update is called once per frame
    void Update()
    {
        Text timerText = timerObject_.GetComponent<Text>();

        //�^�C�}�[�X�V
        if (timerStart_)
        {
            timer_ += Time.deltaTime;
        }

        //00:00:00�@����Ȋ����ɂȂ�悤�ɂ���
        //�^�C�}�[�\����񌅂��擾

        //���Q��
        int intTimer = (int)(timer_ * 100.0f);

        //�U���܂łO����
        string time = intTimer.ToString();
        time = time.PadLeft(6, '0');
        time = time.Insert(4, ":");
        time = time.Insert(2, ":");

        //�e�L�X�g�̕\�������ւ���
        timerText.text = time;
    }

    //�^�C�}�[�v���J�n
    void StartTimer()
    {
        timerStart_ = true;
    }

    //�^�C�}�[�v���I��
    void StopTimer()
    {
        timerStart_ = false;
    }

    //�^�C�}�[���Z�b�g
    void ResetTimer()
    {
        timer_ = 0;
        timerStart_ = false;
    }
}
