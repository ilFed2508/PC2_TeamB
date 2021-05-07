using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSetFalse : MonoBehaviour
{
    public Animator EnemyAnim;

    public void Start()
    {
        
    }
    public void FalseBool()
    {
        EnemyAnim.SetBool("Hit", false);
    }
}
