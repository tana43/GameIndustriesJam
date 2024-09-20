using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycar : MonoBehaviour
{
    [SerializeField] public float movespeed = 0;
    [SerializeField] int minspeed = 1;
    [SerializeField] int maxspeed = 5;
    [SerializeField]  private GameObject player;
    float destroypos = -6;
    int random = 0;

    public float pspeed;

    Vector2 initialPos;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
        movespeed = UnityEngine.Random.Range(minspeed, maxspeed);
    }

    // Update is called once per frame
    void Update()
    {
        pspeed = SpeedSystem.generalSpeed_ / 10.0f;

        Vector2 pos = transform.position;
        pos.y -= ((float)movespeed + pspeed) * Time.deltaTime;

        //pos.x = initialPos.x * Mathf.Sin(pspeed * Time.deltaTime);

        transform.position = pos;

        // è¡ãé
        if (transform.position.y < destroypos)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
    }
}
