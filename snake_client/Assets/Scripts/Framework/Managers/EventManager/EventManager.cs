using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    public Event<bool> OnGuildCreated = new Event<bool>();   //创建公会成功
}
