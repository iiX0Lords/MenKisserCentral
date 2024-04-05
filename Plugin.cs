using BepInEx;
using BepInEx.Unity.IL2CPP;
using Il2CppInterop.Runtime.Injection;
using UnityEngine;

namespace PixelGunCheat;

[BepInPlugin("com.iiX0Lord.pixelguncheat", "MenKisserCentral", "1.0.2")]
public class Plugin : BasePlugin
{
    public GameObject ManagerHook;
    

    public override void Load()
    {

        Debug.Log("Hooking");
        ClassInjector.RegisterTypeInIl2Cpp<CheatManager>();
        ManagerHook = new GameObject("ManagerHook");
        ManagerHook.AddComponent<CheatManager>();
        Object.DontDestroyOnLoad(ManagerHook);
        Debug.Log("Hooked");
    }
}
