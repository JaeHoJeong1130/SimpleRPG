using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : BaseScene
{
    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.End;
        Dictionary<int, Data.Stat> dict = Managers.Data.StatDict;

        Managers.Sound.Play("Player/PlayerGroan", Define.Sound.Effect, 0.9f, 2.0f);

        Managers.Sound.Play("BGM/11 - Heavy Combat - Knight's Valor (loop)", Define.Sound.Bgm, volume : 0.1f);

        

    }

    public override void Clear()
    {
        
    }
}
