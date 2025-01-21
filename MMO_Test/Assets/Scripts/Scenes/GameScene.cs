using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameScene : BaseScene
{
    private PlayerStat playerStat;
    private GameObject boss;
    private bool SceneChanged = false;

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;

        Managers.UI.ShowSceneUI<UI_Player>();

        Dictionary<int, Data.Stat> dict = Managers.Data.StatDict;

        gameObject.GetOrAddComponent<CursorController>();

        Managers.Sound.Play("BGM/8 - Heavy Combat - Warlock's Wrath (loop)", Define.Sound.Bgm, volume : 0.1f);

        // 플레이어 생성
        GameObject player = Managers.Game.Spawn(Define.WorldObject.Player, "Player");
        playerStat = player.GetComponent<PlayerStat>();
        Camera.main.gameObject.GetOrAddComponent<CameraController>().SetPlayer(player);
        
        GameObject go = new GameObject { name = "MonsterGenerator" };
        MonsterGenerator gen = go.GetOrAddComponent<MonsterGenerator>();
        gen.SetKeepMonsterCount(5);

        boss = Managers.Game.Spawn(Define.WorldObject.Monster, "Minotaur");
    }

    private void Update()
    {
        if(playerStat.isDead && !SceneChanged)
        {
            SceneChanged = true;

            Managers.Scene.LoadScene(Define.Scene.Died);
        }

        if(boss == null && !SceneChanged)
        {
            SceneChanged = true;

            Managers.Scene.LoadScene(Define.Scene.End);
        }
    }

    public override void Clear()
    {
        
    }
}
