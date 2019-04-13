using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRate_:I_Event_
{
    const float min_rate=0.05f;
    const float max_rate=0.3f;
    public override void act(CardSystem cs,Land_[] lands)
    {
        float AddExplodeRate=Random.Range(min_rate,max_rate);
        for(int u=0;u!=lands.Length;++u)
            lands[u].tmp_delta_explode_rate=AddExplodeRate;
    }
}
