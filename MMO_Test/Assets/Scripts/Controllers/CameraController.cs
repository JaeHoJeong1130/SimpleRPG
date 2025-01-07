using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.QuarterView;
    [SerializeField]
    Vector3 _delta = new Vector3(0.0f, 6.0f, -5.0f);
    [SerializeField]
    GameObject _player = null;

    public void SetPlayer(GameObject player) { _player = player; }

    void Start()
    {
        
    }

    // 플레이어, 카메라가 움직이는데 Update가 갱신되는 순서가 뒤죽박죽이라 흔들거리게됨
    // 이걸 해결해주는게 LateUpdate()
    void LateUpdate()
    {
        if(_mode == Define.CameraMode.QuarterView)
        {
            if(_player.IsValid() == false)
            {
                return;
            }

            RaycastHit hit;
            if(Physics.Raycast(_player.transform.position, _delta, out hit, _delta.magnitude, LayerMask.GetMask("Block")))
            {
                float dist = (hit.point - _player.transform.position).magnitude * 0.8f;
                transform.position = _player.transform.position + _delta.normalized * dist;
            }
            else
            {
                // TODO
                // 시야가 땡겨졌다가 돌아올때 자연스럽게 하는 부분
                
                transform.position = _player.transform.position + _delta;
                // 무조건 플레이어를 주시하게 해주는 LookAt
                transform.LookAt(_player.transform);
            }
            
        }
        
    }

    // 나중에 쿼터뷰를 코드로 세팅하고 싶을때를 대비
    public void SetQuaterView(Vector3 delta)
    {
        _mode = Define.CameraMode.QuarterView;
        _delta = delta;
    }
}
