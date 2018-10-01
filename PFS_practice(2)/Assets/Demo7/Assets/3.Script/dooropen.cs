using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dooropen : MonoBehaviour {

    float openTimer = 0.0f;
    Transform thedoor;
    Animation anim;

    bool open = false;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (open)
        {
            openTimer += Time.deltaTime;

            if (openTimer >= 2)
            {
                anim.Play("down");
                open = false;
                openTimer = 0.0f;
            }
        }
	}

    void OnControllerColliderHit(ControllerColliderHit col)
    {
        if(col.gameObject.tag == "door")
        {
            anim = col.transform.parent.GetComponent<Animation>();

            if (open == false && !anim.isPlaying)
            {
                anim.Play("open");
                open = true;
            }
     
        }
    }
}
