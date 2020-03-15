using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCityScreenParam : UIOpenParamBase
{ 

}

public class MainCityScreen : ScreenBase
{
    private MainCityCtrl mCtrl;

    public MainCityScreen(UIOpenParamBase param = null) : base(UIConst.UIMainCity) { 
    
    }

    protected override void OnLoadSuccess()
    {
        base.OnLoadSuccess();
        this.mCtrl = this.mCtrlBase as MainCityCtrl;

        this.mCtrl.btnGuild.onClick.AddListener(OnGuildClick);
    }

    private void OnGuildClick() {
        Debug.Log("OnGuildClick");
    }
}
