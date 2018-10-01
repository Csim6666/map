using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieAction2 : MonoBehaviour {
    public Transform player;
    float speed;
    private CharacterController cc;
    private AnimatorStateInfo currentState;
    private int AttackState = Animator.StringToHash("Base Layer.Zombie Attack");

    static Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        speed = 2.0f;
        cc = this.transform.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        currentState = anim.GetCurrentAnimatorStateInfo(0);

        if (Vector3.Distance(this.transform.position, player.position) < 20)
        {
            Vector3 direction = player.position - this.transform.position;
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("isIdle", false);

            if (direction.magnitude > 2)
            {
                if (currentState.nameHash != AttackState)
                {
                    anim.SetBool("isWalking", true);
                    anim.SetBool("isAttacking", false);

                    cc.SimpleMove(transform.TransformDirection(speed * Vector3.forward));
                }
                else
                {
                    anim.SetBool("isWalking", true);
                }

            }
            else
            {

                anim.SetBool("isWalking", false);
                anim.SetBool("isAttacking", true);
            }

        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
        }
    }
}
