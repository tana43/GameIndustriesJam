using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public float goalPoint_;//目標地点までの距離

    static public float distanceTraveled_;

    //１つのWaveで使用するパラメータ
    struct WaveParameter
    {
        float timeLimit_;//時間制限
        float obisSetInterval_;//オービスを配置する間隔
        float obisFirstPoint_;//１つめのオービスまでの距離
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
