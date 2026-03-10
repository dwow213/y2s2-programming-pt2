using NodeCanvas.Framework;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class GuardFindsAT : ActionTask 
	{


		//Called once per frame while the action is active.
		protected override void OnUpdate() 
		{
			Debug.Log("nothing");
			agent.gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
		}
	}
}