using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCards_:I_Event_
{
    public AddCards_()
    {
        AddCardAmount=Random.Range(1,3);
        event_msg="台灣發大財!!!\n所有玩家增加"+AddCardAmount.ToString()+"張手卡";
    }
    public int AddCardAmount=0;
    public override void act(CardSystem cs,Land_[] lands)
    {
        AddCardAmount=Random.Range(1,3);
        event_msg="台灣發大財!!!\n所有玩家增加"+AddCardAmount.ToString()+"張手卡";
        cs.EveryBodyDraw(AddCardAmount);
    }
}
