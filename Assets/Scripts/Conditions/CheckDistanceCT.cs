using NodeCanvas.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class CheckDistanceCT : ConditionTask 
	{
        public BBParameter<GameObject> targetPointBBP;
        public BBParameter<float> stopDistanceBBP;

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