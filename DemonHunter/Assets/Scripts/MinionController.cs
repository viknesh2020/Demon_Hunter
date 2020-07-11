using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionController : MonoBehaviour
{

    public Transform player;
    private Vector3 center;
    public float attackRangeDiameter;
    private float attackRangeRadius;

    public float minionSpeedOnCalm;
    public float minionSpeedOnAggression;

    private float hitDistance;

    int layerMask;

    // Start is called before the first frame update
    void Start()
    {
        
  
    }

    // Update is called once per frame
    void Update()
    {
        layerMask = 1 << 9;
        attackRangeRadius = attackRangeDiameter / 2;

        this.gameObject.GetComponent<NavMeshAgent>().speed = minionSpeedOnCalm;

        center = transform.position;
        RaycastHit hit;

        if (Physics.SphereCast(center, attackRangeRadius, transform.forward, out hit, 100.0f, layerMask, QueryTriggerInteraction.UseGlobal))
        {

            hitDistance = hit.distance;
            /*this.gameObject.GetComponent<NavMeshAgent>().SetDestination(player.position);
            this.gameObject.GetComponent<NavMeshAgent>().speed = minionSpeedOnAggression;*/
            Debug.Log("Range Reached");
        }
        else {

            hitDistance = 100.0f;

        }
               
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(center, (center + transform.forward) * hitDistance);
        Gizmos.DrawWireSphere((center + transform.forward) * hitDistance, attackRangeRadius);
    }
}
