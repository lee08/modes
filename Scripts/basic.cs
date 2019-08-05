using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class basic : MonoBehaviour {
	public float speed = 10.0f;
	public float jumpForce = 10.0f;
	public float jthrust;
	public Rigidbody2D rb;
	public Vector2 movement;
	private float moveInput;
	public bool facingRight = true;

	public bool isGrounded;
	public Transform groundCheck;
	public float checkRadius;
	public LayerMask whatIsGround;

	public int extraJumpValue;
	public int extraJumps;
	public bool jetpack;
	public bool boostjump;
	public bool topdown;
	public bool forced;
	public float gravity = 5f;
	public float justforrocket;
	public float boostmax;
	public float boostmult;
	public float bonus;
	public float remit;
	public bool goleft = false;
	public bool goright = false;
	public bool bashing;
	public bool hrt;
	public string LevelToLoad;
	public float hurtduration = 1f;

	public Animator playanim;

	public int health = 3;

	public GameObject deathEffect;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();	
		if (this.GetComponent<Animator> () != null) {
			playanim = this.GetComponent<Animator> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			if (boostjump) {
				//playanim.Play ("ded");
				playanim.SetBool ("ded",true);
			}
			else if (deathEffect != null) {
				Instantiate (deathEffect, transform.position, Quaternion.identity);
			}
			Invoke("Die",0.5f);
		}
		if (topdown) {
			movement = new Vector2 (Input.GetAxis ("Horizontal")*speed/5f, Input.GetAxis ("Vertical")*speed/5f);
			rb.gravityScale = 0f;
		} else {
			rb.gravityScale = gravity;
			if (jetpack) {
				if (Input.GetButton ("Jump")) {
					rb.AddForce (Vector2.up * jthrust);

				}
			}
				/*else if (forced) {
				if (isGrounded) {
					extraJumps = extraJumpValue;
				}
				if (Input.GetButtonDown ("Jump") && extraJumps > 0) {
					
					rb.AddForce( Vector2.up * jumpForce);
					minusJump ();
				} else if (Input.GetButtonDown ("Jump") && (extraJumps == 0 && isGrounded) || (Input.GetButtonDown ("Jump") && extraJumpValue == -27)) {
					
					rb.AddForce( Vector2.up * jumpForce);
				}
			}*/
			else if (boostjump) {
				Color lerpedColor;
				//hurt = true;
				if (hrt) {
					hurtduration -= Time.deltaTime;
					if (hurtduration > 0f) {
						lerpedColor = Color.Lerp (Color.white, new Color(1.0F, 0.0F, 0.0F, 0.5F), Mathf.PingPong (Time.time * 2f, 1));
						this.GetComponent<SpriteRenderer> ().color = lerpedColor;
						Debug.Log (hurtduration);
					} else {
						Debug.Log ("bap");
						hrt = false;
					}
				}
				if (!hrt) {
					Debug.Log ("bip");
					this.GetComponent<SpriteRenderer> ().color = Color.white;
					hurtduration = 3f;
				}
				if (isGrounded) {
					extraJumps = extraJumpValue;
				}
					
				if (Input.GetButtonDown ("Jump")) {
					
					if ((extraJumps > 0) || (extraJumps == 0 && isGrounded)||bonus > 0f) {
						rb.velocity = new Vector2 (0f, 0f);
						rb.velocity = Vector2.up * (jumpForce + bonus * boostmult);
						if (bonus > 0f) {
							playanim.SetTrigger ("uppercut");
//							playanim.ResetTrigger ("charge");
						} else {
							playanim.SetTrigger ("jump");
						}
						if (extraJumps > 0) {
							minusJump ();
						}
					}
					bonus = 0f;
					remit = 0f;
				}
				if (bonus > 0f) {
					if (!(remit > 0f && (goleft || goright))) {
						remit = bonus;
					}

					if ((Input.GetKeyDown ("left") || Input.GetKeyDown ("a") || Input.GetKeyDown ("j"))&&!goright) {
						//BoostHori (true);
						goleft = true;
					} else if ((Input.GetKeyDown ("right") || Input.GetKeyDown ("d") || Input.GetKeyDown ("l"))&&!goleft) {
						//BoostHori (false);
						goright = true;
					}

				}

				if (((Input.GetKey ("left") || Input.GetKey ("a")|| Input.GetKey ("j")) && (Input.GetKey ("right") || Input.GetKey ("d")|| Input.GetKey ("l"))&&Input.GetButton("Jump"))&&isGrounded) {
					rb.velocity = new Vector2 (0f, 0f);
					bonus += Time.deltaTime;
					playanim.SetTrigger ("charge");
					playanim.SetBool ("punchh", true);
					if (bonus > boostmax) {
						bonus = boostmax;
					}
				} else {
					//bonus = 0f;
				}
				if (remit > 0f && (goleft || goright)) {
					//Debug.Log (Input.GetAxis("Horizontal"));
					remit -= (Time.deltaTime * 4.0f);
				}

			}

			else {
				if (isGrounded) {
					extraJumps = extraJumpValue;
				}
				if (Input.GetButtonDown ("Jump") && extraJumps > 0) {
					rb.velocity = new Vector2 (0f, 0f);
					rb.velocity = Vector2.up * jumpForce;
					minusJump ();
				} else if (Input.GetButtonDown ("Jump") && (extraJumps == 0 && isGrounded) || (Input.GetButtonDown ("Jump") && extraJumpValue == -27)) {
					rb.velocity = new Vector2 (0f, 0f);
					rb.velocity = Vector2.up * jumpForce;
				}
			}


		}

	}
	void FixedUpdate(){
		if (topdown) {
			moveCharacter (movement);
		} else if (forced) {
			isGrounded = Physics2D.OverlapCircle (groundCheck.position, checkRadius, whatIsGround);

			moveInput = Input.GetAxis ("Horizontal");

				//Vector2 summ = new Vector2();
				float uhhh;
				if (isGrounded) {
					uhhh = moveInput * speed;
				justforrocket = 0f;
				} else {
					uhhh = moveInput * speed + (justforrocket/200f);
				}
				rb.velocity = new Vector2 (uhhh, rb.velocity.y);

		} else {
			isGrounded = Physics2D.OverlapCircle (groundCheck.position, checkRadius, whatIsGround);

			moveInput = Input.GetAxis ("Horizontal");
			//if (Mathf.Abs (moveInput) > 0f) {
			if (boostjump) {
				playanim.SetBool ("grounded", ((Mathf.Abs(rb.velocity.y) < 3f)&&bonus<=0f));
				if (Mathf.Abs (rb.velocity.y) < 3f && bonus <= 0f) {
					playanim.ResetTrigger ("uppercut");
					playanim.ResetTrigger ("jump");
					playanim.ResetTrigger ("charge");
					playanim.SetBool ("punchh", false);
				}
				if (remit > 0f&&(goleft||goright)) {
					
					rb.gravityScale = 0f;
					if (speed * 5f * bonus>30f) {
						bashing = true;
					}
					playanim.SetTrigger ("punch");

					if (goleft) {
						//rb.AddForce (Vector2.left * speed * 500.0f);
						rb.velocity = new Vector2 (speed*-5f*bonus, 0.0f);
					} else {
						//rb.AddForce (Vector2.right * speed * 500.0f);
						rb.velocity = new Vector2 (speed*5f*bonus, 0.0f);
					}
				} else if (!(remit > 0f)) {
					rb.gravityScale = gravity;
					playanim.ResetTrigger ("punch");
					goleft = false;
					goright = false;
					bashing = false;
					bonus = 0f;
					rb.velocity = new Vector2 (moveInput * speed, rb.velocity.y);
					if (Input.GetAxisRaw ("Horizontal") == 0) {
						playanim.SetBool ("walk", false);
					} else {
						playanim.SetBool ("walk",true);
					}
				}
			} else {
				rb.velocity = new Vector2 (moveInput * speed, rb.velocity.y);
			}
				/*(boostjump && ((Input.GetKey ("left")||Input.GetKey ("a")) && (Input.GetKey ("right")||Input.GetKey ("d"))&&Input.GetButton("Jump"))) {
				//rb.velocity = new Vector2 (moveInput * speed/4.0f, rb.velocity.y);

			} else if (boostjump && (((Input.GetKeyUp ("left")||Input.GetKeyUp ("a")||Input.GetKeyUp ("j")) && (Input.GetKey ("right")||Input.GetKey ("d")||Input.GetKey ("l")))||((Input.GetKey ("left")||Input.GetKey ("a")||Input.GetKey ("j")) && (Input.GetKeyUp ("right")||Input.GetKeyUp ("d")||Input.GetKeyUp ("l"))))) {
				bonus -= Time.deltaTime;
				if (bonus > 0.0f) {
					rb.velocity = new Vector2 (Input.GetAxisRaw ("Horizontal") * speed * 4.0f, rb.velocity.y);
				}
			}*/ 
			//}
		}


		if (facingRight == false && moveInput > 0) {
			Flip ();
		} else if (facingRight == true && moveInput < 0) {
			Flip ();
		}
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;
	}
	public virtual void minusJump(){
		extraJumps--;
	}

	void moveCharacter(Vector2 direction){
		rb.velocity = direction * speed;
	}
	void Die(){
		if (LevelToLoad != "") {
			SceneManager.LoadScene (LevelToLoad);
		} else {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
	}
	void BoostDie(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
	void BoostHori(bool uhh){
		

	}
}
