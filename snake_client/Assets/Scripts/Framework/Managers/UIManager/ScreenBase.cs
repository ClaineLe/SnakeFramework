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

    public ScreenBase(string UIName, UIOpenParamBase param = null)
    {
        StartLoad(UIName, param);
    }

    virtual public void StartLoad(string UIName, UIOpenParamBase param = null)
    {
        this.mStrUIName = UIName;
        this.mOpenParam = param;
        Singleton<SourceManager>.GetInstance().LoadAsset<GameObject>("Prefabs/" + UIName, PanelLoadComplete);
    }

    private void PanelLoadComplete(GameObject go) 
    {
        Debug.Log(go);
        this.mPanelRoot = GameObject.Instantiate(go, Singleton<UIManager>.GetInstance().GetCanvasRootTransform()).transform as RectTransform;
        this.mCtrlBase = this.mPanelRoot.GetComponent<UICtrlBase>();
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
        GameObject.Destroy(mPanelRoot);
    }
}