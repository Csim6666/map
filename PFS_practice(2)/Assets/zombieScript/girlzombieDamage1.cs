using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girlzombieDamage1 : MonoBehaviour {

    public float fullBlood;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(fullBlood <= 0)
        {
            this.gameObject.SetActive(false);
        }
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.transform.tag == "rocket")
        {
            fullBlood -= 20;
        }
    }
}
