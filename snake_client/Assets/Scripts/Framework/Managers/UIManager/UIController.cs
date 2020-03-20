using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public abstract class UIController : MonoBehaviour
{
    public EventAutoRelease mEventHub = new EventAutoRelease();

    protected virtual void OnDestroy() {
        if (this.mEventHub != null)
        {
            this.mEventHub.Release();
            this.mEventHub = null;
        }
    }

    protected T GetUIComponent<T>(string path) where T : UIBehaviour
    {
        Transform tmpTransform = transform.Find(path);
        if (tmpTransform == null)
            return null;
        return tmpTransform.GetComponent<T>();
    }

    protected void AddButtonClick(string path, UnityAction unityAction) {
        Button btn = GetUIComponent<Button>(path);
        if (btn == null)
        {
            Debug.LogError("AddButtonClick Fail. found out path. path:" + path);
        }
        btn.onClick.AddListener(unityAction);
    }
}