using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraController : MonoBehaviour
{
    [SerializeField]
    Vector3 _delta = new Vector3(0.0f, 15.0f, 0f);
    [SerializeField]
    Transform _player;

    private Camera minimapCamera;

    void Start()
    {
        GameObject go = Managers.Game.GetPlayer();
        _player = go.transform;

        minimapCamera = Camera.main;
    }

    void LateUpdate()
    {
        Vector3 newPos = _player.position;
        newPos.y = transform.position.y;
        transform.position = newPos;

        // TODO
        // 미니맵 확대 축소
        minimapCamera.orthographicSize = 15f;        
    }
}
