using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public float goalPoint_;//�ڕW�n�_�܂ł̋���

    static public float distanceTraveled_;

    //�P��Wave�Ŏg�p����p�����[�^
    struct WaveParameter
    {
        float timeLimit_;//���Ԑ���
        float obisSetInterval_;//�I�[�r�X��z�u����Ԋu
        float obisFirstPoint_;//�P�߂̃I�[�r�X�܂ł̋���
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
