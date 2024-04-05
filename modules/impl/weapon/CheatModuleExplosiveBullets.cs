using UnityEngine.InputSystem;

namespace PixelGunCheat.modules.impl.weapon;

public class CheatModuleExplosiveBullets : CheatModuleWeapon
{
    public CheatModuleExplosiveBullets(Key k) : base(k, false)
    {
    }

    public override string GetName()
    {
        return "ExplosiveBullets";
    }

    public override void HandleCheat(WeaponSounds weaponSounds)
    {
        if (!IsEnabled()) return;
        weaponSounds.bulletExplode = true;

    }
}