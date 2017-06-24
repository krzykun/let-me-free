using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{

    public float ShootPeriod;
    public GameObject HenProjectileRight;
    public GameObject HenProjectileLeft;
    public float ProjectileSpeed;

	private AudioSource _audioSource;

	void Start ()
	{
		_audioSource = GetComponent<AudioSource> ();
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

			_audioSource.Play ();

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
