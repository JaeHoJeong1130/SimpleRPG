using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Scene : UI_Base
{
    public override void Init() // Start()로 하면 안좋음
    {
        Managers.UI.SetCanvas(gameObject, false);
    }
}
