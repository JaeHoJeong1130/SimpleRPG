using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Player : UI_Scene
{
    enum GameObjects
    {
        EXPBar
    }

    enum Texts
    {
        EXPText,
        LevelText
    }

    PlayerStat _stat;

    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));
        Bind<Text>(typeof(Texts));

        GameObject go = GameObject.FindWithTag("Player");
        if(go != null)
            _stat = go.GetComponent<PlayerStat>();
    }

    private void Update()
    {
        float ratio = (_stat.Exp % 10) / (float)10;
        
        SetExpRatio(ratio);
    }

    public void SetExpRatio(float ratio)
    {
        GetText((int)Texts.LevelText).text = $"Level : {_stat.Level}";

        float expPercent = ratio * 100;

        GetText((int)Texts.EXPText).text = $"{expPercent}%";
        GetObject((int)GameObjects.EXPBar).GetComponent<Slider>().value = ratio;
    }
}
