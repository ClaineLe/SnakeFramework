using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public override void Init()
    {
        base.Init();

    }


    private bool mBHasGuild = false;
    public bool HaveGuild() 
    {
        return this.mBHasGuild;
    }

    public void SetHaveGuild(bool haveGuild)
    {
        this.mBHasGuild = haveGuild;
    }
}
