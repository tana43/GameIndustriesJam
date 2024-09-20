using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class enemysponescript : MonoBehaviour
{
    [SerializeField] private GameObject[] enemycar;
    [SerializeField] float spown = 1;
    [SerializeField] private Vector2 shotPoint;
    [SerializeField] float adjustment;
    [SerializeField] float adjustmentmin = 2;
    [SerializeField] float adjustmentmax = 3;
    [SerializeField] float spawntime;
    [SerializeField] float spawntimemin=1;
    [SerializeField] float spawntimemax=3;
    [SerializeField] float spawnrandom;
    float time;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       if (time>=spawnrandom)
       {
            spawnenemy();
            spawnrandom = UnityEngine.Random.Range(spawntimemin, spawntimemax);
            time = 0;
        }

        time += Time.deltaTime;
    }

    void spawnenemy()
    {
        
        Vector2 spawnpos;
        int randomcar = UnityEngine.Random.Range(0, enemycar.Length);
        int random = UnityEngine.Random.Range(0, 3);
         float randomadjustment = UnityEngine.Random.Range(adjustmentmin, adjustmentmax);
        if (random==0)
        {
            spawnpos = shotPoint;
            spawnpos.x = -randomadjustment;
        }
        else if(random==1)
        {
            spawnpos = shotPoint;
        }
        else
        {
            spawnpos = shotPoint;
            spawnpos.x = randomadjustment;
        }
        Instantiate(enemycar[randomcar], spawnpos, Quaternion.Euler(0, 0, 0));
    }
}
