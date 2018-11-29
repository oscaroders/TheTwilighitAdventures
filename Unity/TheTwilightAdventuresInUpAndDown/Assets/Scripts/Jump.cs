using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public bool invertedJump;
	public float jumpMaxTime = 0.3f;
	public float jumpSpeed = 1f;
	float jumpTime;
	float jumpMaxTimer;
	public bool isJumping;
    bool holdingButton;
	Rigidbody2D rb2D;

	// Use this for initialization
	void Start ()
	{
		rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	public void Jumping (bool jumpValue)
	{

        if (jumpValue)
        {
            holdingButton = true;
        }
        
        if (holdingButton && !isJumping)
		{
			isJumping = true;
            
			jumpMaxTimer = Time.time + jumpMaxTime;
			jumpTime = 0;
		}

		if (holdingButton && Time.time < jumpMaxTimer && isJumping)
		{
			jumpTime += Time.deltaTime;

            if(invertedJump)
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, -jumpSpeed);
            }
            else
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
            }
			

			if (jumpTime < 0.45f)
			{
				if (jumpSpeed < 8)
				{
					jumpSpeed *= 1.2f;
				}
			}
			else
			{
				jumpSpeed *= 0.8f;
			}
		}

		if (!holdingButton)
		{
			jumpMaxTimer = 0;
			jumpSpeed = 1f;
		}
	}
    public void SetButtonRelease(bool isUp)
    {
        if(isUp)
        {
            holdingButton = false;
        }
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
		isJumping = false;
        holdingButton = false;

    }
}
