using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurStat : Stat
{
    private void Start()
    {
        _level = 5;
        _hp = 300;
        _maxHp = 300;
        _attack = 30;
        _defense = 0;
        _moveSpeed = 5.0f;
    }

    protected override void OnDead(Stat attacker)
    {
        PlayerStat playerStat = attacker as PlayerStat;
        if(playerStat != null)
        {
            playerStat.Exp += 10;
        }
        Managers.Game.Despawn(gameObject);
    }
}
