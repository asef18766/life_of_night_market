using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryHouseType_:I_Event_
{
    public string[] str;
    public const int HouseTypeAmount=6;
    public string getHousePhisicalName(int type)
    {
        if(type>=1&&type<=HouseTypeAmount)
            return str[type-1];
        return "";
    }
    public DestoryHouseType_()
    {
        str=new string[HouseTypeAmount];
        for(int u=0;u!=HouseTypeAmount;++u)
            str[u]=new string("\0".ToCharArray());
        str[0]="大屌燒";
        str[1]="鹽水雞";
        str[2]="臭豆腐";
        str[3]="彈珠檯";
        str[4]="冬瓜茶";
        str[5]="霜淇淋";
        HOUSE_TYPE_AMOUNT=House_.HouseTypeAmount;
        DestoryType=Random.Range(1,HOUSE_TYPE_AMOUNT+1);
        event_msg="市府查獲無良建商\n含有"+getHousePhisicalName(DestoryType)+"之土地建物全數摧毀";
    }
    int DestoryType;
    public int HOUSE_TYPE_AMOUNT;
    public override void act(CardSystem cs,Land_[] lands)
    {
        DestoryType=Random.Range(1,HouseTypeAmount+1);
        event_msg="市府查獲無良建商\n含有"+getHousePhisicalName(DestoryType-1)+"之土地建物全數摧毀";
        for(int u=0;u!=lands.Length;++u)
        {
            for(int i=0;i!=lands[u].data.Count;++i)
            {
                if(lands[u].data[i].type_id==DestoryType)
                {
                    lands[u].data[i].risk=1.0f;
                }
            }
        }
    }
}
