using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

//�R�̓��H���Ǘ�����
public class RoadCommander : MonoBehaviour
{
    //�w�i���X�N���[�������鑬�x
    public float scrollSpeed_;

    private float scrollSpeedScale_ = 0.01f;

    [SerializeField]
    private BackLoop[] roads_;

    // Start is called before the first frame update
    void Start()
    {

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
        //�e���H�I�u�W�F�N�g�̃X�N���[���l�X�V
        foreach(var road in roads_)
        {
            float speed = scrollSpeed_ * scrollSpeedScale_ * SpeedSystem.generalSpeed_;
            road.offsetSpeed_.y = speed;
        }
    }
}
