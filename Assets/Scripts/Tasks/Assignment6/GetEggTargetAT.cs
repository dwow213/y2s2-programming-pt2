using System.Collections.Generic;
using NodeCanvas.Framework;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class GetEggTargetAT : ActionTask 
	{
		public BBParameter<GameObject> eggsHolderBBP;
		public BBParameter<GameObject> eggTargetBBP;

		protected override void OnUpdate() 
		{
			//update the eggs list
			List<GameObject> eggs = new List<GameObject>();
			for (int i = 0; i < eggsHolderBBP.value.transform.childCount; i++)
			{
				eggs.Add(eggsHolderBBP.value.transform.GetChild(i).gameObject);
			}

			//get a random egg from the list to target
			eggTargetBBP.value = eggs[Random.Range(0, eggs.Count - 1)];
			eggTargetBBP.value.GetComponent<Egg>().opponentEgg = true;
			EndAction(true);
		}


	}
}