using UnityEngine;
using System.Collections;

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
}