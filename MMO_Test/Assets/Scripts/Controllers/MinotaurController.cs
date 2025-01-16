using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinotaurController : BaseController
{
    Stat _stat;

    [SerializeField]
    float _scanRange = 8;

    [SerializeField]
    float _dismissRange = 10;

    [SerializeField]
    float _attackRange = 2;

    public override void Init()
    {
        WorldObjectType = Define.WorldObject.Monster;
        _stat = gameObject.GetComponent<Stat>();

        if(gameObject.GetComponentInChildren<UI_HPBar>() == null)
            Managers.UI.MakeWorldSpaceUI<UI_HPBar>(transform);
    }

    protected override void UpdateIdle()
    {

        GameObject player = Managers.Game.GetPlayer();
        if(player == null)
            return;

        Managers.Game.GetPlayer();

        float distance = (player.transform.position - transform.position).magnitude;
        if(distance <= _scanRange)
        {
            Managers.Sound.Play("MonsterRoars/01. Primal Roar", Define.Sound.Effect);
            _lockTarget = player;
            State = Define.State.Moving;
            return;
        }
    }

    protected override void UpdateMoving()
    {
        GameObject player = Managers.Game.GetPlayer();
        float distance = (player.transform.position - transform.position).magnitude;
        if(_dismissRange < distance)
            State = Define.State.Idle;

        // 플레이어가 내 사정거리보다 가까우면 공격
        if(_lockTarget != null)
        {
            _destPos = _lockTarget.transform.position;
            float attackDistance = (_destPos - transform.position).magnitude;
            if(attackDistance <= _attackRange)
            {
                NavMeshAgent nma = gameObject.GetOrAddComponent<NavMeshAgent>();
                nma.SetDestination(transform.position);
                State = Define.State.Skill;
                return;
            }
        }

        Vector3 dir = _destPos - transform.position;
        if(dir.magnitude < 0.1f) // 벡터에서 벡터를 빼는 경우 정확하게 0이 나오지 않는경우가 많음
        {
            State = Define.State.Idle;
        }
        else
        {
            NavMeshAgent nma = gameObject.GetOrAddComponent<NavMeshAgent>();
            nma.SetDestination(_destPos);
            float moveSpeed = _stat.MoveSpeed;
            nma.speed = moveSpeed;

            // 캐릭터 부드럽게 회전
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 20 * Time.deltaTime);
        } 
    }

    protected override void UpdateSkill()
    {
        if(_lockTarget != null)
        {
            Vector3 dir = _lockTarget.transform.position - transform.position;
            Quaternion quat = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, quat, 20 * Time.deltaTime);
        }
    }

    void OnHitEvent()
    {
        if(_lockTarget != null)
        {
            Stat targetStat = _lockTarget.GetComponent<Stat>();
            Managers.Sound.Play("Attack/HammerFlesh1", Define.Sound.Effect, volume : 0.4f);
            targetStat.OnAttacked(_stat);

            if(targetStat.Hp > 0)
            {
                float distance = (_lockTarget.transform.position - transform.position).magnitude;
                if(distance <= _attackRange)
                    State = Define.State.Skill;
                else
                    State = Define.State.Moving;
            }
            else
            {
                State = Define.State.Idle;
            }
        }
        else
        {
            State = Define.State.Idle;
        }
    }
}
