using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Driver : MonoBehaviour
{
    //�̗́i�ᔽ�_���@6�_�܂Łj
    public int hp_ = 0;

    //����ł��邩
    public bool die_ = false;

    //�Ƌ���~�܂ł̃X�R�A
    private const int licenseSuspensionScore = 6;

    //�ƒ�G�t�F�N�g�̃v���n�u
    [SerializeField]
    private GameObject LatterEffectPrefab_;

    //�G�t�F�N�g�͍Đ��ς�
   private bool playedEffect_ = false;
 
    // Start is called before the first frame update
    void Start()
    {
        die_ = false;
    }

    // Update is called once per frame
    void Update()
    {
        LicenseSuspensionUpdate();
    }

    //�ᔽ�s�ׂ�����
    public void Violation(int score)
    {
        //���ɖƒ₩ 
        if (die_) return;

        hp_ += score;

        //�ƒ₵�Ă��Ȃ���
        DieCheck();
    }

    //���S���Ă��邩
    void DieCheck()
    {
        //�ƒ�ɂȂ��Ă��Ȃ���
        if (hp_ >= licenseSuspensionScore)
        {
            Die();
        }
    }

    //���S
    void Die()
    {
        die_ = true;


    }

    //�ƒ≉�o
    async void LicenseSuspensionUpdate()
    {
        if (!die_) return;

        //Time.timeScale -= Time.deltaTime;
        //if (Time.timeScale < 0.1f)
    
        if(!playedEffect_)
        {
            Instantiate(LatterEffectPrefab_);
            playedEffect_ = true;

            await Task.Delay(200);  //�Ó]����܂ő҂�
            // �Ó]���ă��U���g��ʂ�
            GameObject.Find("Fade").GetComponent<FadeController>().PlayFadeOut();
        }
    }
}
