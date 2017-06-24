using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{

	public float velCoeff = 1.0f;
	public int health = 6;
    public Vector2 startPosition;
    public Vector2 endPosition;
    public int HenHitPenalty = 1;
    public Animation JumpAnimation;
    public float JumpDuration = 1.0f;
    public Sprite[] PlayerSprites;
    public Sprite[] WalkRightSprites;
    public Sprite[] WalkLeftSprites;
    private bool isJumping = false;

    void Start ()
	{
        JumpAnimation = this.GetComponent<Animation>();
	}

    // TODO This is triggered once the player reaches endPosition
    void LevelWonTransition()
    {
        Debug.Log("LEVEL CLEARED - add transition here");
    }

    // TODO This is a trigger function for the 'game over' scene transition
    void GameOverTransition()
    {
        Debug.Log("GAME OVER - add transition here");
    }

	void FixedUpdate ()
	{
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * velCoeff;
		var y = Input.GetAxis("Vertical") * Time.deltaTime * velCoeff;

        if (Input.GetKeyDown("space"))
        {
            jump();
        }

        if ( x == 0)
        {
        }
        else
        {
            if ( x < 0)
            {
                Debug.Log("x < 0");
                GetComponent<SpriteRenderer>().sprite = WalkLeftSprites[health - 1];
            }
            else
            {
                Debug.Log("x > 0");
                GetComponent<SpriteRenderer>().sprite = WalkRightSprites[health - 1];
            }

        }

		transform.Translate(x, y, 0);
	}

    void jump()
    {
        JumpAnimation.Play("JumpAnimation");
        StartCoroutine(DisableCollisionWhileJumping());
    }
    
    IEnumerator DisableCollisionWhileJumping()
    {
        isJumping = true;
        
        // Disable collision with every Hen
        GameObject[] HenArray = GameObject.FindGameObjectsWithTag("hen");
        foreach (var Hen in HenArray)
        {
            Physics2D.IgnoreCollision(Hen.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
        }

        //this.GetComponent<Collider2D>();
        yield return new WaitForSeconds(JumpDuration);
        
        // Enable collision with every Hen
        foreach (var Hen in HenArray)
        {
            Physics2D.IgnoreCollision(Hen.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
        }

        isJumping = false;
    }

    /*
     * Returns true if player should take damage, false if player is immune to damage
     */
    public bool TakeDamage(int DamageValue)
    {
        if (!isJumping)
        {
            health -= DamageValue;
            Debug.Log("Player took " + DamageValue + " points of damage. Current health: " + health);
            if (health > 0)
            {
                GetComponent<SpriteRenderer>().sprite = PlayerSprites[health - 1];
                //todo sprite change
                //GameOverTransition();
                //health = 6; //TODO This is the defeat condition
                //GetComponent<SpriteRenderer>().sprite = PlayerSprites[health - 1];
            }
            return true;
        }
        else return false;
        
    }

	void OnCollisionEnter2D(Collision2D collObj)
	{
		if ((collObj.gameObject.tag == "hen") || (collObj.gameObject.tag == "deadly"))
		{
            TakeDamage(HenHitPenalty);
        }
	}
}
