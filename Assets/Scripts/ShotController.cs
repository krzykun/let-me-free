using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{

    public float ShootPeriod;
    public GameObject HenProjectileRight;
    public GameObject HenProjectileLeft;
    public float ProjectileSpeed;

	void Start ()
	{
        StartCoroutine(shoots());
	}

	void Update ()
	{
		
	}

    IEnumerator shoots()
    {
        while (true)
        {
            yield return new WaitForSeconds(ShootPeriod);

            if (this.gameObject.GetComponent<HenMoveController>().goingLeft)
            {
                GameObject newProjectile = (GameObject)Instantiate(HenProjectileLeft, transform.position, Quaternion.identity);
                newProjectile.GetComponent<ProjectileMoveController>().ProjectileSpeed = ProjectileSpeed;
            }
            else
            {
                GameObject newProjectile = (GameObject)Instantiate(HenProjectileRight, transform.position, Quaternion.identity);
                newProjectile.GetComponent<ProjectileMoveController>().ProjectileSpeed = -ProjectileSpeed;
            }
            
        }
    }
}
