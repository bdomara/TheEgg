/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger,
    idle
}

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Info")]
    public PlayerState currentState;
    public float speed;
    private Vector3 change;
    private Rigidbody2D myRigidbody;
    private Animator animator;

    // TODO HEALTH Break off the health system into its own component

    // public FloatValue currentHealth;

    // TODO INVENTORY break off player inventory into its own component
    public Inventory playerInventory;
    public SpriteRenderer receivedItemSprite;
    public VectorValue startingPosition;


    [Header("Signals")]

    //TODO HEALTH player hit part of health system?
    public Signal playerHit;

    //TODO MAGIC player magic part of payer magic system
    public Signal reduceMagic;
    //public Signal playerHealthSignal;
    */
/*//TODO IFRAME break off IFrame stuff into it's own script
[Header("IFrame stuff")]
public Color flashColor;
public Color regularColor;
public float flashDuration;
public int numberOfFlashes;*/
//public Collider2D triggerCollider;
//public SpriteRenderer mySprite;
/*
    // TODO ABILITY break off with the player ability system
    [Header("Projectiles")]
    public GameObject projectile;
    public InventoryItem bow;


    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
        transform.position = startingPosition.initialValue;
    }

    // Update is called once per frame
    void Update()
    {
        // is the player in interaction
        if (currentState == PlayerState.interact)
        {
            return; // (exit update)
        }
        // change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("actionIcon") && currentState != PlayerState.attack
            && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }
        // TODO ABILITY
        else if (Input.GetButtonDown("SecondItem") && currentState != PlayerState.attack
            && currentState != PlayerState.stagger)
        {
            if (playerInventory.IsItemInInventory(bow))
            {
                StartCoroutine(SecondAttackCo());
            }
        }
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
        }

    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.1f);
        if (currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }

    }

    // TODO ABILITY
    private IEnumerator SecondAttackCo()
    {
        //animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        //MakeArrow();
        //animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.1f);
        if (currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }

    }
    */
// TODO ABILITY this should be part of ability itself
/* private void MakeArrow()
 {
     if (playerInventory.currentMagic > 0)
     {
         Vector2 temp = new Vector2(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
         Arrow arrow = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Arrow>();
         arrow.Setup(temp, ChooseArrowDirection());
         playerInventory.ReduceMagic(arrow.magicCost);
         reduceMagic.Raise();
     }
 }*/
/*
    // TODO ABILITY should be part of ability
    Vector3 ChooseArrowDirection()
    {
        float temp = Mathf.Atan2(animator.GetFloat("moveY"), animator.GetFloat("moveX")) * Mathf.Rad2Deg;
        return new Vector3(0, 0, temp);
    }

    
    public void RaiseItem()
    {
        if (playerInventory.currentItem != null)
        {
            if (currentState != PlayerState.interact)
            {
                animator.SetBool("receive item", true);
                currentState = PlayerState.interact;
                receivedItemSprite.sprite = playerInventory.currentItem.itemSprite;
            }
            else
            {
                animator.SetBool("receive item", false);
                currentState = PlayerState.idle;
                receivedItemSprite.sprite = null;
            }
        }
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            change.x = Mathf.Round(change.x);
            change.y = Mathf.Round(change.y);
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("walking", true);

        }
        else
        {
            animator.SetBool("walking", false);
        }
    }

    void MoveCharacter()
    {
        change.Normalize();
        myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime
        );
    }

    //TODO KNOCKBACK move the knockback to its own script
    public void Knock(float knockTime)
    {
        StartCoroutine(KnockCo(knockTime));

    }

    // TODO move to own script
    private IEnumerator KnockCo(float knockTime)
    {
        playerHit.Raise();
        if (myRigidbody != null)
        {
            //StartCoroutine(FlashCo());
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }
    */
// TODO IFRAMES move to own script
/*private IEnumerator FlashCo()
{
    int temp = 0;
    triggerCollider.enabled = false;
    while(temp < numberOfFlashes)
    {
        mySprite.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        mySprite.color = regularColor;
        yield return new WaitForSeconds(flashDuration);
        temp++;
    }
    triggerCollider.enabled = true;
}
}*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    [SerializeField] private AnimatorController anim;
    [SerializeField] private StateMachine myState;
    [SerializeField] private float WeaponAttackDuration;
    [SerializeField] private ReceiveItem myItem;

    private Vector2 tempMovement = Vector2.down;


    // Start is called before the first frame update
    void Start()
    {
        myState.ChangeState(GenericState.idle);
    }

    // Update is called once per frame
    void Update()
    {
        if (myState.myState == GenericState.receiveItem)
        {
            if (Input.GetButtonDown("ActionIcon"))
            {
                myState.ChangeState(GenericState.idle);
                anim.SetAnimParameter("receive item", false);
                myItem.ChangeSpriteState();
            }
            return;
        }
        GetInput();
        SetAnimation();
    }


    void SetState(GenericState newState)
    {
        myState.ChangeState(newState);
    }


    void GetInput()
    {
        if (Input.GetButtonDown("ActionIcon") && myState.myState != GenericState.receiveItem)
        {
            StartCoroutine(WeaponCo());
            tempMovement = Vector2.zero;
            Motion(tempMovement);
        }
        else if (myState.myState != GenericState.attack)
        {
            tempMovement.x = Input.GetAxisRaw("Horizontal");
            tempMovement.y = Input.GetAxisRaw("Vertical");
            Motion(tempMovement);
        }
        else
        {
            tempMovement = Vector2.zero;
            Motion(tempMovement);
        }
    }

    void SetAnimation()
    {
        if (tempMovement.magnitude > 0)
        {
            anim.SetAnimParameter("moveX", Mathf.Round(tempMovement.x));
            anim.SetAnimParameter("moveY", Mathf.Round(tempMovement.y));
            anim.SetAnimParameter("walking", true);
            SetState(GenericState.walk);
        }
        else
        {
            anim.SetAnimParameter("walking", false);
            if (myState.myState != GenericState.attack)
            {
                SetState(GenericState.idle);
            }
        }
    }

    public IEnumerator WeaponCo()
    {
        myState.ChangeState(GenericState.attack);
        anim.SetAnimParameter("attacking", true);
        yield return new WaitForSeconds(WeaponAttackDuration);
        myState.ChangeState(GenericState.idle);
        anim.SetAnimParameter("attacking", false);
    }
}