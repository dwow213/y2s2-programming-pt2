using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class SeekAT : ActionTask 
	{
		public BBParameter<Transform> seekTargetBBP;
		public BBParameter<Vector3> moveDirectionBBP;
		[MinValue(0f)] public float weight;

		//Called once per frame while the action is active.
		protected override void OnUpdate() 
		{
			moveDirectionBBP.value += (seekTargetBBP.value.position - agent.transform.position).normalized * weight;
		}
	}
}