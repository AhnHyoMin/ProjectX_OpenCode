using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Physics 와 관련된 코드 모아둠
/// </summary>
public static class CPhysicsUtile
{
    static RaycastHit[] m_RaycastHit = new RaycastHit[256];
    static Collider[] m_Colider = new Collider[256];

    public static int SphereCastNonAlloc(Vector3 _Origin, float _Radius, Vector3 _Dir, ref RaycastHit[] _RaycastHit, float _MaxDistance)
    {       
        int _Count = Physics.SphereCastNonAlloc(_Origin, _Radius, _Dir, m_RaycastHit, _MaxDistance);

        _RaycastHit = m_RaycastHit;       
        return _Count;
    }

    public static int OverlapSphereNonAlloc(Vector3 _Origin, float _Radius, ref Collider[] _RaycastHit, int _Layer = 1)
    {
        int _Count = Physics.OverlapSphereNonAlloc(_Origin, _Radius, m_Colider, _Layer);

        _RaycastHit = m_Colider;
        return _Count;
    }


}
