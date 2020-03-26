using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class ScreenBase
{
    public RectTransform mPanelRoot = null;
    public string mStrUIName = "";
    public UICtrlBase CtrlBase { get => this.mCtrlBase; }
    protected UICtrlBase mCtrlBase;

    protected UIOpenParamBase mOpenParam;


    public int mOpenOrder = 0;//界面打开顺序
    public int mSortingLayer = 0;//界面层级

    public ScreenBase(string UIName, UIOpenParamBase param = null)
    {
        StartLoad(UIName, param);
    }

    public void SetOpenOrder(int openOrder)
    {
        this.mOpenOrder = openOrder;
        if (mCtrlBase != null && mCtrlBase.ctrlCanvas != null)
        {
            this.mCtrlBase.ctrlCanvas.sortingOrder = openOrder;
        }
    }

    private void UpdateLayoutLevel()
    {
        Camera camera = Singleton<UIManager>.GetInstance().GetUICamera();
        if (camera != null)
        {
            this.mCtrlBase.ctrlCanvas.worldCamera = camera;
        }

        this.mCtrlBase.ctrlCanvas.overrideSorting = true;
        this.mCtrlBase.ctrlCanvas.sortingLayerID = (int)mCtrlBase.screenPriority;
        this.mSortingLayer = (int)mCtrlBase.screenPriority;
        this.mCtrlBase.ctrlCanvas.sortingOrder = mOpenOrder;
    }

    virtual public void StartLoad(string UIName, UIOpenParamBase param = null)
    {
        this.mStrUIName = UIName;
        this.mOpenParam = param;
        Singleton<SourceManager>.GetInstance().LoadAsset<GameObject>("Prefabs/" + UIName, PanelLoadComplete);
    }

    private ILuaPanelInterface panelInterface;
    private void BindLuaScreen() {
        string luaFileName = string.Format("{0}Panel", this.mStrUIName);
        string luaPath = string.Format("UI/Panels/{0}/{1}", this.mStrUIName, luaFileName);
        Debug.Log(luaPath);
        byte[] luaBytes = Singleton<SourceManager>.GetInstance().LoadCustomData(luaPath, ".lua");
        LuaManager luaMgr = Singleton<LuaManager>.GetInstance();
        luaMgr.DoString(luaBytes, this.mStrUIName);
        panelInterface = luaMgr.GetLuaInterface<ILuaPanelInterface>(null, luaFileName);
        panelInterface.LoadSuccess(this.mPanelRoot.gameObject, luaPath);
    }



    private void PanelLoadComplete(GameObject go) 
    {
        Debug.Log(go);
        this.mPanelRoot = GameObject.Instantiate(go, Singleton<UIManager>.GetInstance().GetCanvasRootTransform()).transform as RectTransform;
        this.mCtrlBase = this.mPanelRoot.GetComponent<UICtrlBase>();
        this.UpdateLayoutLevel();
        this.BindLuaScreen();
        this.OnLoadSuccess();
        Singleton<UIManager>.GetInstance().AddUI(this);
    }

    virtual protected void OnLoadSuccess() {
        if (mCtrlBase.m_UseMask)
            Singleton<UIManager>.GetInstance().SetupMask(this);
    }

    virtual public void OnClose()
    {
        Singleton<UIManager>.GetInstance().RemoveUI(this.mStrUIName);
    }

    virtual public void OnClickMaskArea() {
        this.OnClose();
    }

    virtual public void Dispose()
    {
        panelInterface.Release();
        GameObject.Destroy(mPanelRoot.gameObject);
    }
}