using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollow : Movement
{
    [SerializeField] private StateMachine currentState;
    [SerializeField] private AnimatorController anim;
    [SerializeField] private string targetTag;
    private Transform target;
    [SerializeField] private float chaseRadius;
    [SerializeField] private float attackRadius;
    [SerializeField] private Vector3 homePosition;
    private float targetDistance;
    private float homingDistance;
    private float homeRange = .5f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = homePosition;
        target = GameObject.FindGameObjectWithTag(targetTag).GetComponent<Transform>();
        currentState.ChangeState(GenericState.idle);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        targetDistance = Vector3.Distance(transform.position, target.position);
        if (targetDistance < chaseRadius && targetDistance > attackRadius)
        {
            Vector2 temp = (Vector2)(target.position - transform.position);
            SetAnimFloat(temp);
            anim.SetAnimParameter("wakeUp", true);
            currentState.ChangeState(GenericState.walk);
            Motion(temp);
        }
        else
        {
            homingDistance = Vector3.Distance(transform.position,homePosition);
            if(homingDistance <= homeRange)
            {
                transform.position = homePosition;
                anim.SetAnimParameter("wakeUp", false);
            }
            Vector2 temp = (Vector2)(homePosition - transform.position);
            SetAnimFloat(temp);
            Motion(temp);

        }
    }

    public void SetAnimFloat(Vector2 setVector)
    {
        anim.SetAnimParameter("moveX", setVector.x);
        anim.SetAnimParameter("moveY", setVector.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
}
