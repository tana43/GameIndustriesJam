using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteCar : MonoBehaviour
{
    [SerializeField] public GameObject obj;
    float angle = 0;
    Vector2 startpos;
    Vector2 targetPos;
    float lerpSpeed = 0.5f; // ラープのスピード

    // Start is called before the first frame update
    void Start()
    {
        RectTransform t = obj.GetComponent<RectTransform>();
        startpos = t.anchoredPosition;
        targetPos = startpos; // 初期ターゲットポジション
    }

    // Update is called once per frame
    void Update()
    {
        MoveUI();
    }

    void MoveUI()
    {
        RectTransform t = obj.GetComponent<RectTransform>();

        // 新しいターゲット位置を計算
        angle += 30.5f * Time.deltaTime;
        float sin = Mathf.Sin(angle);
        float cos = Mathf.Cos(angle);
        targetPos = new Vector2(startpos.x + sin * 90, startpos.y + cos * 30); // * 50で移動幅を調整

        // 現在の位置をターゲット位置に向けてラープで補間
        t.anchoredPosition = Vector2.Lerp(t.anchoredPosition, targetPos, lerpSpeed * Time.deltaTime);
    }
}
