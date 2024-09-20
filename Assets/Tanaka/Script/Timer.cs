using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    //�^�C�}�[
    [SerializeField]
    private float timer_;

    //�^�C�}�[���X�^�[�g���Ă��邩
    public bool timerStart_;

    //�e�L�X�g�I�u�W�F�N�g
    public GameObject timerObject_ = null;

    //�g
    public GameObject timerFrameObject_ = null;

    //�_�ł��������̂ŃT�C���J�[�u���g��
    private float sinCurve_;

    //�g��U��������Ƃ��Ɏg��
    [SerializeField]
    private float frameShakePos_;

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
            timer_ -= Time.deltaTime;
            if (timer_ < 0)
            {

                //�^�C�}�[���O�̂Ƃ��͐�
                timer_ = 0;
                timerText.color = Color.red;

                // �Ó]���ă��U���g��ʂ�
                //GameObject.Find("Fade").GetComponent<FadeController>().PlayFadeOut();
            }
            else if (timer_ < 10.0f)
            {
                //�^�C�}�[���P�O�ȉ��̎��͓_�ŁA�Ԃɂ���
                timerText.color = Color.red;

                sinCurve_ += Time.deltaTime * 3.0f;

                float sin = Mathf.Sin(sinCurve_);
                sin = Mathf.Abs(sin);

                Color color = timerText.color;
                color.a = sin;
                timerText.color = color;
            }
            else
            {
                //�^�C�}�[������̂Ƃ��͔�
                timerText.color = Color.white;
            }
        }
        else
        {
            //�^�C�}�[���~�܂��Ă���Ƃ��͉��F
            timerText.color = Color.yellow;
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
    public void StartTimer()
    {
        timerStart_ = true;
    }

    //�^�C�}�[�v���I��
    public void StopTimer()
    {
        timerStart_ = false;
    }

    //�^�C�}�[���Z�b�g
    public void ResetTimer()
    {
        timer_ = 0;
        timerStart_ = false;
    }

    public void SetTimer(float time)
    {
        timer_ = time;
    }

    public float GetTimer()
    {
        return timer_;
    }
}
