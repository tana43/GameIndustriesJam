using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class enemysponescript : MonoBehaviour
{
    [SerializeField] GameObject enemycar;
    [SerializeField] float spown = 1;
    [SerializeField] private Vector2 shotPoint;
    [SerializeField] float adjustment;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetMouseButtonDown(0))
        {
            spawnenemy();
        }
    }

    void spawnenemy()
    {
        
        Vector2 spawnpos;
        int random = UnityEngine.Random.Range(0, 3);
        if(random==0)
        {
            spawnpos = shotPoint;
            spawnpos.x = -adjustment;
        }
        else if(random==1)
        {
            spawnpos = shotPoint;
        }
        else
        {
            spawnpos = shotPoint;
            spawnpos.x = adjustment;
        }
        Instantiate(enemycar, spawnpos, Quaternion.Euler(0, 0, 0));
    }
}
