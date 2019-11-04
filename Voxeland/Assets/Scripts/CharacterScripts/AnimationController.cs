using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    CharacterScript character;

    void Start()
    {
        character = GetComponentInParent<CharacterScript>();    
    }
    public void Jumping()
    {
        
    }

    public void OnGround()
    {
        character.isJumping = false;
    }

    public void FinishAttack()
    {
        character.isAttacking = false;
    }
}
