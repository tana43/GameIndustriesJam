using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random4 : MonoBehaviour
{
    [SerializeField] public GameObject obj;
    bool trigger = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger)
        {
            RectTransform t = obj.GetComponent<RectTransform>();

            // ランダムな方向に弾き飛ばすためにランダムなベクトルを生成
            float randomX = Random.Range(10f, 150f); // ランダムなX方向の力
            float randomY = Random.Range(10f, 150f); // ランダムなY方向の力
            Vector2 randomDirection = new Vector2(randomX, randomY);

            // 位置をランダムに弾き飛ばす
            t.anchoredPosition += randomDirection * 0.5f;

            // ランダムな回転角度を加える
            float randomAngle = Random.Range(0f, 360f);
            t.Rotate(new Vector3(0, 0, randomAngle)); // Z軸回転（2Dのため）

            // 回転の結果を即座に反映
            t.localRotation = Quaternion.Euler(0, 0, t.localRotation.eulerAngles.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        trigger = true;
    }
}
