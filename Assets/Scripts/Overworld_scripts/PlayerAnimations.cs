using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    //all code in this script is from the practical animations task
    public float speed = 1f;

    Animator anim;
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }


  
    void Update()
    {
        if (Input.GetKey("d"))
        {
            anim.SetBool("moving", true);
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetKey("a"))
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
            anim.SetBool("moving", true);
        }
        else if (Input.GetKey("w") || Input.GetKey("s"))
        {
            anim.SetBool("moving", true);
        }
        else
        {
            anim.SetBool("moving", false);
        }
    }

}

