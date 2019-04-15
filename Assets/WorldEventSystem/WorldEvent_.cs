using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WorldEvent_ : MonoBehaviour
{
    const float add_rate = 0.2f;
    float[] add_rate_sep = new float[] { 0.7f, 0.2f, 0.1f };

    List<I_Event_> event_pool = new List<I_Event_>();
    void Start()
    {
        //initialize addcard events
        AddCards_ _add_events = new AddCards_();
        _add_events.pro=0.2f;
        event_pool.Add(_add_events);

        //initialize add destory rate events
        AddRate_ _adr_event = new AddRate_();
        _adr_event.pro = 0.7f;
        event_pool.Add(_adr_event);

        //initialize Destory house under rate event
        DestoryHouseUnderRate_ _dhur_event = new DestoryHouseUnderRate_();
        _dhur_event.pro = 0.05f;
        event_pool.Add(_dhur_event);

        //initialize Destory house type event
        DestoryHouseType_ _dht_event = new DestoryHouseType_();
        _dht_event.pro = 0.05f;
        event_pool.Add(_dht_event);
    }
    I_Event_ getEvent()
    {
        float choice = Random.Range(0.0f, 1.0f);
        float cur = 0.0f;
        for (int u = 0; u != event_pool.Count; ++u)
        {
            if (cur <= choice && choice < cur + event_pool[u].pro)
                return event_pool[u];
            cur += event_pool[u].pro;
        }
        return null;
    }
    string generateEvent()
    {
        Debug.Log("event generate");
        CardSystem cs = FindObjectOfType<CardSystem>();
        Land_[] lands = FindObjectsOfType<Land_>();
        I_Event_ _eve = getEvent();
        _eve.act(cs, lands);
        return _eve.event_msg;
    }
    bool timeblock=true;
    IEnumerator timer()
    {
        yield return new WaitForSeconds(2);
        GetComponent<Text>().text="";
        timeblock=true;
    }
    public void UpdateText()
    {
        string eve = generateEvent();
        GetComponent<Text>().text = eve;
        FindObjectOfType<PlayerOperator>().CheckLandAll();
        timeblock=false;

    }
    void Update()
    {
        if(timeblock!=true)
        {
            StartCoroutine("timer");
        }
    }
}