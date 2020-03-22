using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFacade : Singleton<GameFacade>
{
    public DataManager mDataMgr
    {
        get
        {
            if (this._dataMgr == null)
                this._dataMgr = Singleton<DataManager>.GetInstance();
            return this._dataMgr;
        }
    }
    private DataManager _dataMgr = null;
    
    public UIManager mUiMgr
    {
        get
        {
            if (this._uiMgr == null)
                this._uiMgr = Singleton<UIManager>.GetInstance();
            return this._uiMgr;
        }
    }
    private UIManager _uiMgr = null;
}
