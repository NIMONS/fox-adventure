using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : FoxMonoBehaviour
{
    [SerializeField] protected PlayerCtrl playerCtrl;

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadPlayerCtrl();
	}

	protected void LoadPlayerCtrl()
	{
		if (this.playerCtrl != null) return;
		this.playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
		Debug.LogWarning(transform.name + ": LoadPlayerCtrl", gameObject);
	}

	protected override void Update()
	{
		base.Update();
		this.Animation();
	}

	protected void Animation()
	{
		Animator animator = playerCtrl.Model.Animator;
		//if (animator.GetBool("isRun"))
		//{
		//	//de
		//}
	}
}
