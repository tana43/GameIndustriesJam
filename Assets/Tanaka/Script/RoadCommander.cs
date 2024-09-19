using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

//３つの道路を管理する
public class RoadCommander : MonoBehaviour
{
    //背景をスクロールさせる速度
    public float scrollSpeed_ = 1.0f;

    private float scrollSpeedScale_ = 0.01f;

    //スクロールしている速度（静的変数）
    public static float generalScrollSpeed_;

    [SerializeField] private float generalScrollSpeedScale_ = 1.0f;

    [SerializeField]
    private BackLoop[] roads_;

    // Start is called before the first frame update
    void Start()
    {
        generalScrollSpeedScale_ = 0.22f;

        //下のはインスペクターで設定する
        //子オブジェクト（道路１レーン）を登録
        //for (int i = 0; i < transform.childCount; ++i)
        //{
        //    var child = transform.GetChild(i);
        //    roads_.Add(child.GetComponent<BackLoop>());
        //}
    }

    // Update is called once per frame
    void Update()
    {
        float speed = scrollSpeed_ * scrollSpeedScale_ * SpeedSystem.generalSpeed_;
        //各道路オブジェクトのスクロール値更新
        foreach (var road in roads_)
        {
            road.offsetSpeed_.y = speed;
        }

        //静的変数の更新
        generalScrollSpeed_ = speed;
        generalScrollSpeed_ *= generalScrollSpeedScale_;
    }
}
