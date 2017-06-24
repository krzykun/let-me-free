using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMoveController : MonoBehaviour
{
    public float ProjectileSpeed { get;  set; } // + is for going left, - for going right. Set by Hen parent Shooter class.

    void Start ()
	{
		
	}

	void Update ()
	{
        transform.Translate(new Vector2(ProjectileSpeed, 0));
    }
}
