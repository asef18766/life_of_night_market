using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land_ : MonoBehaviour
{
    public House_ house;
    public List<House_> data;
    const float cost_rate=3.0f;
    const float profit_rate=0.1f;
    public float tmp_delta_explode_rate=0.0f;
    // Start is called before the first frame update
    Transform tf;
    void Start()
    {
        data=new List<House_>();
        tf=GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
            add_house_by_id(1,1);
        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("gain profit");
            DeltaMoney_[] dm=gain_profit();
           
            Debug.Log(dm.Length.ToString());
        }
        update_house_pos();
    }
    public float get_risk()
    {
        float ret=0.0f;
        for(int u=0;u!=data.Count;++u)
        {
            ret+=data[u].risk;
        }
        return ret+tmp_delta_explode_rate;
    }
    public float explode()
    {
        float ret=0.0f;
        for(int u=0;u!=data.Count;++u)
            ret+=(data[u].price*cost_rate);
        clear_house();
        return ret;
    }
    public DeltaMoney_[] gain_profit()
    {
        DeltaMoney_[] ret=new DeltaMoney_[data.Count];
        for(int u=0;u!=ret.Length;++u)
        {
            ret[u]=new DeltaMoney_();
        }
        for(int u=0;u!=data.Count;++u)
        {
            ret[u].owner_id=data[u].owner_id;
            ret[u].amount=data[u].price*profit_rate;
        }
        return ret;
    }
    void clear_house()
    {
        for(int u=0;u!=data.Count;++u)
            DestroyImmediate(data[u].gameObject);
        data.Clear();
    }
    void update_house_pos()
    {
        Vector3 local_pos=tf.position;
        for(int u=0;u!=data.Count;++u)
        {
            
            SpriteRenderer spr=data[u].GetComponent<SpriteRenderer>();
            Vector3 sprite_bounds=spr.bounds.size;
            float dc=data.Count+1.0f;
            float sep=u+1.0f;
            Vector3 delta=new Vector3(0,sprite_bounds.y/2,-0.5f+(1.0f/dc)*sep);
            data[u].transform.position=local_pos+delta;
        }
    }
    public void add_house_by_id(int type_id,int owner_id)
    {
        House_ h=Instantiate(house,new Vector3(0,0,0),new Quaternion());
        h.type_id=type_id;
        h.owner_id=owner_id;
        data.Add(h);
    }
}
