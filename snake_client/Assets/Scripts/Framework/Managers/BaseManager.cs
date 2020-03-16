using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseManager<T> : Singleton<T>, IManager where T : class, IManager, new()
{

}
