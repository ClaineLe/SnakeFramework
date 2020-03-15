using UnityEngine;
using System.Collections;

public class GuildScreen : ScreenBase
{

    private GuildCtrl mCtrl;
    
    private GuildCreateSubScreen mSubCreate;// 创建公会界面逻辑
    private GuildInfoSubScreen mSubInfo;        // 公会详情界面逻辑

    public GuildScreen(UIOpenParamBase param = null) : base(UIConst.UIGuild) { }

    protected override void OnLoadSuccess()
    {
        base.OnLoadSuccess();
        mCtrl = mCtrlBase as GuildCtrl;
        // 有公会就打开公会详情 没有就打开创建界面
        bool bHaveGuild = Singleton<DataManager>.GetInstance().HaveGuild();
        // 处理子界面的显示隐藏
        mCtrl.subInfo.gameObject.SetActive(bHaveGuild);
        mCtrl.subCreate.gameObject.SetActive(!bHaveGuild);

        // 处理子界面逻辑初始化
        if (bHaveGuild)
        {
            mSubInfo = new GuildInfoSubScreen(mCtrl.subInfo);
        }
        else
        {
            mSubCreate = new GuildCreateSubScreen(mCtrl.subCreate);
        }

    }
}
