using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObisManager : MonoBehaviour
{
    //�e�I�[�r�X��ݒu����ۂ̊Ԋu
    public float obisSetInterval_;

    //�I�[�r�X�̌��m���x
    public float obisBorderSpeed_;

    //�e���x�ᔽ�v���_��
    [SerializeField]
    private float speeding4Score_ = 20.0f;
    [SerializeField]
    private float speeding6Score_ = 40.0f;

    //�I�[�r�X�̐����͈�
    public float obisSpawnArea_;

    //���̃E�F�[�u�ōŏ��ɐ��������I�[�r�X�̔z�u�ʒu
    //�v���C���[���猩������
    public float spawnObisFirstPoint_;

    //�I�[�r�X�𐶐�����ۂ�X���W
    [SerializeField]
    private float spawnPosX_;

    //���������I�[�r�X��o�^���Ă���
    [SerializeField]
    private List<Obis> obisList_;

    //�I�[�r�X�̃v���n�u
    [SerializeField]
    private GameObject obisPrefab_; 

    //���ɒʉ߂���I�[�r�X�̗v�f��
    private int nextObisIndex_;

    //�E�F�[�u�V�X�e��
    [SerializeField]
    private GameObject waveSystemObject_; 
    private WaveSystem waveSystem_;

    //�Q�[���V�X�e��
    [SerializeField]
    private GameObject gameSystemObject_;
    private GameSystem gameSystem_;

    //�v���C���[
    [SerializeField]
    private GameObject playerObject_;

    // Start is called before the first frame update
    void Start()
    {
        obisList_.Clear();

        waveSystem_ = waveSystemObject_.GetComponent<WaveSystem>();
        gameSystem_ = gameSystemObject_.GetComponent<GameSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePassingObis();
    }

    //�ݒ�l�����ɃI�[�r�X��z�u���Ă���
    public void SetObis()
    {
        //������
        Initialize();

        float playerPosY = playerObject_.transform.position.y;

        //�ŏ��̈�̖ڂ��X�|�[��������
        float spawnPosY = playerPosY + spawnObisFirstPoint_;

        //�������̍��W�͂P�T�Ŋ��������炢�����x����
        AddObis(spawnPosY / 15.0f);

        float intervalSpawnPosY = spawnPosY;
        //�S�[���n�_���z����܂Ń��[�v����
        while (true)
        {
            //�����ʒu���Ԋu��������
            intervalSpawnPosY += obisSetInterval_;

            spawnPosY = intervalSpawnPosY + Random.RandomRange(-obisSpawnArea_, obisSpawnArea_);

            //�����ʒu���S�[�����z���Ă���Ȃ琶�������ɁA���[�v�𔲂���
            float dist = spawnPosY - playerPosY;
            if(dist > gameSystem_.goalPoint_)
            {
                break;
            }

            //��������
            AddObis(spawnPosY / 15.0f);
        }
    }

    //������
    void Initialize()
    {
        nextObisIndex_ = 0;

        ListClear();
    }

    //���X�g���폜���A�N���A����
    void ListClear()
    {
        foreach (var obis in obisList_)
        {
            GameObject.Destroy(obis);
        }
        obisList_.Clear();
    }

    void AddObis(float spawnPosY)
    {
        //�I�[�r�X����
        Vector2 spawnPos = new Vector2(spawnPosX_,spawnPosY);
        var obj = Instantiate(obisPrefab_, spawnPos, Quaternion.Euler(Vector3.zero));

        var obis = obj.GetComponent<Obis>();
        obis.borderSpeed = obisBorderSpeed_;
        obis.speeding4Score_ = speeding4Score_;
        obis.speeding6Score_ = speeding6Score_;

        //���X�g�ɓo�^
        obisList_.Add(obis);
    }

    //�v���C���[���ʉ߂����I�[�r�X�𔻒肵�A���̃I�[�r�X���X�V
    void UpdatePassingObis()
    {
        //�v�f�����z���Ă��Ȃ���
        if (obisList_.Count >= nextObisIndex_) return;

        //�ʉ߂��Ă���Ȃ玟�̃I�[�r�X��
        var obis = obisList_[nextObisIndex_];
        if(obis.passing_)
        {
            nextObisIndex_++;
        }
    }
}
