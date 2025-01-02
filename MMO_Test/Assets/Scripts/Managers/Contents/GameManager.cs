using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    //Dictionary<int, GameObject> _player = new Dictionary<int, GameObject>();
    
    // 일단 플레이어 한명이니깐 겜옵으로 하나 저장
    GameObject _player;
    // 아이디 숫자로 관리는 아직 안하니깐 Hashset으로
    HashSet<GameObject> _monsters = new HashSet<GameObject>();

    public GameObject Spawn(Define.WorldObject type, string path, Transform parent = null)
    {
        GameObject go = Managers.Resource.Instantiate(path, parent);

        switch(type)
        {
            case Define.WorldObject.Monster:
                _monsters.Add(go);
                break;
            case Define.WorldObject.Player:
                _player = go;
                break;
        }

        return go;
    }

    public Define.WorldObject GetWorldObjectType(GameObject go)
    {
        BaseController bc = go.GetComponent<BaseController>();
        if(bc == null)
            return Define.WorldObject.Unknown;

        return bc.WorldObjectType;
    }

    public void Despawn(GameObject go)
    {
        Define.WorldObject type = GetWorldObjectType(go);

        switch(type)
        {
            case Define.WorldObject.Monster:
                {
                    if(_monsters.Contains(go))
                        _monsters.Remove(go);
                }
                break;
            case Define.WorldObject.Player:
                {
                    if(_player == go)
                        _player = null;
                }
                break;
        }
    }
}
