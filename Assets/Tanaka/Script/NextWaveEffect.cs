using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextWaveEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject waveObject_;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //�e�L�X�g�X�V
        Text waveText = waveObject_.GetComponent<Text>();
        waveText.text = WaveSystem.currentWave_.ToString();
    }

    //�A�j���[�V�����Đ���̏��ŗp�֐�
    void Disappearance()
    {
        GameObject.Destroy(gameObject);
    }
}
