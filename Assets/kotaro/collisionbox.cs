using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionbox : MonoBehaviour
{
    [SerializeField] private float time = 0; 
    private bool collisionflag = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(collisionflag)
        {
            transform.parent.GetComponent<enemycar>().movespeed = Mathf.Lerp( transform.parent.GetComponent<enemycar>().movespeed, 1, time);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemycar")
        {
            Debug.Log("hit");
            collisionflag = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        time = time + Time.deltaTime/20;
    }
}