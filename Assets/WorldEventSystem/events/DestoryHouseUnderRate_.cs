using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryHouseUnderRate_:I_Event_
{
    public float rate_barrier=0.0f;
    public override void act(CardSystem cs,Land_[] lands)
    {
        for(int u=0;u!=lands.Length;++u)
        {
            if(lands[u].get_risk()<rate_barrier)
                lands[u].data[0].risk=1.0f;
        }
    }
}
