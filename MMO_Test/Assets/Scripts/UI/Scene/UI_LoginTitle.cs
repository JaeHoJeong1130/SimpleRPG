using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_LoginTitle : UI_Scene
{
    enum Buttons
    {
        StartButton,
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));

        // extension을 이용해 한줄로 작성
        GetButton((int)Buttons.StartButton).gameObject.BindEvent(OnButtonClicked);
    }

    private void OnButtonClicked(PointerEventData data)
    {
        Debug.Log("Start Button Clicked");
        Managers.Scene.LoadScene(Define.Scene.Game);
    }
}
