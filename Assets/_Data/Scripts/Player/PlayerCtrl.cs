using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : FoxMonoBehaviour
{
    [SerializeField] protected  PlayerMovement model;
    public PlayerMovement Model => model;

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadPlayerMovement();
	}


	protected void LoadPlayerMovement()
	{
		if (this.model != null) return;
		this.model = transform.GetComponentInChildren<PlayerMovement>();
		Debug.LogWarning(transform.name + ": LoadPlayerMovement", gameObject);
	}
}
