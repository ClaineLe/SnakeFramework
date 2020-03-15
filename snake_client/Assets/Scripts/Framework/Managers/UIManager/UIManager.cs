using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Type = System.Type;

public class UIManager : Singleton<UIManager>
{
    private Dictionary<Type, ScreenBase> mTypeScreens;

    private GameObject uiRoot;
    private GameObject canvasRoot;
    private Camera uiCamera;

    public int mUIOpenOrder = 0;//UI打开时，Order值，用来标识界面层级顺序

    public override void Init()
    {
        base.Init();
        this.mTypeScreens = new Dictionary<Type, ScreenBase>();
        Singleton<SourceManager>.GetInstance().LoadAsset<GameObject>("Prefabs/UIRoot", assetObj => {
            this.uiRoot = GameObject.Instantiate(assetObj);
            this.uiCamera = this.uiRoot.transform.Find("UICamera").GetComponent<Camera>();
            this.uiRoot.name = this.uiRoot.name.Replace("(Clone)", string.Empty);
            GameObject.DontDestroyOnLoad(this.uiRoot);

            this.canvasRoot = this.uiRoot.transform.Find("Canvas").gameObject;
        });
    }
    public Transform GetCanvasRootTransform() {
        return this.canvasRoot.transform;
    }
    public ScreenBase OpenUI(Type type, UIOpenParamBase param = null)
    {
        ScreenBase screenBase = this.GetUI(type);
        ++mUIOpenOrder;

        if (screenBase != null){
            if (screenBase != null && !screenBase.CtrlBase.ctrlCanvas.enabled) {
                screenBase.CtrlBase.ctrlCanvas.enabled = true;
            }
            return screenBase;
        }
        screenBase = (ScreenBase)System.Activator.CreateInstance(type, param);
        this.mTypeScreens.Add(type, screenBase);
        screenBase.SetOpenOrder(mUIOpenOrder);
        return screenBase;
    }
    public ScreenBase GetUI(Type type)
    {
        if (!typeof(ScreenBase).IsAssignableFrom(type)) return default;
        ScreenBase screenBase = null;
        if (mTypeScreens.TryGetValue(type, out screenBase))
            return screenBase;
        return null;
    }
    public bool CloseUI(Type type)
    {
        ScreenBase screenBase = GetUI(type);
        if (screenBase != null)
        {
            if (type == typeof(ScreenBase))     // 标尺界面是测试界面 不用关闭
                return false;
            else
                screenBase.OnClose();
            return true;
        }
        return false;
    }
    public void AddUI(ScreenBase screenBase)
    {
        screenBase.mPanelRoot.SetParent(GetCanvasRootTransform());

        screenBase.mPanelRoot.anchorMin = Vector3.zero;
        screenBase.mPanelRoot.anchorMax = Vector3.one;
        screenBase.mPanelRoot.anchoredPosition = Vector3.zero;
        screenBase.mPanelRoot.sizeDelta = Vector3.zero;
        screenBase.mPanelRoot.transform.localScale = Vector3.one;
        screenBase.mPanelRoot.transform.localRotation = Quaternion.identity;
        screenBase.mPanelRoot.name = screenBase.mPanelRoot.name.Replace("(Clone)", string.Empty);
    }
    public void RemoveUI(ScreenBase screenBase)
    {
        if (mTypeScreens.ContainsKey(screenBase.GetType()))  // 根据具体需求决定到底是直接销毁还是缓存
            mTypeScreens.Remove(screenBase.GetType());
        screenBase.Dispose();
    }


    public Camera GetUICamera()
    {
        return uiCamera;
    }
}
