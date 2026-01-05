using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IDamagedable
{
    public void Damaged(int damage);
}
public enum AttackType { Bullet=1, Canon=2, Laser=3};

public enum Layer
{
    Default = 1 << 0,
    TransparentFX = 1 << 1,
    IgnoreRaycase = 1 << 2,
    Water = 1 << 3,
    UI = 1 << 4,
    MonsterBody = 1 << 6,
    MonsterHitbox = 1 << 7,
    Detector = 1 << 9,
    Invinsible = 1 << 10,
    Attack = 1 << 11
}

public enum Scene { Main, GamePlay, Ending, length}