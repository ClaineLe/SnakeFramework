﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHub
{
    public static Event<bool> OnGuildCreated = new Event<bool>();   //创建公会成功
}
