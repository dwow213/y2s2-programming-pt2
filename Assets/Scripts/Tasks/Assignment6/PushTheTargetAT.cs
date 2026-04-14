using NodeCanvas.Framework;
using ParadoxNotion.Design;
using TMPro;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class PushTheTargetAT : ActionTask<NavMeshAgent>
    {

		public BBParameter<bool> currentlyAttackingBBP;
		public BBParameter<GameObject> pushTargetBBP;
		public float targetDirection;
		public bool hasTurned;
		public float speed;

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() 
		{
			agent.speed = speed;
			hasTurned = false;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() 
		{
            if (!currentlyAttackingBBP.value)
                EndAction(true);

			if (!hasTurned)
			{
                agent.transform.LookAt(pushTargetBBP.value.transform);
				Quaternion rotation = agent.transform.rotation;
				rotation.x = 0;
				rotation.z = 0;
				agent.transform.rotation = rotation;

				Vector3 dirToTarget = pushTargetBBP.value.transform.position - agent.transform.position;
                float dotProduct = Vector3.Dot(agent.transform.forward, dirToTarget.normalized);

				Debug.Log($"dir to target: {dirToTarget}");
				if (dotProduct > targetDirection)
					hasTurned = true;
			}
			else
				agent.SetDestination(pushTargetBBP.value.transform.position);
        }
	}
}