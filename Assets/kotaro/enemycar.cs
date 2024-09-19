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

    // Start is called before the first frame update
    void Start()
    {
        movespeed = UnityEngine.Random.Range(minspeed, maxspeed);
    }

    // Update is called once per frame
    void Update()
    {
        

        Vector2 pos = transform.position;
        pos.y -= (float)movespeed +player.GetComponent<Player>().speedY * Time.deltaTime;
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
