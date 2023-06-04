using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private TPMovement TPMovement;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (TPMovement.direction.magnitude >= 0.01f)
            anim.SetBool("isRun",true);
        else
            anim.SetBool("isRun",false);
    }
    
}
