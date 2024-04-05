﻿using UnityEngine.InputSystem;

namespace PixelGunCheat.modules.impl.weapon;

public class CheatModuleForceCancer : CheatModuleWeapon
{
    public CheatModuleForceCancer(Key k) : base(k, true)
    {
    }

    public override string GetName()
    {
        return "AllDebuffsOnHit";
    }

    public override void HandleCheat(WeaponSounds t)
    {
        if (!IsEnabled()) return;
        t.isCharm = true;
        t.isCursing = true;
        t.isLightning = true;
        t.isPoisoning = true;
        t.isStun = true;
        
        t.isBlindEffect = true;
        t.isBlindEffectTime = 9999f;
        
        t.isSlowdown = true;
        t.isSlowdownStack = true;
    }
}