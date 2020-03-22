using UnityEngine;

public class SourceManager : Singleton<SourceManager>
{
    public override void Init()
    {
        base.Init();
    }

    public void LoadAsset<T>(string assetPath, System.Action<T> callback) where T : Object
    {
        T assetObj = Resources.Load<T>(assetPath);
        callback?.Invoke(assetObj);
    }

    public byte[] LoadCustomData(string filePath, string suffix) {
        return System.IO.File.ReadAllBytes("../Luacode/" + filePath.Replace('.', '/') + suffix);
    }
}
