using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor(typeof(ComponentCollect))]
public class ComponentCollectInspector : Editor
{
    static Dictionary<int, string> _outletObjects = new Dictionary<int, string>();
    private HashSet<string> _cachedPropertyNames = new HashSet<string>();
    
    public override void OnInspectorGUI()
    {
        _cachedPropertyNames.Clear();
        EditorGUI.BeginChangeCheck();
        var outlet = target as ComponentCollect;
        if (outlet.OutletInfos == null || outlet.OutletInfos.Count == 0)
        {
            if (GUILayout.Button("Add New Outlet"))
            {
                if (outlet.OutletInfos == null)
                    outlet.OutletInfos = new List<ComponentInfo>();

                Undo.RecordObject(target, "Add OutletInfo");
                outlet.OutletInfos.Add(new ComponentInfo());
            }
        }
        else
        {
            for (var j = outlet.OutletInfos.Count - 1; j >= 0; j--)
            {
                var currentTypeIndex = -1;
                var outletInfo = outlet.OutletInfos[j];
                string[] typesOptions = default(string[]);

                var isValid = outletInfo.Object != null && !_cachedPropertyNames.Contains(outletInfo.Name);
                _cachedPropertyNames.Add(outletInfo.Name);

                if (outletInfo.Object != null)
                {
                    if (outletInfo.Object is GameObject)
                    {
                        currentTypeIndex = 0;// give it default
                        _outletObjects[outletInfo.Object.GetInstanceID()] = outletInfo.Name;
                        Component[] components = outletInfo.Object.GetComponents<Component>();
                        typesOptions = new string[components.Length];
                        for (var i = 0; i < components.Length; i++)
                        {
                            var com = components[i];
                            if (com == null) continue;
                            var typeName = typesOptions[i] = com.GetType().FullName;
                            if (typeName == outletInfo.ComponentType)
                            {
                                currentTypeIndex = i;
                            }
                        }
                    }
                }

                using (var v = new GUILayout.VerticalScope("box"))
                {
                    using (var h = new GUILayout.HorizontalScope("box"))
                    {
                        EditorGUILayout.Space();
                        if (GUILayout.Button("+"))
                        {
                            Undo.RecordObject(target, "Insert OutletInfo");
                            outlet.OutletInfos.Insert(j, new ComponentInfo());
                        }
                        if (GUILayout.Button("-"))
                        {
                            Undo.RecordObject(target, "Remove OutletInfo");
                            outlet.OutletInfos.RemoveAt(j);
                        }
                    }

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.EndHorizontal();

                    outletInfo.Name = EditorGUILayout.TextField("Name:", outletInfo.Name);
                    outletInfo.Object = EditorGUILayout.ObjectField("Object:", outletInfo.Object, typeof(UnityEngine.Object), true) as MonoBehaviour;
                    if (currentTypeIndex >= 0)
                    {
                        var typeIndex = EditorGUILayout.Popup("Component:", currentTypeIndex, typesOptions);
                        outletInfo.ComponentType = typesOptions[typeIndex].ToString();
                    }
                }
            }
        }

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(target, "GUI Change Check");
        }
    }


}
