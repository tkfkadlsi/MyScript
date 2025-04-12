using UnityEngine;

public class DrumTower : Tower
{
    protected override void Setting()
    {
        base.Setting();

        TowerLevel = 1;
        Damage = 1;
        Range = 5;
    }

    protected override void HandleNoteEvent(TowerType type)
    {
        if (_isStun) return;
        if (type != TowerType.Drum) return;

        DrumAttack drumAttack = Managers.Instance.Pool.PopObject(PoolType.DrumAttack, transform.position).GetComponent<DrumAttack>();
        drumAttack.SettingTarget(new Vector3(Range, 0f, 0f), Damage, this);
    }
}
