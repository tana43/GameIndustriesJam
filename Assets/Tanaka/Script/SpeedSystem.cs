using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedSystem : MonoBehaviour
{
    //�v���C���[�̑��x������
    public static float generalSpeed_;

    //�C���X�y�N�^�[��œ��������߂̉��̑��x
    [SerializeField]
    private float protoSpeed_ = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        //generalSpeed_ = protoSpeed_;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        generalSpeed_ = protoSpeed_;
    }
}
