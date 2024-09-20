using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeResult : MonoBehaviour
{
    [SerializeField] GameObject letter;
    [SerializeField] GameObject fade;

    // Update is called once per frame
    void Update()
    {
        // �A�j���[�V�����I���őJ��
        if (letter.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            fade.GetComponent<FadeController>().PlayFadeOut();
        }
    }
}
