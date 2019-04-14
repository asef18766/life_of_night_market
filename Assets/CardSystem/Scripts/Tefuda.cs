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

    void Start()
    {
        f_CardInter_ = prefab_Card_.transform.GetChild(1).GetComponent<Image>().rectTransform.sizeDelta.x /4;
        m_CardSystem_ = GameObject.Find("CardSystem").GetComponent<CardSystem>();
    }

    void Update()
    {
        i_TefudaCountNow_ = transform.childCount;
        if(i_TefudaCountLast_ != i_TefudaCountNow_)
        {
            //RefreshCardPosit();
        }
    }

    void ShowUp()
    {

    }

    void RefreshCardPosit()
    {
        if (i_TefudaCountNow_ % 2 == 0)
        {
            for (int i = 0; i < i_TefudaCountNow_; i++)
            {
                transform.GetChild(i).transform.position =  new Vector2(transform.GetChild(i).transform.position.x + (-1^i)*i,0);
                //transform.GetChild(i).GetComponent<RectTransform>().position = new Vector2((1 + Mathf.Round(i / 2)) * (-1 ^ i) * f_CardInter_, 0);
            }
        }
        else
        {
            for (int i = 0; i < i_TefudaCountNow_; i++)
            {
                transform.GetChild(i).transform.position = new Vector2((Mathf.Round(i / 2)) * (-1 ^ i) * f_CardInter_, 0);
            }
        }
        i_TefudaCountLast_ = i_TefudaCountNow_;
    }
}
