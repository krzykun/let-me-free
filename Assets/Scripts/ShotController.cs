using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{

    public float ShootPeriod;
    public GameObject HenProjectileRight;
    public GameObject HenProjectileLeft;
    public float ProjectileSpeed;
    
    public AudioSource [] _audioSources;

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
            yield return new WaitForSeconds(ShootPeriod + Random.Range(-1.0f, 1.0f));

			_audioSources[Random.Range(0, _audioSources.Length)].Play();

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
