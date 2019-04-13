using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryHouseType_:I_Event_
{
    public DestoryHouseType_()
    {
        event_msg="DestoryHouseType_event";
    }
    public int HOUSE_TYPE_AMOUNT=0;
    public override void act(CardSystem cs,Land_[] lands)
    {
        int DestoryType=Random.Range(1,HOUSE_TYPE_AMOUNT);
        for(int u=0;u!=lands.Length;++u)
        {
            for(int i=0;i!=lands[u].data.Count;++i)
            {
                if(lands[u].data[i].type_id==DestoryType)
                {
                    lands[u].data[i].risk=1.0f;
                    break;
                }
            }
        }
    }
}
