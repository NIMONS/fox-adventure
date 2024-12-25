using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : FoxMonoBehaviour
{
	[SerializeField] protected PlayerCtrl playerCtrl;

	[SerializeField] protected float moveSpeed = 10f;
	[SerializeField] protected float jumpForce = 10f;
	[SerializeField] protected LayerMask groundLayer; // Lớp cho mặt đất
	private Rigidbody2D rb;
	private bool isGrounded;

	protected void Start()
	{
		rb = this.playerCtrl.Model.GetComponent<Rigidbody2D>();
	}

	protected void Update() // Chuyển từ FixedUpdate sang Update
	{
		this.HandleInput(); // Xử lý input trong Update
		this.CheckGrounded(); // Kiểm tra nếu player đang trên mặt đất
	}

	protected void HandleInput()
	{
		float horizontal = Input.GetAxis("Horizontal");

		// Nhảy chỉ khi nhấn phím Space và đang trên mặt đất
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Jump();
		}

		// Di chuyển player
		rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
	}

	private void Jump()
	{
		rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
	}

	// Kiểm tra nếu player đang trên mặt đất
	protected void CheckGrounded()
	{
		isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, groundLayer);
	}
}
