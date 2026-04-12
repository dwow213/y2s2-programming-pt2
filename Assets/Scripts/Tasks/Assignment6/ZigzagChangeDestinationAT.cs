using System.IO;
using NodeCanvas.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class ZigzagChangeDestinationAT : ActionTask<NavMeshAgent>
	{
		public BBParameter<Vector3> destinationBBP;
		public BBParameter<float> xBoundBBP;
		public BBParameter<float> zBoundBBP;
		public BBParameter<Vector3> velocityLowerRangeBBP;
		public BBParameter<Vector3> velocityUpperRangeBBP;
		public BBParameter<float> xMultiplierBBP;
		public BBParameter<float> zMultiplierBBP;

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() 
		{
			zMultiplierBBP.value *= -1;
			if (agent.transform.position.x >= xBoundBBP.value || agent.transform.position.x <= -xBoundBBP.value)
			{
				xMultiplierBBP.value *= -1;
			}

			Vector3 newPos = Vector3.zero;
			newPos.x = Random.Range(velocityLowerRangeBBP.value.x, velocityUpperRangeBBP.value.x) * xMultiplierBBP.value;
			if (newPos.x > xBoundBBP.value)
				newPos.x = xBoundBBP.value;
			else if (newPos.x < -xBoundBBP.value)
				newPos.x = -xBoundBBP.value;

			newPos.y = agent.transform.position.y;

			newPos.z = Random.Range(velocityLowerRangeBBP.value.z, velocityUpperRangeBBP.value.z) * zMultiplierBBP.value;
			if (newPos.z > zBoundBBP.value)
				newPos.z = zBoundBBP.value;
			else if (newPos.z < -zBoundBBP.value)
				newPos.z = -zBoundBBP.value;

			destinationBBP.value += newPos;

            var path = new NavMeshPath();
            if (!agent.CalculatePath(destinationBBP.value, path))
			{
				destinationBBP.value = newPos;
			}

			EndAction();
        }
	}
}