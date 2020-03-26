using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AutoSingleton(false)]
public class GameFramework : MonoSingleton<GameFramework>
{
    private GameFacade mGameFacade;
    void Start()
    {
        this.InitManagers();
        //Singleton<UIManager>.GetInstance().OpenUI(typeof(MainCityScreen));
        this.OnInitManagers();
    }

    private void InitManagers()
    {
        Singleton<UIManager>.CreateInstance();
    }

    private void OnInitManagers() {
        this.mGameFacade = new GameFacade();
        Singleton<LuaManager>.GetInstance().StartUp(this.mGameFacade);
    }
}
