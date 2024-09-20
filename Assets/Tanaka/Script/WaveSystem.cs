using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSystem : MonoBehaviour
{
    //�^�C�}�[�̃I�u�W�F�N�g
    public GameObject TimerObject_;
    public Timer timer_;

    //�I�[�r�X�}�l�[�W���[
    public GameObject obisManagerObject_;
    private ObisManager obisManager_;

    //�Q�[���V�X�e��
    public GameObject gameSystemObject_;
    private GameSystem gameSystem_;

    //���݂̃E�F�[�u��
    static public int currentWave_ = 0;

    //�E�F�[�u�e�L�X�g
    [SerializeField]
    private GameObject textObject_;

    //�E�F�[�u�G�t�F�N�g
    [SerializeField]
    private GameObject nextWaveEffectPrefab_;

    //�E�F�[�u���オ�����Ƃ��ɑҋ@���鎞��
    [SerializeField]
    private float nextWaveWaitTime_ = 2.0f;
    private float nextWaveWaitTimer_ = 0.0f;

    //�P��Wave�Ŏg�p����p�����[�^
    [System.Serializable]
    public struct WaveParameter
    {
        public float timeLimit_;//���Ԑ���
        public float obisSetInterval_;//�I�[�r�X��z�u����Ԋu
        public float obisFirstPoint_;//�P�߂̃I�[�r�X�܂ł̋���

        //public float borderSpeed_;//�ᔽ���x

        public float obisSpawnArea_;//�I�[�r�X�̐����͈́i20�̏ꍇ�A�{�����������ʒu����O��Q�O�ȓ��ɐ��������j
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

        gameSystem_ = gameSystemObject_.GetComponent<GameSystem>();

        nextWaveWaitTimer_ = 0.0f;

        //�E�F�[�u�P��
        NextWave();
    }

    // Update is called once per frame
    void Update()
    {   
        //�e�L�X�g�X�V
        TextUiUpdate();

        //�ҋ@��Ԃ̍X�V
        UpdateWaitTime();
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
        obisManager_.spawnObisFirstPoint_ = wave.obisFirstPoint_;
        obisManager_.obisSpawnArea_ = wave.obisSpawnArea_;

        //�I�[�r�X�}�l�[�W���[����I�[�r�X�ݒu
        obisManager_.SetObis();

        //�G�t�F�N�g�Đ�
        Instantiate(nextWaveEffectPrefab_, Vector2.zero, Quaternion.Euler(Vector3.zero));

        //�ҋ@�^�C�}�[���Z�b�g
        nextWaveWaitTimer_ = 0.0f;


        //�Q�[���V�X�e����ҋ@��
        gameSystem_.ToWaitMode();
    }

    //�E�F�[�u���N���A ����wave������Ȃ�false,�Ȃ��Ȃ�true
    public bool WaveClear()
    {
        // ���U���g�̃X�R�A�X�V
        Result.SetResult(currentWave_, timer_.GetTimer());

        //���̃E�F�[�u�����擾
        int newWave = currentWave_ + 1;

        //�ݒ肳��Ă���E�F�[�u�p�����[�^�̗v�f�����z���邩����
        if(waveParameters_.Length < newWave)
        {
            //TODO:�z����Ȃ�Q�[���N���A
            //GameClear();

            complete_ = true;

            return true;
        }
        else
        {
            //�z���Ȃ��Ȃ�A���̃E�F�[�u��
            NextWave();

            return false;
        }
    }

    //UI�X�V
    void TextUiUpdate()
    {
        Text waveText = textObject_.GetComponent<Text>();

        waveText.text = currentWave_.ToString();
    }

    void UpdateWaitTime()
    {
        //�ҋ@��ԂłȂ��̂Ȃ珈�����Ȃ�
        if (!gameSystem_.waitMode_) return;

        if(nextWaveWaitTimer_ > nextWaveWaitTime_)
        {
            //�ҋ@������
            gameSystem_.WaitModeCancel();
        }

        nextWaveWaitTimer_ += Time.deltaTime;
    }
}
