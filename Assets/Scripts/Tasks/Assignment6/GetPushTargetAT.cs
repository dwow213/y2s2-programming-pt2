using System.Collections.Generic;
using JetBrains.Annotations;
using NodeCanvas.Framework;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class GetPushTargetAT : ActionTask {

		public BBParameter<List<GameObject>> pushTargetListBBP;
		public BBParameter<GameObject> pushTargetBBP;
		public BBParameter<bool> currentlyAttackingBBP;

		//randomly pick a push target, which is either the player or opponent
		protected override void OnExecute() 
		{
			int randNum = Random.Range(0, pushTargetListBBP.value.Count);
			pushTargetBBP.value = pushTargetListBBP.value[randNum];
			currentlyAttackingBBP.value = true;
			
			EndAction(true);
		}
	}
}