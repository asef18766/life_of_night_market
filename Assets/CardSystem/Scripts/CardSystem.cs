using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSystem : MonoBehaviour
{
    public GameObject gObj_Yamafuda_;
    public GameObject gObj_Tefuda_;
    public GameObject Prefab_Card_;
    //[玩家,手持卡片序號]
    public int[] i_WhoseCardCount_;
    public int i_thisTimeYouDraw_;
    public CardDataPool m_CDP_;

    void Start()
    {
        gObj_Yamafuda_ = GameObject.Find("Yamafuda");
        gObj_Tefuda_ = GameObject.Find("Tefuda");
    }
    
    public void DrawCard()
    {
        int i = m_CDP_.CDPool_.ToArray().Length;
        i_thisTimeYouDraw_ = Random.Range(0, i);
        GameObject NewCard_ = Instantiate(Prefab_Card_,gObj_Tefuda_.transform);
        NewCard_.GetComponent<CardRefer>().PrintCard(i_thisTimeYouDraw_,m_CDP_);

        //gObj_Yamafuda_.SetActive(false);
    }

    public void ShowTefuda(string PlayerID)
    {
        gObj_Tefuda_.SetActive(true);
        Instantiate(Prefab_Card_, gObj_Tefuda_.transform);
    }

    public void UsingCard()
    {

    }

    public void IfContinue(bool b_TorF_)
    {
        if (b_TorF_)
        {
            //Check();
            ShowYamafuda();
        }
        else if(!b_TorF_)
        {
            gObj_Tefuda_.SetActive(false);
            //Dice();
        }
    }
    
    public void ShowYamafuda()
    {
        gObj_Yamafuda_.SetActive(true);
    }
}
