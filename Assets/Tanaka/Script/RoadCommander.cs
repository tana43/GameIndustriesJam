using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

//３つの道路を管理する
public class RoadCommander : MonoBehaviour
{
    //背景をスクロールさせる速度
    public float scrollSpeed_;

    private float scrollSpeedScale_ = 0.01f;

    [SerializeField]
    private BackLoop[] roads_;

    // Start is called before the first frame update
    void Start()
    {

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
        //各道路オブジェクトのスクロール値更新
        foreach(var road in roads_)
        {
            float speed = scrollSpeed_ * scrollSpeedScale_ * SpeedSystem.generalSpeed_;
            road.offsetSpeed_.y = speed;
        }
    }
}
