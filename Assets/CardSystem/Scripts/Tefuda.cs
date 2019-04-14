using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tefuda : MonoBehaviour
{
    public float f_CardInter_;
    public GameObject prefab_Card_;
    public CardSystem m_CardSystem_;
    public int i_TefudaCountNow_;
    public int i_TefudaCountLast_;
    public bool b_CanUseCard_;
    public Transform[] trans_CardPosit_ = new Transform[9];

    void Start()
    {
        f_CardInter_ = prefab_Card_.transform.GetChild(1).GetComponent<Image>().rectTransform.sizeDelta.x /4;
        m_CardSystem_ = GameObject.Find("CardSystem").GetComponent<CardSystem>();
    }

    void Update()
    {
        //隨時更新能不能出牌
        b_CanUseCard_ = m_CardSystem_.b_CanUseCard_;
        
        //隨時更新現在手牌數，若有更新會整理手牌位置
        i_TefudaCountNow_ = transform.childCount;
        if(i_TefudaCountLast_ != i_TefudaCountNow_)
        {
            RefreshCardPosit();
        }
    }

    void RefreshCardPosit()
    {
        for (int i = 0; i < i_TefudaCountNow_; i++)
        {
            transform.GetChild(i).transform.position = trans_CardPosit_[i].position;
        }
        i_TefudaCountLast_ = i_TefudaCountNow_;
    }
}