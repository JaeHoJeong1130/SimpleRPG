using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScene : BaseScene
{
    private bool SceneChanged = false;

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Login;

        Managers.UI.ShowSceneUI<UI_LoginTitle>();

        //List<GameObject> list = new List<GameObject>();

        Managers.Sound.Play("BGM/4 - Heavy Combat - Shadowstrike (loop)", Define.Sound.Bgm, volume : 0.1f);

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
