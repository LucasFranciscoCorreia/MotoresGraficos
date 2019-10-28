using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public void Jumping()
    {
        
    }

    public void OnGround()
    {
        GetComponentInParent<CharacterScript>().isJumping = false;
    }
}
