using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AutoSingleton(false)]
public class GameFramework : MonoSingleton<GameFramework>
{
    void Start()
    {
        this.InitManagers();

        Singleton<LuaManager>.GetInstance().StartUp();
        //Singleton<UIManager>.GetInstance().OpenUI(typeof(MainCityScreen));
    }

    private void InitManagers()
    {
        //Singleton<DataManager>.CreateInstance();
        //Singleton<CameraManager>.CreateInstance();
        //Singleton<UIManager>.CreateInstance();


        
    }
}
