using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSystem : MonoBehaviour
{
    public GameObject gObj_Yamafuda_;
    public GameObject gObj_TefudaPannel_;
    public GameObject gObj_IfContinue_;
    public GameObject Prefab_Card_;
    public GameObject[] gObj_TefudaNowShowing_;

    public string[] s_PlayersTefuda_ = new string[4];

    public int[] i_ThisPlayersTefuda_;
    public int i_thisTimeYouDraw_;
    public int i_PlayerIDNow_;

    public CardDataPool m_CDP_;

    public bool b_CanUseCard_ = false;

    void Start()
    {
        gObj_Yamafuda_ = GameObject.Find("Yamafuda");
        gObj_TefudaPannel_ = GameObject.Find("Tefuda");
        gObj_IfContinue_ = GameObject.Find("IfContinue");

        gObj_Yamafuda_.SetActive(false); 
        gObj_TefudaPannel_.SetActive(false);
        gObj_IfContinue_.SetActive(false);

        EveryBodyDraw(5);
    }

    //發牌給每個人
    public void EveryBodyDraw(int i_DrawCount_)
    {
        int i_Cards_ = m_CDP_.CDPool_.ToArray().Length;
        //選擇要給的玩家
        for (int i = 0; i < 4; i++)
        {
            //抽給他i_DrawCount_張
            for (int n = 0; n < i_DrawCount_; n++)
            {
                s_PlayersTefuda_[i] += Random.Range(0, i_Cards_) + " ";
            }
        }
    }

    //玩家回合開始叫我
    public void TurnStart(int PlayerID)
    {
        i_PlayerIDNow_ = PlayerID - 1;
        ShowYamafuda();
        ShowTefuda(i_PlayerIDNow_);
    }

    //牌組給你抽
    public void ShowYamafuda()
    {
        gObj_Yamafuda_.SetActive(true);
    }
    
    //抽卡！
    public void DrawCard()
    {
        //抽起乃
        int i = m_CDP_.CDPool_.ToArray().Length;
        i_thisTimeYouDraw_ = Random.Range(0, i);
        s_PlayersTefuda_[i_PlayerIDNow_] += i_thisTimeYouDraw_ + " ";
        ShowTefuda(i_PlayerIDNow_);

        //進入出牌階段
        CanUseCard(true);

        //關掉抽卡按鈕
        gObj_Yamafuda_.SetActive(false);
    }
    
    //用卡片
    public void UsingCard(int CardID_)
    {
        Debug.Log("Build CardID: "+ CardID_);
        
        //清除資料
        s_PlayersTefuda_[i_PlayerIDNow_] = s_PlayersTefuda_[i_PlayerIDNow_].Substring(0,s_PlayersTefuda_[i_PlayerIDNow_].Length-2);
        ShowTefuda(i_PlayerIDNow_);

        //判斷還有沒有手牌能出
        if (i_ThisPlayersTefuda_.Length >= 1)
        {
            gObj_IfContinue_.SetActive(true);
            CanUseCard(false);
        }
        else if(i_ThisPlayersTefuda_.Length <= 0 )
        {
            CardPhaseEnd();
        }
    }

    //接收是否繼續出牌
    public void IfContinue(bool b_TorF_)
    {
        if (b_TorF_)
        {
            Debug.Log("Check");
            Debug.Log("Finished");
            CanUseCard(true);
        }
        else if(!b_TorF_)
        {
            CardPhaseEnd();
        }
        gObj_IfContinue_.SetActive(false);
    }

    //重整手牌UI
    public void ShowTefuda(int PlayerID)
    {
        //刪除原本的牌
        if (gObj_TefudaNowShowing_.Length != 0)
        {
            for (int m = 0; m < gObj_TefudaNowShowing_.Length; m++)
            {
                Destroy(gObj_TefudaNowShowing_[m]);
            }
        }

        //切割手牌資料，並輸入到空間
        i_ThisPlayersTefuda_ = new int[s_PlayersTefuda_[i_PlayerIDNow_].Split(null).Length - 1];
        for (int n = 0; n < s_PlayersTefuda_[i_PlayerIDNow_].Split(null).Length - 1; n++)
        {
            i_ThisPlayersTefuda_[n] = int.Parse(s_PlayersTefuda_[i_PlayerIDNow_].Split(null)[n]);
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

    public void CanUseCard(bool IfTorF)
    {
        b_CanUseCard_ = IfTorF;
    }

    //卡片操作結束
    public void CardPhaseEnd()
    {
        gObj_TefudaPannel_.SetActive(false);
        Debug.Log("Dice");
    }
}
