using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class UIPanel
{
    public RectTransform mPanelRoot = null;
    public string mStrUIName = "";
    private string mLuaPath;

    private ILuaPanelInterface panelInterface;

    public int mPriority { get => this.panelInterface.GetPriority(); }
    public bool mUseMask { get => this.panelInterface.GetUseMask(); }
    public bool mAlwaysShow { get => this.panelInterface.GetAlwaysShow(); }
    public bool mHideOtherScreenWhenThisOnTop { get => this.panelInterface.GetHideOtherScreenWhenThisOnTop(); }

    public Canvas ctrlCanvas { get; private set; }

    public int mOpenOrder = 0;//界面打开顺序
    public int mSortingLayer = 0;//界面层级

    public UIPanel(string UIName)
    {
        StartLoad(UIName);
    }

    public void SetOpenOrder(int openOrder)
    {
        this.mOpenOrder = openOrder;
        if (panelInterface != null && ctrlCanvas != null)
        {
            this.ctrlCanvas.sortingOrder = openOrder;
        }
    }

    private void UpdateLayoutLevel()
    {
        Camera camera = Singleton<UIManager>.GetInstance().GetUICamera();
        if (camera != null)
        {
            this.ctrlCanvas.worldCamera = camera;
        }

        this.ctrlCanvas.overrideSorting = true;
        this.ctrlCanvas.sortingLayerID = mPriority;
        this.mSortingLayer = this.ctrlCanvas.sortingLayerID;
        this.ctrlCanvas.sortingOrder = mOpenOrder;
    }

    public void StartLoad(string UIName)
    {
        this.mStrUIName = UIName;
        string luaFileName = string.Format("{0}Panel", this.mStrUIName);
        mLuaPath = string.Format("UI/Panels/{0}/{1}", this.mStrUIName, luaFileName);
        byte[] luaBytes = Singleton<SourceManager>.GetInstance().LoadCustomData(mLuaPath, ".lua");
        LuaManager luaMgr = Singleton<LuaManager>.GetInstance();
        luaMgr.DoString(luaBytes, this.mStrUIName);
        Debug.Log("luaFileName:" + luaFileName);
        panelInterface = luaMgr.GetLuaInterface<ILuaPanelInterface>(null, luaFileName);
        Singleton<SourceManager>.GetInstance().LoadAsset<GameObject>("Prefabs/" + this.mStrUIName, PanelLoadComplete);
    }


    private void PanelLoadComplete(GameObject go) 
    {
        Debug.Log(go);
        this.mPanelRoot = GameObject.Instantiate(go, Singleton<UIManager>.GetInstance().GetCanvasRootTransform()).transform as RectTransform;
        this.ctrlCanvas = this.mPanelRoot.GetComponent<Canvas>();
        this.UpdateLayoutLevel();
        panelInterface.LoadSuccess(this, mLuaPath);
        if (mUseMask)
            Singleton<UIManager>.GetInstance().SetupMask(this);
        Singleton<UIManager>.GetInstance().AddUI(this);
    }

    public void OnClose()
    {
        Singleton<UIManager>.GetInstance().RemoveUI(this.mStrUIName);
    }

    public void OnClickMaskArea() {
        this.OnClose();
    }

    public void Dispose()
    {
        panelInterface.Release();
        GameObject.Destroy(mPanelRoot.gameObject);
    }
}