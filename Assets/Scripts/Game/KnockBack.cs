using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class KnockBack : MonoBehaviour
{
    [SerializeField] private float thrust;
    [SerializeField] private float knockTime;
    [SerializeField] private string otherTag;
    // public float damage;

    /*private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag(otherTag) && other.isTrigger)
        {
            Rigidbody2D hit = other.GetComponentInParent<Rigidbody2D>();
            if (hit != null)
            {
                Vector3 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                hit.DOMove(hit.transform.position + difference, knockTime);
                //hit.AddForce(difference, ForceMode2D.Impulse);
                
                if (other.gameObject.CompareTag("enemy") && other.isTrigger)
                {
                    hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    other.GetComponent<Enemy>().Knock(hit, knockTime);

                }
                
                if(other.gameObject.CompareTag("Player"))
                {
                    if(other.GetComponentInParent<PlayerMovement>().currentState != PlayerState.stagger)
                    {
                        hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                        other.GetComponentInParent<PlayerMovement>().Knock(knockTime);
                    }
                }
                

            }

        }
    }*/

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag) && other.isTrigger)
        {
            Rigidbody2D temp = other.GetComponentInParent<Rigidbody2D>();
            if (temp)
            {
                Vector2 direction = other.transform.position - transform.position;
                temp.DOMove((Vector2)other.transform.position +
                    (direction.normalized * thrust), knockTime);
            }
        }
    }

}
