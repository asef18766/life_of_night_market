using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSystem : MonoBehaviour
{
    public GameObject gObj_Yamafuda_;
    public GameObject gObj_TefudaPannel_;
    public GameObject Prefab_Card_;
    public GameObject[] gObj_TefudaNowShowing_;
    //[玩家,手持卡片序號]
    public string[] i_PlayersTefuda_ = new string[4];
    public int[] i_ThisPlayersTefuda_;
    public int i_thisTimeYouDraw_;
    public int i_PlayerIDNow_;
    public CardDataPool m_CDP_;

    void Start()
    {
        gObj_Yamafuda_ = GameObject.Find("Yamafuda");
        gObj_TefudaPannel_ = GameObject.Find("Tefuda");
        EveryBodyDraw(5);
    }
    
    public void TurnStart(int PlayerID)
    {
        i_PlayerIDNow_ = PlayerID - 1;
        ShowYamafuda();
        ShowTefuda(i_PlayerIDNow_);
            
    }

    public void DrawCard()
    {
        int i = m_CDP_.CDPool_.ToArray().Length;
        i_thisTimeYouDraw_ = Random.Range(0, i);
        i_PlayersTefuda_[i_PlayerIDNow_] += i_thisTimeYouDraw_ + " ";
        ShowTefuda(i_PlayerIDNow_);

        /*
        GameObject NewCard_ = Instantiate(Prefab_Card_,gObj_TefudaPannel_.transform);
        NewCard_.GetComponent<CardRefer>().PrintCard(i_thisTimeYouDraw_,m_CDP_);
        */

        //gObj_Yamafuda_.SetActive(false);
    }

    public void EveryBodyDraw(int i_DrawCount_)
    {
        int i_Cards_ = m_CDP_.CDPool_.ToArray().Length;
        //選擇要給的玩家
        for (int i = 0; i < 4; i++)
        {
            //抽給他i_DrawCount_張
            for (int n = 0; n < i_DrawCount_; n++)
            {
                i_PlayersTefuda_[i] += Random.Range(0, i_Cards_)+" ";
            }
        }
    }

    public void ShowTefuda(int PlayerID)
    {
        //刪除原本的牌
        if(gObj_TefudaNowShowing_.Length != 0)
        {
            for (int m = 0; m < gObj_TefudaNowShowing_.Length; m++)
            {
                Destroy(gObj_TefudaNowShowing_[m]);
            }
        }

        //切割手牌資料，並輸入到空間
        i_ThisPlayersTefuda_ = new int[i_PlayersTefuda_[i_PlayerIDNow_].Split(null).Length-1];
        for (int n=0;n< i_PlayersTefuda_[i_PlayerIDNow_].Split(null).Length-1; n++)
        {
            i_ThisPlayersTefuda_[n] = int.Parse(i_PlayersTefuda_[i_PlayerIDNow_].Split(null)[n]);
        }

        //開啟手牌顯示
        gObj_TefudaPannel_.SetActive(true);

        //創建手牌物件
        gObj_TefudaNowShowing_ = new GameObject[i_ThisPlayersTefuda_.Length];
        for (int i = 0; i < i_ThisPlayersTefuda_.Length; i++)
        {
            gObj_TefudaNowShowing_[i] = Instantiate(Prefab_Card_, gObj_TefudaPannel_.transform);
            gObj_TefudaNowShowing_[i].GetComponent<CardRefer>().PrintCard(i_ThisPlayersTefuda_[i], m_CDP_);
        }
    }

    public void UsingCard(int CardID_)
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
            gObj_TefudaPannel_.SetActive(false);
            //Dice();
        }
    }
    
    public void ShowYamafuda()
    {
        gObj_Yamafuda_.SetActive(true);
    }
}
