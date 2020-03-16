using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Type = System.Type;

public class UIManager : BaseManager<UIManager>
{
    private Dictionary<Type, ScreenBase> mTypeScreens;

    private GameObject uiRoot;
    private GameObject canvasRoot;
    private Camera uiCamera;
    private GameObject uiMask;
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

        Singleton<SourceManager>.GetInstance().LoadAsset<GameObject>("Prefabs/UIMask", assetObj => {
            this.uiMask = assetObj;
        });
    }

    /*
    // 预制分辨率
    static Vector2Int ScreenResolution = new Vector2Int(1136,640);
    void Update()
    {
        if (ScreenResolution.x != Screen.width || ScreenResolution.y != Screen.height)
        {
            ScreenResolution = new Vector2Int(Screen.width, Screen.height);
            EventManager.ScreenResolutionEvt.BroadCastEvent(ScreenResolution);
        }
    }
         */

    public void SetupMask(ScreenBase screenBase) {
        if (screenBase == null || screenBase.CtrlBase == null)
            return;

        GameObject tmpMaskGo = GameObject.Instantiate(this.uiMask, screenBase.mPanelRoot);
        tmpMaskGo.transform.SetAsFirstSibling();
        tmpMaskGo.name = "UIAutoMask_Create_By_UIManager";
        Button btnMask = tmpMaskGo.GetComponent<Button>();
        if (btnMask != null)
        {
            btnMask.onClick.AddListener(screenBase.OnClickMaskArea);
        }
    }

    public Transform GetCanvasRootTransform() {
        return this.canvasRoot.transform;
    }
    public ScreenBase OpenUI(Type type, UIOpenParamBase param = null)
    {
        ScreenBase screenBase = this.GetUI(type);
        ++mUIOpenOrder;

        if (screenBase != null) {
            if (screenBase != null && !screenBase.CtrlBase.ctrlCanvas.enabled) {
                screenBase.CtrlBase.ctrlCanvas.enabled = true;
            }
            return screenBase;
        }
        screenBase = (ScreenBase)System.Activator.CreateInstance(type, param);
        this.mTypeScreens.Add(type, screenBase);
        screenBase.SetOpenOrder(mUIOpenOrder);

        if (screenBase.CtrlBase.mHideOtherScreenWhenThisOnTop)
        {
            ProcessUIOnTop();
        }
        return screenBase;
    }

    private List<ScreenBase> tmpSortList = new List<ScreenBase>();
    private void ProcessUIOnTop() {
        tmpSortList.Clear();
        foreach (var s in this.mTypeScreens.Values)
            tmpSortList.Add(s);
        tmpSortList.Sort((left, right) => {
            if (left.mSortingLayer == right.mSortingLayer)
                return right.mOpenOrder.CompareTo(left.mOpenOrder);
            return right.mSortingLayer.CompareTo(left.mSortingLayer);
        });



        // 先找到第一个控制的UI层
        int index = 0;

        for (int i = 0; i < tmpSortList.Count; i++)
        {
            var tempC = tmpSortList[i];
            if (tempC.CtrlBase.mHideOtherScreenWhenThisOnTop)
            {
                // 找到第一个需要被隐藏的界面 隐藏就好
                tempC.CtrlBase.ctrlCanvas.enabled = true;
                index = i;// 因为是一个有序的List 所以找到第一个需要控制的界面之后记录序号，然后从它接着遍历即可
                break;
            }
        }

        // 如果没有找到 可能的情况是就是关闭了最上层界面 所以现在最上层的应该是空的
        if (index == 0)
        {
            for (int i = 0; i < tmpSortList.Count; i++)
            {
                var tempC = tmpSortList[i];
                // 找到第一个需要被隐藏的界面 隐藏就好
                if (!tempC.CtrlBase.ctrlCanvas.enabled)
                {
                    tempC.CtrlBase.ctrlCanvas.enabled = true;
                    index = i;// 因为是一个有序的List 所以找到第一个需要控制的界面之后记录序号，然后从它接着遍历即可
                    break;
                }
            }
        }

        // 找到下面需要隐藏的 
        for (int i = index + 1; i < tmpSortList.Count; i++)
        {
            var tempC = tmpSortList[i];
            if (!tempC.CtrlBase.mAlwaysShow)
            {
                // 找到需要被隐藏的界面 隐藏就好
                tempC.CtrlBase.ctrlCanvas.enabled = false;
            }
        }

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

        if (screenBase.CtrlBase.mHideOtherScreenWhenThisOnTop)
        {
            ProcessUIOnTop();
        }
    }


    public Camera GetUICamera()
    {
        return uiCamera;
    }
}
