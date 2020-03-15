using UnityEngine;
using System.Collections;

public class SubScreenBase
{
    protected UISubCtrlBase mCtrlBase;

    public UISubCtrlBase CtrlBase { get => this.mCtrlBase; }

    public SubScreenBase(UISubCtrlBase ctrlBase)
    {
        this.mCtrlBase = ctrlBase;
        Init();
    }

    virtual protected void Init()
    {
    }

    virtual public void Dispose()
    {

    }
}
