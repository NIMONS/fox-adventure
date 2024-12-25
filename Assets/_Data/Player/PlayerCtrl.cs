using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : FoxMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model => model;
	[SerializeField] protected PlayerMovement playerMovement;
	public PlayerMovement PlayerMovement => playerMovement;


	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadModel();
		this.LoadPlayerMovement();
	}

	protected void LoadPlayerMovement()
	{
		if (this.playerMovement != null) return;
		this.playerMovement = transform.GetComponentInChildren<PlayerMovement>();
		Debug.LogWarning(transform.name + ": LoadPlayerMovement", gameObject);
	}

	protected void LoadModel()
	{
		if (this.model != null) return;
		this.model = transform.Find("Model");
		Debug.LogWarning(transform.name + ": LoadModel", gameObject);
	}
}
