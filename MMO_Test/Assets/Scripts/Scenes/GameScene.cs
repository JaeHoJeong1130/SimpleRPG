using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;

        //Managers.UI.ShowSceneUI<UI_Inven>();

        Dictionary<int, Data.Stat> dict = Managers.Data.StatDict;

        gameObject.GetOrAddComponent<CursorController>();

        Managers.Sound.Play("BGM/5 - Heavy Combat - Paladin's Fury (loop)", Define.Sound.Bgm, volume : 0.1f);

        GameObject player = Managers.Game.Spawn(Define.WorldObject.Player, "Player");
        Camera.main.gameObject.GetOrAddComponent<CameraController>().SetPlayer(player);
        
        //GameObject go = new GameObject { name = "MonsterGenerator" };
        //MonsterGenerator gen = go.GetOrAddComponent<MonsterGenerator>();
        //gen.SetKeepMonsterCount(5);

        GameObject obj = Managers.Game.Spawn(Define.WorldObject.Monster, "Slime");
    }

    public override void Clear()
    {
        
    }
}
