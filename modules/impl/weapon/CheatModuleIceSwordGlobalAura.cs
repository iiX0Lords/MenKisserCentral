﻿using UnityEngine.InputSystem;

namespace PixelGunCheat.modules.impl.weapon;

public class CheatModuleIceSwordGlobalAura : CheatModuleWeapon
{
    public CheatModuleIceSwordGlobalAura(Key k) : base(k)
    {
    }

    public override string GetName()
    {
        return "KillAll";
    }

    public override void HandleCheat(WeaponSounds t)
    {
        if (!IsEnabled()) return;
        t.isFrostSword = true;
        t.isFrostSwordUseAngle = true;
        t.frostRadius = 9999f;
        t.frostDamageMultiplier = 2f;
        t.frostSwordAngle = 360;
        t.frostSwordnTime = 0.33f;
    }
}