using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XO_Player 
{
    public XO_Player(string name)
    {
        XO_name = name;
        XO_amount++;
        XO_money = 1000;
        //Debug.Log("name:"+XO_name);
        //Debug.Log("money:" + XO_money);
    }

    public string XO_name { get; set; }
    public float XO_money { get; set; }

    public static int XO_amount = 0;
}
