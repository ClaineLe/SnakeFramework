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

        mCtrl.AutoRelease(Singleton<EventManager>.GetInstance().OnGuildCreated.Subscribe(this.OnGuildCreated));
        // 有公会就打开公会详情 没有就打开创建界面
        bool bHaveGuild = Singleton<DataManager>.GetInstance().HaveGuild();
        this.OnGuildCreated(bHaveGuild);
    }

    private void OnGuildCreated(bool created) {
        // 这里可以直接从PlayerData拿数据，也可以通过参数传递进来，就看你定义的时候是否给事件定义参数了
        //bCreated = PlayerData.GetInstance().HaveGuild();
        // 处理子界面的显示隐藏
        mCtrl.subInfo.gameObject.SetActive(created);
        mCtrl.subCreate.gameObject.SetActive(!created);

        // 处理子界面逻辑初始化
        if (created)
        {
            mSubInfo = new GuildInfoSubScreen(mCtrl.subInfo);
}
        else
        {
            mSubCreate = new GuildCreateSubScreen(mCtrl.subCreate);
        }
    
    }
}
