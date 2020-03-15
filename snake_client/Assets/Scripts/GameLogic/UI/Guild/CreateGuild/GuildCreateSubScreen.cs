using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuildCreateSubScreen : SubScreenBase
{
    GuildCreateSubCtrl mCtrl;// 创建公会子控件

    public GuildCreateSubScreen(GuildCreateSubCtrl subCtrl) : base(subCtrl)
    {
    }

    protected override void Init()
    {
        mCtrl = mCtrlBase as GuildCreateSubCtrl;

        mCtrl.btnCreate.onClick.AddListener(OnCreateClick);
        mCtrl.btnClose.onClick.AddListener(OnCloseClick);
    }

    void OnCreateClick()
    {
        Singleton<DataManager>.GetInstance().SetHaveGuild(true);
    }

    void OnCloseClick()
    {
        Singleton<UIManager>.GetInstance().CloseUI(typeof(GuildScreen));
    }
}
