using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSystem : MonoBehaviour
{
    //�ڕW�n�_�܂ł̋���
    [SerializeField]
    private float goalPoint_;

    //�i�s����
    static public float distanceTraveled_;

    //�ÓI�ϐ��m�F�p
    [SerializeField]
    private float distTravelMonitoring_;

    //�S�[���܂ł̋���
    [SerializeField]
    private float goalDistance_;

    //�^�C�}�[�̃I�u�W�F�N�g
    public GameObject TimerObject_;
    private Timer timer_;

    //�I�[�r�X�}�l�[�W���[
    public GameObject obisManagerObject_;
    private ObisManager obisManager_;

    //���݂̃E�F�[�u��
    [SerializeField]
    private int currentWave_ = 0;

    //�E�F�[�u�e�L�X�g
    [SerializeField]
    private GameObject textObject_;

    //�P��Wave�Ŏg�p����p�����[�^
    [System.Serializable]
    public struct WaveParameter
    {
        public float timeLimit_;//���Ԑ���
        public float obisSetInterval_;//�I�[�r�X��z�u����Ԋu
        public float obisFirstPoint_;//�P�߂̃I�[�r�X�܂ł̋���
    }

    //�e�E�F�[�u�ł̐ݒ�l��ێ������Ă���
    [SerializeField]
    private WaveParameter[] waveParameters_;

    //�E�F�[�u��S�ď��z������
    public bool complete_ = false;

    // Start is called before the first frame update
    void Start()
    {
        complete_ = false;

        currentWave_ = 0;

        timer_ = TimerObject_.GetComponent<Timer>();

        obisManager_ = obisManagerObject_.GetComponent<ObisManager>();

        //�E�F�[�u�P��
        NextWave();
    }

    // Update is called once per frame
    void Update()
    {
        //�����̍X�V
        TraveledUpdate();

        //�E�F�[�u�X�V
        WaveUpdate();

        //�e�L�X�g�X�V
        TextUiUpdate();
    }

    //�i�s�����̍X�V
    void TraveledUpdate()
    {
        //���݂̐i�s����
        float speed = SpeedSystem.generalSpeed_ * Time.deltaTime;

        //���v�̐i�s�������X�V
        distanceTraveled_ += speed;

        //�C���X�y�N�^�[�Ō��邽�߂Ɋm�F�p�̕ϐ���
        distTravelMonitoring_ = distanceTraveled_;

        //�S�[���܂ł̋������v�Z
        goalDistance_ -= speed;
    }

    //���̃E�F�[�u�ւ����Ƃ��ɌĂ΂��֐�
    public void NextWave()
    {
        //�E�F�[�u��i�߂�
        currentWave_++;

        //����̃E�F�[�u�̐ݒ���擾
        var wave = waveParameters_[currentWave_ - 1];

        //�e��ݒ�𔽉f
        timer_.SetTimer(wave.timeLimit_);

        //�I�[�r�X�̐ݒ�
        obisManager_.obisSetInterval_ = wave.obisSetInterval_;

        //�S�[���܂ł̋��������Z�b�g
        goalDistance_ = goalPoint_;
    }

    //�E�F�[�u�X�V����
    void WaveUpdate()
    {
        //�^�C�}�[���؂��܂ł�
        //�S�[���܂ł̋������O�ȉ��Ȃ�N���A
        if(goalDistance_ <= 0)
        {
            //���̃E�F�[�u�����擾
            int newWave = currentWave_ + 1;

            //�ݒ肳��Ă���E�F�[�u�p�����[�^�̗v�f�����z���邩����
            if(waveParameters_.Length < newWave)
            {
                //TODO:�z����Ȃ�Q�[���N���A
                //GameClear();

                complete_ = true;
            }
            else
            {
                //�z���Ȃ��Ȃ�A���̃E�F�[�u��
                NextWave();
            }
        }
    }

    //UI�X�V
    void TextUiUpdate()
    {
        Text waveText = textObject_.GetComponent<Text>();

        waveText.text = "Wave" + currentWave_.ToString();
    }
}
