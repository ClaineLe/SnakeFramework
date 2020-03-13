using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using uSourceManager = Singleton<SourceManager>;
public class MapLogic :MonoBehaviour, ISystemLogic
{
    public void Start()
    {
        uSourceManager.GetInstance().LoadAsset<GameObject>("Models/MapUnit", assetObj => {
            Vector3[] mapPositions = new Vector3[2];
            mapPositions[0] = new Vector3(0, 0, 0);
            mapPositions[1] = new Vector3(0, 1, 0);
            this.Create(assetObj, mapPositions);
        });
    }

    private void Create(GameObject obj, Vector3[] mapPositions)
    {
        GameObject[] maps = new GameObject[mapPositions.Length];
        for (int i = 0; i < mapPositions.Length; i++)
        {
            GameObject mapGo = GameObject.Instantiate(obj, this.transform);
            mapGo.transform.position = mapPositions[i];
            maps[i] = mapGo;
        }
        StaticBatchingUtility.Combine(maps, this.gameObject);
    }
}
