using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryHouseUnderRate_:I_Event_
{
    const float min_rate=0.1f;
    const float max_rate=0.5f;
    public float rate_barrier=0.0f;
    public DestoryHouseUnderRate_()
    {
        rate_barrier=Random.Range(min_rate,max_rate);
        event_msg="驚報!!水泥公司使用海砂!!\n爆炸機率"+rate_barrier.ToString()+"%以下土地房屋全毀";
    }
    public override void act(CardSystem cs,Land_[] lands)
    {
        rate_barrier=Random.Range(min_rate,max_rate);
        event_msg="驚報!!水泥公司使用海砂!!\n爆炸機率"+rate_barrier.ToString()+"%以下土地房屋全毀";
        for(int u=0;u!=lands.Length;++u)
        {
            if(lands[u].get_risk()<rate_barrier)
                lands[u].data[0].risk=1.0f;
        }
    }
}
