using NodeCanvas.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class CheckDistanceCT : ConditionTask 
	{
        public BBParameter<GameObject> targetPointBBP;
        public BBParameter<float> stopDistanceBBP;

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() 
		{
			Vector3 pointPos = targetPointBBP.value.transform.position;

			Vector3 directionVector = pointPos - agent.transform.position;
			if (directionVector.magnitude < stopDistanceBBP.value)
			{
				return true;
			}
			return false;
		}
	}
}