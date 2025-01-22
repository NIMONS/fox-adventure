using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMovement : FoxMonoBehaviour
{
	[SerializeField] protected PlayerCtrl playerCtrl;
	[SerializeField] protected Rigidbody2D _rigidbody2D;
	[SerializeField] protected BoxCollider2D _collider2D;
	[SerializeField] protected Animator _animator;
	public Animator Animator => _animator;

	[SerializeField] protected float moveSpeed = 9f;
	[SerializeField] protected float jumpForce = 8f;

	private bool canDoubleJump =false;
	private bool isGrounded;

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadRigidbody2D();
		this.LoadPlayerCtrl();
		this.LoadBoxCollider2D();
		this.LoadAnimator();
	}

	protected void LoadAnimator()
	{
		if (_animator != null) return;
		this._animator = transform.GetComponent<Animator>();
		Debug.LogWarning(transform.name + ": LoadAnimator", gameObject);
	}

	protected void LoadBoxCollider2D()
	{
		if (_collider2D != null) return;
		this._collider2D = transform.GetComponent<BoxCollider2D>();
		Debug.LogWarning(transform.name + ": LoadBoxCollider2D", gameObject);
	}

	protected void LoadPlayerCtrl()
	{
		if (playerCtrl != null) return;
		this.playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
		Debug.LogWarning(transform.name + ": LoadPlayerCtrl", gameObject);
	}

	protected void LoadRigidbody2D()
	{
		if (_rigidbody2D != null) return;
		this._rigidbody2D = transform.GetComponent<Rigidbody2D>();
		this._rigidbody2D.gravityScale = 2.9f;

		Debug.LogWarning(transform.name + ": LoadRigidbody2D", gameObject);
	}



	protected override void Update() 
	{
		this.Animation();
		this.HandleInput();

	}

	protected void HandleInput()
	{
		float horizontal = Input.GetAxis("Horizontal");

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Jump();
		}

		if (Input.GetKey(KeyCode.A))
		{
			transform.localScale = new Vector3(-5f, 5f, 5f);
			_animator.SetBool("isRun", true);
		}else if (Input.GetKey(KeyCode.D))
		{
			transform.localScale = new Vector3(5f, 5f, 5f);
			_animator.SetBool("isRun", true);
		}
		
		else
		{
			_animator.SetBool("isRun", false);

		}

		_rigidbody2D.velocity = new Vector2(horizontal * moveSpeed, _rigidbody2D.velocity.y);
		
		_rigidbody2D.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
	}

	private void Jump()
	{
		if (isGrounded)
		{
			_rigidbody2D.velocity= new Vector2(this._rigidbody2D.velocity.x, jumpForce);
			canDoubleJump = true;
			this._animator.SetBool("isJumping", true);
			this._animator.SetBool("isFalling", false);
		}else if (canDoubleJump)
		{
			_rigidbody2D.velocity = new Vector2(this._rigidbody2D.velocity.x, jumpForce);
			canDoubleJump = false;
			this._animator.SetTrigger("isDoubleJump");
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Ground"))
		{
			isGrounded = true;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Ground"))
		{
			isGrounded = false;
		}
	}

	protected void Animation()
	{
		Debug.Log(this._rigidbody2D.velocity.y);
		if(!isGrounded && this._rigidbody2D.velocity.y < 0)
		{
			this._animator.SetBool("isJumping", true);
			this._animator.SetBool("isFalling", false);
			this._animator.SetBool("isDoubleJump", false);
		}

		if (isGrounded)
		{
			this._animator.SetBool("isJumping", false);
			this._animator.SetBool("isFalling", false);
		}
	}
}
