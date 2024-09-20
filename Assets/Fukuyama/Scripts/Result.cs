using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public struct ResultScore
    {
        public int wave;
        public float time;
    }
    public static List<ResultScore> resultScores = new List<ResultScore>(); 

    public static float maxWave;
    public static float maxSpeed;

    public Text maxSpeedText;
    public Text resultText;

    // Start is called before the first frame update
    void Start()
    {       
        if (maxSpeedText == null) return;
        if (resultText == null) return;

        maxSpeedText.text = "";
        resultText.text = "";

        // �ō���
        maxSpeedText.text += $"{"maxspeed:" + SpeedSystem.generalSpeed_}\r\n";

        // wave�ƃ^�C��
        foreach (ResultScore score in resultScores)
        {
            resultText.text += $"{"wave:" + score.wave + ":" + score.time.ToString("N2")}\r\n";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject.Find("Fade").GetComponent<FadeController>().PlayFadeOut();
        }
    }

    // �E�F�[�u���̎擾
    public static void SetMaxWave(int wave)
    {
        maxWave = wave;
    }

    // ���U���g�̎擾
    public static void SetResult(int wave, float time)
    {
        resultScores.Add(new ResultScore { wave = wave, time = time });
    }

    // �ō����̎擾
    public static void SetMaxSpeed(float speed)
    {
        if (speed > maxSpeed)
        {
            maxSpeed = speed;
        }
    }
}
