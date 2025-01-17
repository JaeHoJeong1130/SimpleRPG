using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;

        Managers.UI.ShowSceneUI<UI_Player>();

        Dictionary<int, Data.Stat> dict = Managers.Data.StatDict;

        gameObject.GetOrAddComponent<CursorController>();

        Managers.Sound.Play("BGM/11 - Heavy Combat - Knight's Valor (loop)", Define.Sound.Bgm, volume : 0.1f);

        // 플레이어 생성
        GameObject player = Managers.Game.Spawn(Define.WorldObject.Player, "Player");
        Camera.main.gameObject.GetOrAddComponent<CameraController>().SetPlayer(player);
        
        GameObject go = new GameObject { name = "MonsterGenerator" };
        MonsterGenerator gen = go.GetOrAddComponent<MonsterGenerator>();
        gen.SetKeepMonsterCount(5);

        GameObject obj = Managers.Game.Spawn(Define.WorldObject.Monster, "Minotaur");
    }

    public override void Clear()
    {
        
    }
}
