using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycar : MonoBehaviour
{
    [SerializeField] float movespeed = 1;
    float destroypos = -6;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos.y -= movespeed * Time.deltaTime;
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
