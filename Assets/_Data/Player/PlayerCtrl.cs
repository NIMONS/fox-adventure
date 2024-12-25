using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : FoxMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model => model;

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadModel();
	}


	protected void LoadModel()
	{
		if (this.model != null) return;
		this.model = transform.Find("Model");
		Debug.LogWarning(transform.name + ": LoadModel", gameObject);
	}
}
