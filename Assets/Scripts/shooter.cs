using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour {

    public float ShootPeriod;
    public GameObject HenProjectile;
    public float ProjectileSpeed;

	// Use this for initialization
	void Start () {
        StartCoroutine(shoots());
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    IEnumerator shoots()
    {
        while (true)
        {
            yield return new WaitForSeconds(ShootPeriod);

            GameObject newProjectile = (GameObject)Instantiate(HenProjectile, transform.position, Quaternion.identity);
            if (this.gameObject.GetComponent<HenMoveController>().goingLeft)
            {
                newProjectile.GetComponent<ProjectileMoveController>().ProjectileSpeed = ProjectileSpeed;
            }
            else
            {
                newProjectile.GetComponent<ProjectileMoveController>().ProjectileSpeed = -ProjectileSpeed;
            }
            
        }
    }
}
