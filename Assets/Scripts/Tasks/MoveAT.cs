using NodeCanvas.Framework;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class MoveAT : ActionTask 
	{
		public BBParameter<Vector3> moveDirectionBBP;
		public BBParameter<float> moveSpeedBBP;
		public BBParameter<float> turnSpeedBBP;

		//Called once per frame while the action is active.
		protected override void OnUpdate() 
		{
			Vector3 planar = new(moveDirectionBBP.value.x, 0, moveDirectionBBP.value.z);

			Quaternion desiredRotation = Quaternion.LookRotation(planar);
			Quaternion currentRotation = agent.transform.rotation;

			agent.transform.rotation = Quaternion.RotateTowards(currentRotation, desiredRotation, turnSpeedBBP.value * Time.deltaTime);
			agent.transform.position += moveSpeedBBP.value * Time.deltaTime * agent.transform.forward;

			//moveDirectionBBP.value = Vector3.zero;
		}
	}
}