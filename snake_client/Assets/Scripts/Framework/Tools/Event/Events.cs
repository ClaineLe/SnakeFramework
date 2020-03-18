

//所有Event的基类，实现了一些通用的方法
using System;


//所有Event的基类，实现了一些通用的方法
public abstract class EventRegister
{
    protected Delegate _delegate;

    private void _RemoveEventHandler(Delegate d)
    {
        _delegate = Delegate.RemoveAll(_delegate, d);
    }

    /// <summary>
    /// 订阅监听,订阅的监听不用remove,需要执行返回接口的Release。该功能可以方便统一管理，实现自动移除监听
    /// </summary>
    /// <param name="cb"></param>
    /// <returns></returns>
    protected IRelease _Subscribe(Delegate cb)
    {
        _delegate = Delegate.Combine(_delegate, cb);
        return new EventHandlerRemover(this, cb);
    }
    private class EventHandlerRemover : IRelease
    {
        EventRegister _soruce;
        Delegate _value;
        public EventHandlerRemover(EventRegister soruce, Delegate value)
        {
            _soruce = soruce;
            _value = value;
        }
        void IRelease.Release()
        {
            _soruce._RemoveEventHandler(_value);
        }
    }
}
public class Event : EventRegister
{
    public IRelease Subscribe(Action cb)
    {
        return _Subscribe(cb);
    }

    public void BroadCastEvent()
    {
        if (_delegate != null)
        {
            (_delegate as Action)();
        }
    }
}

public class Event<T0> : EventRegister
{
    public IRelease Subscribe(Action<T0> cb)
    {
        return _Subscribe(cb);
    }

    public void BroadCastEvent(T0 arg0)
    {
        if (_delegate != null)
        {
            (_delegate as Action<T0>)(arg0);
        }
    }
}

public class Event<T0, T1> : EventRegister
{
    public IRelease Subscribe(Action<T0, T1> cb)
    {
        return _Subscribe(cb);
    }
    protected void _BroadCastEvent(T0 arg0, T1 arg1)
    {
        if (_delegate != null)
        {
            (_delegate as Action<T0, T1>)(arg0, arg1);
        }
    }
}

public class Event<T0, T1, T2> : EventRegister
{
    //定阅事件
    public IRelease Subscribe(Action<T0, T1, T2> cb)
    {
        return _Subscribe(cb);
    }

    protected void _BroadCastEvent(T0 arg0, T1 arg1, T2 arg2)
    {
        if (_delegate != null)
        {
            (_delegate as Action<T0, T1, T2>)(arg0, arg1, arg2);
        }
    }
}

public class Event<T0, T1, T2, T3> : EventRegister
{
    //定阅事件
    public IRelease Subscribe(Action<T0, T1, T2, T3> cb)
    {
        return _Subscribe(cb);
    }

    protected void _BroadCastEvent(T0 arg0, T1 arg1, T2 arg2, T3 arg3)
    {
        if (_delegate != null)
        {
            (_delegate as Action<T0, T1, T2, T3>)(arg0, arg1, arg2, arg3);
        }
    }
}
