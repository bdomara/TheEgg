/*using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(menuName = "ScriptableObjects/Abilities/Dash Ability", fileName = "Dash Ability")]

public class DashAbility : GenericAbility
{
    public float dashForce;

    public override void Ability(Vector2 playerPosition, Vector2 playerFacingDirection,
        Animator playerAnimator = null, Rigidbody2D playerRigidbody = null)
    {
        // make sure the player has enough magic
        if(playerMagic.initialValue >= magicCost)
        {
            playerMagic.initialValue -= magicCost;
            usePlayerMagic.Raise();
        }
        else
        {
            return;
        }
        if (playerRigidbody)
        {
            Vector3 dashVector = playerRigidbody.transform.position +
                (Vector3)playerFacingDirection * dashForce;
            playerRigidbody.DOMove(dashVector, duration);
        }
    }
}*/
