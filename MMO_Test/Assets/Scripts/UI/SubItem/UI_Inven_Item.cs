using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UI_Inven_Item : UI_Base
{
    // 텍스트하나 이미지하나 이렇게 만들어도 되지만
    // 이렇게 적은 경우엔 그냥 겜옵에 다 넣어줘도됨
    enum GameObjects
    {
        ItemIcon,
        ItemNameText,
    }

    string _name;

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));
        Get<GameObject>((int)GameObjects.ItemNameText).GetComponent<Text>().text = _name;

        Get<GameObject>((int)GameObjects.ItemIcon).BindEvent((PointerEventData) => { Debug.Log($"아이템 클릭! {_name}"); });
    }

    public void SetInfo(string name)
    {
        _name = name;
    }
}
