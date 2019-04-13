using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardRefer : MonoBehaviour
{
    public Image UI_Image_Picture_;
    public Text UI_Text_Value_;
    public Text UI_Text_Risk_;

    public void PrintCard(int CardNumber, CardDataPool m_CardDataPool_)
    {
        UI_Image_Picture_ = transform.GetChild(0).GetComponent<Image>();
        UI_Text_Value_ = transform.GetChild(1).GetComponent<Text>();
        UI_Text_Risk_ = transform.GetChild(2).GetComponent<Text>();

        UI_Image_Picture_.sprite = m_CardDataPool_.CDPool_[CardNumber].sprite_CardArt_;
        UI_Text_Value_.text = ""+ m_CardDataPool_.CDPool_[CardNumber].int_Value_;
        UI_Text_Risk_.text = m_CardDataPool_.CDPool_[CardNumber].f_Risk_ + "%";
    }

}
