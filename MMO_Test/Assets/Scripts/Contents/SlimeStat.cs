using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeStat : Stat
{
    private void Start()
    {
        _level = 1;
        _hp = 100;
        _maxHp = 100;
        _attack = 10;
        _defense = 0;
        _moveSpeed = 5.0f;
    }

}
