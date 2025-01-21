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

        Managers.Sound.Play("SoundEffect/medieval-fanfare-6826", Define.Sound.Effect, 1f, 0.8f);

        Managers.Sound.Play("BGM/Forever", Define.Sound.Bgm, volume : 0.1f);

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !SceneChanged)
        {           
            SceneChanged = true;
            
            StartCoroutine(LoadGameScene());
        }
    }

    private IEnumerator LoadGameScene()
    {
        Managers.Sound.Play("UISound/SFX_FastUiClick_02_wav", Define.Sound.Effect, volume : 1f);

        yield return new WaitForSeconds(1.0f);

        Managers.Scene.LoadScene(Define.Scene.Game);
    }

    public override void Clear()
    {
        
    }
}
