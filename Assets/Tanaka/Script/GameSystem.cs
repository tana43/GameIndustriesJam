using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    //�Q�[���N���A
    static public bool gameClear_;

    //�E�F�[�u�V�X�e��
    public GameObject waveSystemObject_;
    private WaveSystem waveSystem_;

    //�G�l�~�[�X�|�[���V�X�e��
    public GameObject enemySpawnSystemObject_;

    public WaveSystem GetWaveSystem()
    {
        return waveSystem_;
    }

    //�S�[���܂ł̐ݒ苗��
    public float goalPoint_;

    //�i�s����
    static public float distanceTraveled_;

    //�ÓI�ϐ��m�F�p
    [SerializeField]
    private float distTravelMonitoring_;

    //���݂̃S�[���܂ł̋���
    [SerializeField]
    private float goalDistance_;

    //�ҋ@���ԁi�^�C�}�[�⋗���̍X�V�����Ȃ���ԁj
    public bool waitMode_ = false;

    //�N���A�G�t�F�N�g
    public GameObject clearEffectPrefab_;

    // Start is called before the first frame update
    void Start()
    {
        gameClear_ = false;

        waveSystem_ = waveSystemObject_.GetComponent<WaveSystem>();

        goalDistance_ = goalPoint_;
    }

    // Update is called once per frame
    void Update()
    {
        //�E�F�[�u�̍X�V
        WaveUpdate();

        //�����̍X�V
        if (!waitMode_)
        {
            TraveledUpdate();
        }
    }

    void GameClear()
    {
        gameClear_ = true;

        //�G�̐������~����
        var spawnSystem = enemySpawnSystemObject_.GetComponent<enemysponescript>();
        spawnSystem.enabled = false;

        //�N���A�G�t�F�N�g
        Instantiate(clearEffectPrefab_);
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

    //�E�F�[�u�X�V
    void WaveUpdate()
    {
        //�^�C�}�[���؂��܂ł�
        //�S�[���܂ł̋������O�ȉ��Ȃ�N���A
        if (goalDistance_ <= 0)
        {
            bool waveEnd = waveSystem_.WaveClear();

            if (waveEnd)//�S�Ă�wave���I��
            {
                GameClear();
            }
            else//����wave�֐i��
            {
                //�S�[���܂ł̋��������Z�b�g
                goalDistance_ = goalPoint_;
            }
        }
    }
    //�ҋ@��Ԃ�
    public void ToWaitMode()
    {
        waitMode_ = true;

        waveSystem_.timer_.StopTimer();
    }

    //�ҋ@��ԉ���
    public void WaitModeCancel()
    {
        waitMode_ = false;

        waveSystem_.timer_.StartTimer();
    }
}
