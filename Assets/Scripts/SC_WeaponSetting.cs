using JetBrains.Annotations;

[System.Serializable]
public struct WeaponSetting
{
    public float attackSpeed;
    public float attackDist;
    public bool isAuto;
    public int maxAmmo;
    public int currentAmmo;
}