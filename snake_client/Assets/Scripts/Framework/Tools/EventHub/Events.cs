
public class Event : EventRegister
{
    public void BroadCastEvent()
    {
        _BroadCastEvent();
    }
}

public class Event<T0> : EventRegister<T0>
{
    public void BroadCastEvent(T0 arg0)
    {
        _BroadCastEvent(arg0);
    }
}



public class Event<T0, T1> : EventRegister<T0, T1>
{
    public void BroadCastEvent(T0 arg0, T1 arg1)
    {
        _BroadCastEvent(arg0, arg1);
    }
}




public class Event<T0, T1, T2> : EventRegister<T0, T1, T2>
{
    public void BroadCastEvent(T0 arg0, T1 arg1, T2 arg2)
    {
        _BroadCastEvent(arg0, arg1, arg2);
    }
}


public class Event<T0, T1, T2, T3> : EventRegister<T0, T1, T2, T3>
{
    public void BroadCastEvent(T0 arg0, T1 arg1, T2 arg2, T3 arg3)
    {
        _BroadCastEvent(arg0, arg1, arg2, arg3);
    }
}
