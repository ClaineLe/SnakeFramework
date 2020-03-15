using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void PanelLoadComplete(GameObject go) 
    {
        this.mPanelRoot = GameObject.Instantiate(go, Singleton<UIManager>.GetInstance().GetCanvasRootTransform()).transform as RectTransform;
        this.mCtrlBase = this.mPanelRoot.GetComponent<UICtrlBase>();
        this.UpdateLayoutLevel();
        this.OnLoadSuccess();
        Singleton<UIManager>.GetInstance().AddUI(this);
    }

    virtual protected void OnLoadSuccess() {
    
    }

    virtual public void OnClose()
    {
        Singleton<UIManager>.GetInstance().RemoveUI(this);
    }

    virtual public void Dispose()
    {
        GameObject.Destroy(mPanelRoot.gameObject);
    }
}