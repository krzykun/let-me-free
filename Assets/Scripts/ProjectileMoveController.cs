using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMoveController : MonoBehaviour {
    
    public float ProjectileSpeed { get;  set; } // + is for going left, - for going right. Set by Hen parent Shooter class.

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector2(ProjectileSpeed, 0));
    }
}
