using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : BaseScene
{
    private bool SceneChanged = false;
    
    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.End;
        Dictionary<int, Data.Stat> dict = Managers.Data.StatDict;

        Managers.Sound.Play("Player/PlayerGroan", Define.Sound.Effect, 0.9f, 2.0f);

        Managers.Sound.Play("BGM/Forever", Define.Sound.Bgm, volume : 0.1f);

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !SceneChanged)
        {
            SceneChanged = true;
            Managers.Scene.LoadScene(Define.Scene.Game);
        }
    }

    public override void Clear()
    {
        
    }
}
