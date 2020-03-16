using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : BaseManager<CameraManager>
{
    private Camera mMainCamera;
    public override void Init()
    {
        base.Init();
        this.mMainCamera = Camera.main;
        GameObject.DontDestroyOnLoad(this.mMainCamera);
    }


}
