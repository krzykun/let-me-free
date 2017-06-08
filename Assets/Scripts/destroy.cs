using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour {

    public float LifeDuration;
    public int ProjectileHitPenalty = 1;

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, LifeDuration);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            collider.GetComponent<PlayerMoveController>().TakeDamage(ProjectileHitPenalty);
        }

        if ((collider.tag != "hen") && (collider.tag != "deadly"))
        {
            Destroy(this.gameObject);
        }
    }
}
