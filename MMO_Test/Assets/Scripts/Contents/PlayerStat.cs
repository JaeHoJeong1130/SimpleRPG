using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : Stat
{
    [SerializeField]
    protected int _exp;
    [SerializeField]
    protected int _gold;

    public bool isDead = false;

    public int Exp
    {
        get { return _exp; }
        set 
        {
            _exp = value; 

            int level = Level;
            while(true)
            {
                Data.Stat stat;
                if(Managers.Data.StatDict.TryGetValue(level + 1, out stat) == false)
                    break;
                if(_exp < stat.totalExp)
                    break;
                level++;
            }

            if(level != Level)
            {
                Debug.Log("Level Up!");
                Managers.Sound.Play("Player/PlayerLevelup", Define.Sound.Effect, volume : 0.4f);
                Level = level;
                SetStat(Level);
            }
        } 
    }
    
    public int Gold { get { return _gold; } set {_gold = value; } }

    private void Start()
    {
        _level = 1;
        _exp = 0;
        _moveSpeed = 8.0f;
        _gold = 0;

        SetStat(_level);
    }

    public void SetStat(int _level)
    {
        Dictionary<int, Data.Stat> dict = Managers.Data.StatDict;

        Data.Stat stat = dict[_level];

        _hp = stat.maxHp;
        _maxHp = stat.maxHp;
        _attack = stat.attack;
        _defense = stat.defense;
    }

    protected override void OnDead(Stat attacker)
    {
        isDead = true;
        Debug.Log("YOU DIED...");
    }
}
