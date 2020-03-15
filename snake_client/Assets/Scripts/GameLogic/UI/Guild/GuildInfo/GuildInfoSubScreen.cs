using UnityEngine;
using System.Collections;

public class GuildInfoSubScreen : SubScreenBase
{

    GuildInfoSubCtrl mCtrl;// 创建公会子控件

    public GuildInfoSubScreen(GuildInfoSubCtrl subCtrl) : base(subCtrl)
    {

    }

    protected override void Init()
    {
        mCtrl = mCtrlBase as GuildInfoSubCtrl;
        mCtrl.btnClose.onClick.AddListener(OnCloseClick);
    }

    void OnCloseClick()
    {
        Singleton<UIManager>.GetInstance().CloseUI(typeof(GuildScreen));
    }
}
