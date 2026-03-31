using System.Collections.Generic;
using NodeCanvas.Framework;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class GetEggTargetAT : ActionTask 
	{
		public BBParameter<GameObject> eggsHolderBBP;
		public BBParameter<GameObject> eggTargetBBP;

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnUpdate() 
		{
			List<GameObject> eggs = new List<GameObject>();
			for (int i = 0; i < eggsHolderBBP.value.transform.childCount; i++)
			{
				eggs.Add(eggsHolderBBP.value.transform.GetChild(i).gameObject);
			}

			eggTargetBBP.value = eggs[Random.Range(0, eggs.Count - 1)];
			EndAction(true);
		}


	}
}