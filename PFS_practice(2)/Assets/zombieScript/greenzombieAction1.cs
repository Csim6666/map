using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenzombieAction1 : MonoBehaviour {
    public Transform player;
    private CharacterController cc;
    static Animator anim;
    private AnimatorStateInfo currentState;
    private int AttackState = Animator.StringToHash("Base Layer.attack");

    private float speed;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        cc = this.transform.GetComponent<CharacterController>();
        speed = 3.0f;
    }
	
	// Update is called once per frame
	void Update () {
        currentState = anim.GetCurrentAnimatorStateInfo(0);

        if (Vector3.Distance(this.transform.position, player.position) < 20 && Physics.Linecast(transform.position, player.transform.position))
        {
            Vector3 direction = player.position - this.transform.position;
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("isIdle", false);

            if (direction.magnitude > 2)
            {
                if (currentState.nameHash != AttackState)
                {
                    cc.SimpleMove(transform.TransformDirection(Vector3.forward * speed));
                    anim.SetBool("isWalking", true);
                    anim.SetBool("isAttacking", false);
                }
                else{
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
