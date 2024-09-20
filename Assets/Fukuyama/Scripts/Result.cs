using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
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

    public Text resultText;

    // Start is called before the first frame update
    void Start()
    {
        resultText.text = "";

        // �e�X�g
        SetResult(1, 20);
        SetResult(2, 40);
        SetResult(3, 55);

        if (resultText == null) return;
        foreach (ResultScore score in resultScores)
        {
            resultText.text += $"{"wave:" + score.wave + ":" + score.time}\r\n";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �E�F�[�u���̎擾
    public void SetMaxWave(int wave)
    {
        maxWave = wave;
    }

    // ���U���g�̎擾
    public void SetResult(int wave, float time)
    {
        resultScores.Add(new ResultScore { wave = wave, time = time });
    }

    // �ō����̎擾
    public void SetMaxSpeed(float speed)
    {
        if (speed > maxSpeed)
        {
            maxSpeed = speed;
        }
    }
}
