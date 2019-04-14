using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardRefer : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public GameObject gObj_BeingDrag_;
    public Vector2 v2_StartPosit_;

    public Collider2D m_Collider_;
    public Image UI_Image_Picture_;
    public Text UI_Text_Value_;
    public Text UI_Text_Risk_;

    public int i_CardNumber_;
    public bool b_IsTouchPannel;

    public void PrintCard(int CardNumber, CardDataPool m_CardDataPool_)
    {
        UI_Image_Picture_ = transform.GetChild(0).GetComponent<Image>();
        UI_Text_Value_ = transform.GetChild(3).GetComponent<Text>();
        UI_Text_Risk_ = transform.GetChild(4).GetComponent<Text>();

        i_CardNumber_ = CardNumber;
        UI_Image_Picture_.sprite = m_CardDataPool_.CDPool_[CardNumber].sprite_CardArt_;
        UI_Text_Value_.text = ""+ m_CardDataPool_.CDPool_[CardNumber].int_Value_;
        UI_Text_Risk_.text = m_CardDataPool_.CDPool_[CardNumber].f_Risk_ + "%";
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        gObj_BeingDrag_ = gameObject;
        v2_StartPosit_ = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (b_IsTouchPannel)
        {
            UseThisCard();
        }
        else if (!b_IsTouchPannel)
        {
        //    transform.position = v2_StartPosit_;
        }
        gObj_BeingDrag_ = null;
        v2_StartPosit_ = new Vector2(0, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
            b_IsTouchPannel = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        b_IsTouchPannel = false;
    }

    void UseThisCard()
    {
        GameObject.Find("CardSystem").GetComponent<CardSystem>().UsingCard(i_CardNumber_);
        Destroy(this.gameObject);
    }
}
