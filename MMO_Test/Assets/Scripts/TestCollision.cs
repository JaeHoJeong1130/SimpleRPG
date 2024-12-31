using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TestCollision : MonoBehaviour
{
    // 1) 나 혹은 RidigBody 있어야 한다 (IsKinematic : Off)
    // 2) 나한테 Collider가 있어야 한다 (IsTrigger : Off)
    // 3) 상대한테 Collider가 있어야 한다 (IsTrigger : Off)
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision @ {collision.gameObject.name} ");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger @ {other.gameObject.name} ");
    }

    void Start()
    {
        
    }

    void Update()
    {
        //Debug.Log(Input.mousePosition);

        //Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition));


        // 카메라 기준 레이캐스팅 해보기 (긴 버전)
        // 롤처럼 땅을 찍으면 거기로 이동하는걸 구현할 때 레이캐스팅을 활용할 수 있다
        // if(Input.GetMouseButtonDown(0))
        // {
        //     Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        //     Vector3 dir = mousePos - Camera.main.transform.position;
        //     dir = dir.normalized;

        //     Debug.DrawRay(Camera.main.transform.position, dir * 100.0f, Color.red, 1.0f);

        //     RaycastHit hit;
        //     if(Physics.Raycast(Camera.main.transform.position, dir, out hit, 100.0f))
        //     {
        //         Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
        //     }
        // }

        // 카메라 기준 레이캐스팅 (레이 버전)
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

            //int mask = (1 << 8) | (1 << 9);
            LayerMask mask = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall");

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100.0f, mask))
            {
                Debug.Log($"Raycast Camera @ {hit.collider.gameObject.tag}");
            }
        }
        
    }
}
