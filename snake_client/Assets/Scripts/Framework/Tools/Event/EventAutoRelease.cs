using System.Collections.Generic;
using UnityEngine;

public class EventAutoRelease : IRelease
{
    protected List<IRelease> mEventList = new List<IRelease>();

    public void Subscribe<T0>(Event<T0> evt, System.Action<T0> handle)
    {
        mEventList.Add(evt.Subscribe(handle));
    }
    public void Subscribe<T0, T1>(Event<T0, T1> evt, System.Action<T0, T1> handle)
    {
        mEventList.Add(evt.Subscribe(handle));
    }
    public void Subscribe<T0, T1, T2>(Event<T0, T1, T2> evt, System.Action<T0, T1, T2> handle)
    {
        mEventList.Add(evt.Subscribe(handle));
    }
    public void Subscribe<T0, T1, T2, T3>(Event<T0, T1, T2, T3> evt, System.Action<T0, T1, T2, T3> handle)
    {
        mEventList.Add(evt.Subscribe(handle));
    }

    public void Release()
    {
        foreach (var releaseID in mEventList)
        {
            releaseID.Release();
        }
    }
}