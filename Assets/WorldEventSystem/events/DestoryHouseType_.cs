using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryHouseType_:I_Event_
{
    public DestoryHouseType_()
    {
        DestoryType=Random.Range(1,HOUSE_TYPE_AMOUNT);
        event_msg="市府查獲無良建商\n"+"(房屋名 id:"+DestoryType.ToString()+")"+"全數摧毀";
        
    }
    int DestoryType;
    public int HOUSE_TYPE_AMOUNT=0;
    public override void act(CardSystem cs,Land_[] lands)
    {
        DestoryType=Random.Range(1,HOUSE_TYPE_AMOUNT);
        event_msg="市府查獲無良建商\n"+"(房屋名 id:"+DestoryType.ToString()+")"+"全數摧毀";
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
