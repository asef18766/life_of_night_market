using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRate_:I_Event_
{
    public AddRate_()
    {
        AddExplodeRate=Random.Range(min_rate,max_rate);
        event_msg="大地震發生!!!\n場地上爆炸機率增加"+((int)(AddExplodeRate/0.01f)).ToString()+"%";
    }
    const float min_rate=0.05f;
    const float max_rate=0.3f;
    float AddExplodeRate=0.0f;
    public override void act(CardSystem cs,Land_[] lands)
    {
        AddExplodeRate=Random.Range(min_rate,max_rate);
        event_msg="大地震發生!!!\n場地上爆炸機率增加"+((int)(AddExplodeRate/0.01f)).ToString()+"%";
        for(int u=0;u!=lands.Length;++u)
            lands[u].tmp_delta_explode_rate=AddExplodeRate;
    }
}
