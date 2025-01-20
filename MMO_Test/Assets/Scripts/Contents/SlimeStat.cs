using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeStat : Stat
{
    private void Start()
    {
        _level = 1;
        _hp = 50;
        _maxHp = 50;
        _attack = 10;
        _defense = 0;
        _moveSpeed = 3.0f;
    }

    protected override void OnDead(Stat attacker)
    {
        PlayerStat playerStat = attacker as PlayerStat;
        if(playerStat != null)
        {
            playerStat.Exp += 3;
        }
        Managers.Game.Despawn(gameObject);
    }

}
