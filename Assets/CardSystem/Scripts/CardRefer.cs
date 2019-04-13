using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardRefer : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public GameObject gObj_BeingDrag_;
    public Vector2 v2_StartPosit_;

    public Image UI_Image_Picture_;
    public Text UI_Text_Value_;
    public Text UI_Text_Risk_;

    public void PrintCard(int CardNumber, CardDataPool m_CardDataPool_)
    {
        UI_Image_Picture_ = transform.GetChild(0).GetComponent<Image>();
        UI_Text_Value_ = transform.GetChild(3).GetComponent<Text>();
        UI_Text_Risk_ = transform.GetChild(4).GetComponent<Text>();

        UI_Image_Picture_.sprite = m_CardDataPool_.CDPool_[CardNumber].sprite_CardArt_;
        UI_Text_Value_.text = ""+ m_CardDataPool_.CDPool_[CardNumber].int_Value_;
        UI_Text_Risk_.text = m_CardDataPool_.CDPool_[CardNumber].f_Risk_ + "%";
    }

    public void OnMouseDown()
    {
        transform.position = Input.mousePosition;
        Debug.Log("AA");
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
        gObj_BeingDrag_ = null;
        v2_StartPosit_ = new Vector2(0, 0);
    }


}
