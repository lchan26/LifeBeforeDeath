using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;


/// <summary>
/// Eyes check for set targets on a timer
/// When targets are seen, an event is called that passes in the GameObject that was seen
/// You can also cycle through the targets that were seen in the last check with GetSeenTargets()
/// </summary>
public class Eyes : MonoBehaviour
{

    public UnityEvent<GameObject> onSeeTarget = new UnityEvent<GameObject>();

    [SerializeField, Tooltip("Range to see targets")] 
    private float viewRange = 20.0f;

    [SerializeField, Tooltip("Angle to see targets")]
    private float viewAngle = 60.0f; 

    [SerializeField, Tooltip("Collision masks to hit for raycast")] 
    private LayerMask hitLayerMask;

    [SerializeField, Tooltip("Current objects to check if in sight")] 
    private List<GameObject> targets = new List<GameObject>();

    [SerializeField, Tooltip("How long to wait before checking for targets again")]
    private float checkForTargetTime = 0.3f;
    private float currentCheckForTargetTime;


    private HashSet<GameObject> inSight = new HashSet<GameObject>();

    private Collider myCollider;



    private void Start()
    {
        currentCheckForTargetTime = checkForTargetTime;
        myCollider = GetComponent<Collider>();
    }


    void Update()
    {

        // Check for targets on a timer
        currentCheckForTargetTime -= Time.deltaTime;
        if (currentCheckForTargetTime <= 0)
        {
            CheckTargets();
            currentCheckForTargetTime = checkForTargetTime;
        }
    }



    /// <summary>
    /// Cycles through targets and sees if their in range 
    /// </summary>
    /// Thx https://www.youtube.com/watch?v=rQG9aUWarwE for some help
    public void CheckTargets()
    {

        // Clear targets that are in sight
        inSight.Clear();

        bool prevColliderEnabled = true;
        if (myCollider != null)
        {
            // Disable this game objects collider (so the raycast doesn't collide with itself) 
            prevColliderEnabled = myCollider.enabled;
            myCollider.enabled = false;
        }

        // Go through each target
        foreach (GameObject target in targets)
        {

            // Cast a ray in the direction of the target for the distance of the view range
            Vector3 direction = (target.transform.position - transform.position).normalized;

            float angle = Vector3.Angle(transform.forward, direction);

            if (angle < viewAngle / 2)
            {

                Physics.Raycast(transform.position, direction, out RaycastHit hit, viewRange, hitLayerMask, QueryTriggerInteraction.Ignore);
                print("In angle");

                // If it hits, send an event for when a target is seen
                if (hit.collider != null && hit.collider.gameObject.Equals(target))
                {
                    inSight.Add(target);
                    onSeeTarget.Invoke(target);
                }
            }
        }
        print("Checking targets");

        if (myCollider != null)
        {
            // Set collider enabled value to old enabled value (in case it was disabled before)
            myCollider.enabled = prevColliderEnabled;
        }
    }

    /// <summary>
    /// Gets a reference to the hashset of all targets in sight (since the last target check)
    /// </summary>
    /// <returns>Ready only hashset of targets in range</returns>
    public ref HashSet<GameObject> GetSeenTargets()
    {
        return ref inSight;
    }

    

    private void OnDrawGizmosSelected()
    {
        // Draws the area the eyes can see
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, viewRange);

        Vector3 pos = transform.position;
        Vector3 right = new Vector3(Mathf.Sin(Mathf.Deg2Rad * viewAngle / 2), 0, 0);
        Vector3 up = new Vector3(0, Mathf.Sin(Mathf.Deg2Rad * viewAngle / 2), 0);

        Gizmos.DrawLine(pos, pos + transform.forward * viewRange);
        Gizmos.DrawLine(pos, pos + (transform.forward + right + up).normalized * viewRange);
        Gizmos.DrawLine(pos, pos + (transform.forward + right - up).normalized * viewRange);
        Gizmos.DrawLine(pos, pos + (transform.forward - right + up).normalized * viewRange);
        Gizmos.DrawLine(pos, pos + (transform.forward - right - up).normalized * viewRange);

        Gizmos.DrawLine(pos, pos + (transform.forward + up).normalized * viewRange);
        Gizmos.DrawLine(pos, pos + (transform.forward - up).normalized * viewRange);
        Gizmos.DrawLine(pos, pos + (transform.forward + right).normalized * viewRange);
        Gizmos.DrawLine(pos, pos + (transform.forward - right).normalized * viewRange);
    }



}
