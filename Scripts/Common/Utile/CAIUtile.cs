using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// AI와 관련된 유틸 함수들 모아둠
/// </summary>

public static class CAIUtile 
{

    private static GameObject[] m_Entitys = new GameObject[128];
    private static Collider[] m_colliders = new Collider[512];

    public static GameObject[] Entitys { get => m_Entitys; private set => m_Entitys = value; }

    /// <summary>
    /// 타겟 지점에 근접한 타겟 검색
    /// </summary>
    /// <param name="_TargetPosition"></param>
    /// <param name="_Radius"></param>
    /// <param name="_Ignore"></param>
    /// <returns></returns>
    public static int FindCloseEntity(Vector3 _TargetPosition, float _Radius, GameObject _Ignore)
    {
        int _InCount = 0;
        int _PhysicsLength = Physics.OverlapSphereNonAlloc(_TargetPosition, _Radius, m_colliders);

        for (int i = 0; i < _PhysicsLength; i++)
        {
            // 자기 자신은 제외
            if (m_colliders[i].gameObject == _Ignore)
                continue;


            if (_InCount < m_Entitys.Length)
            {
                m_Entitys[_InCount++] = m_colliders[i].gameObject;
            }
            else
                break;

        }

        return _InCount;
    }

    //public static int FindLayerTarget(Vector3 _TargetPosition,float _Radius,string _LayerName)
    //{
    //    int _InCount = 0;
    //    int _PhysicsLength = Physics.OverlapSphereNonAlloc(_TargetPosition, _Radius, m_colliders, LayerMask.NameToLayer(_LayerName));

    //    for (int i = 0; i < _PhysicsLength; i++)
    //    {          
    //        if (_InCount < m_Entitys.Length)
    //        {
    //            //m_colliders[i]

    //            m_Entitys[_InCount++] = m_colliders[i].gameObject;
    //        }
    //        else
    //            break;

    //    }

    //    return _InCount;
    //}

    //public static int FindFowardEntity(Vector3 _TargetPosition, float _Radius, GameObject _Ignore)
    //{
    //    int _InCount = 0;
    //    int _PhysicsLength = Physics.OverlapSphereNonAlloc(_TargetPosition, _Radius, m_colliders);

    //    for (int i = 0; i < _PhysicsLength; i++)
    //    {
    //        // 자기 자신은 제외
    //        if (m_colliders[i].gameObject == _Ignore)
    //            continue;


    //        if (_InCount < m_Entitys.Length)
    //        {
    //            //m_colliders[i]

    //            m_Entitys[_InCount++] = m_colliders[i].gameObject;
    //        }
    //        else
    //            break;

    //    }

    //    return _InCount;
    //}

    ///// <summary>
    ///// Returns true if the given position is on a nav mesh.
    ///// </summary>
    //public static bool IsPositionOnNavMesh(Vector3 position)
    //{
    //    NavMeshHit hit;
    //    return NavMesh.SamplePosition(position, out hit, 0.2f, NavMesh.AllAreas);
    //}

    /// <summary>
    /// 경로를 계산한다
    /// </summary>
    public static void GetPath(ref NavMeshPath path, Vector3 source, Vector3 target, float _Radius = 1)
    {
        if (path == null)
            path = new NavMeshPath();

        GetClosestStandablePosition(ref source, _Radius);
        GetClosestStandablePosition(ref target, _Radius);

        NavMesh.CalculatePath(source, target, NavMesh.AllAreas, path);
    }

    public static void GetNextPoint(NavMeshPath _Path, Transform _StartTr, float _CheckRange = 0.5f)
    {
        if (_Path != null && _Path.corners.Length > 0)
        {
            Vector3 _VecPoint = _Path.corners[0];

            float _Distance = Vector3.Distance(_StartTr.position, _VecPoint);
        }
    }

    /// <summary>
    /// 이동 가능한 지점인지 체크한다
    /// </summary>
    public static bool IsNavigationBlocked(Vector3 origin, Vector3 target)
    {
        NavMeshHit hit;
        return NavMesh.Raycast(origin, target, out hit, NavMesh.AllAreas);
    }

    /// <summary>
    /// 타겟 지점에 가장 가까운 점을 찾는다
    /// </summary>
    public static bool GetClosestStandablePosition(ref Vector3 position,float _Radius =1)
    {
        NavMeshHit hit;

        if (NavMesh.SamplePosition(position, out hit, _Radius, NavMesh.AllAreas))
        {
            position = hit.position;
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool Raycast(ref Vector3 position, Vector3 origin, Vector3 _Dir, float _MaxDistance, float _Radius)
    {
        RaycastHit _RaycastHit;

        int _LayMask = ((1 << LayerMask.NameToLayer(CLayerName.Player)) | (1 << LayerMask.NameToLayer(CLayerName.Enemy)));
        _LayMask = ~_LayMask;
        if (Physics.Raycast(origin, _Dir, out _RaycastHit, _MaxDistance, _LayMask))
        {
            NavMeshHit hit;
            if (NavMesh.SamplePosition(_RaycastHit.point, out hit, _Radius, NavMesh.AllAreas))
            {
                position = hit.position;
                return true;
            }
            return false;
        }
        else
            return false;
    }
}
