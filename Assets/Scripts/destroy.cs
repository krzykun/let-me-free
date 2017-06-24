using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{

    public float LifeDuration;
    public int ProjectileHitPenalty = 1;

	void Start ()
	{
        Destroy(this.gameObject, LifeDuration);
	}

	void Update ()
	{
		
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
		if (collider.tag == "Player")
		{
			if (collider.GetComponent<PlayerMoveController> ().TakeDamage (ProjectileHitPenalty))
			{
				Destroy (this.gameObject);
			}
		}
		else
		{
			if ((collider.tag != "hen") && (collider.tag != "deadly"))
			{
				Destroy (this.gameObject);
			}
		}
    }
}
