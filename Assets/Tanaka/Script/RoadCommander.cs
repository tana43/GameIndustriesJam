using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

//�R�̓��H���Ǘ�����
public class RoadCommander : MonoBehaviour
{
    //�w�i���X�N���[�������鑬�x
    public float scrollSpeed_ = 1.0f;

    private float scrollSpeedScale_ = 0.01f;

    //�X�N���[�����Ă��鑬�x�i�ÓI�ϐ��j
    public static float generalScrollSpeed_;

    [SerializeField] private float generalScrollSpeedScale_ = 1.0f;

    [SerializeField]
    private BackLoop[] roads_;

    // Start is called before the first frame update
    void Start()
    {
        generalScrollSpeedScale_ = 0.22f;

        //���̂̓C���X�y�N�^�[�Őݒ肷��
        //�q�I�u�W�F�N�g�i���H�P���[���j��o�^
        //for (int i = 0; i < transform.childCount; ++i)
        //{
        //    var child = transform.GetChild(i);
        //    roads_.Add(child.GetComponent<BackLoop>());
        //}
    }

    // Update is called once per frame
    void Update()
    {
        float speed = scrollSpeed_ * scrollSpeedScale_ * SpeedSystem.generalSpeed_;
        //�e���H�I�u�W�F�N�g�̃X�N���[���l�X�V
        foreach (var road in roads_)
        {
            road.offsetSpeed_.y = speed;
        }

        //�ÓI�ϐ��̍X�V
        generalScrollSpeed_ = speed;
        generalScrollSpeed_ *= generalScrollSpeedScale_;
    }
}
