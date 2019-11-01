using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEnemy : Movement
{
    [SerializeField] public Collider2D boundary;
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


    void FixedUpdate()
    {
        targetDistance = Vector3.Distance(transform.position, target.position);

        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius
            && boundary.bounds.Contains(target.transform.position))
        {
            Vector2 temp = (Vector2)(target.position - transform.position);
            SetAnimFloat(temp);
            anim.SetAnimParameter("wakeUp", true);
            currentState.ChangeState(GenericState.walk);
            Motion(temp);
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius
           || !boundary.bounds.Contains(target.transform.position))
        {
            Vector2 temp = Vector2.zero;
            anim.SetAnimParameter("wakeUp", false);
            Motion(temp);
        }
    }

    public void SetAnimFloat(Vector2 setVector)
    {
        anim.SetAnimParameter("moveX", setVector.x);
        anim.SetAnimParameter("moveY", setVector.y);
    }
}
