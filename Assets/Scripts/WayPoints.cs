using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        foreach( Transform t in transform)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(t.position, 1f); 
        }

        Gizmos.color = Color.red;
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
        }

        Gizmos.DrawLine(transform.GetChild(transform.childCount - 1).position, transform.GetChild(0).position);
    }

    //public Transform GetNextWayPoint (Transform currentWaypoint)
    //{
    //    if (currentWaypoint == null)
    //    {
    //        return transform.GetChild(0);
    //    }
    //    return null;
    //}
}
