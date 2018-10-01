using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girlzombieAction1 : MonoBehaviour {

    public Transform player;
    private CharacterController cc;
    private AnimatorStateInfo currentState;
    private int AttackState = Animator.StringToHash("Base Layer.Zombie Neck Bite");
    public float speed;

    static Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        cc = this.transform.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        
        currentState = anim.GetCurrentAnimatorStateInfo(0);

        if (Vector3.Distance(this.transform.position, player.transform.position) < 20 && Physics.Linecast(this.transform.position, player.transform.position))
        {
            Vector3 direction = (player.transform.position - this.transform.position);
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("isIdle", false);

            if (direction.magnitude > 2)
            {
                if(currentState.nameHash != AttackState)
                {
                    cc.SimpleMove(transform.TransformDirection(Vector3.forward * speed));
                    anim.SetBool("isRunning", true);
                    anim.SetBool("isAttacking", false);
                }
                else
                {
                    anim.SetBool("isRunning", true);
                }
            }
            else
            {
                anim.SetBool("isRunning", false);
                anim.SetBool("isAttacking", true);
            }
        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("isAttacking", false);
        }
	}


}
