using UnityEngine;
using System.Collections.Generic;

public class ComponentInfo
{
    public string Name;
    public string ComponentType;
    public Component Object;
}

public class ComponentCollect : MonoBehaviour
{
    [HideInInspector]
    public List<ComponentInfo> OutletInfos = new List<ComponentInfo>();

    public Component GetComponent(string refName)
    {
        return OutletInfos.Find(a => a.Name == refName).Object;
    }
}
