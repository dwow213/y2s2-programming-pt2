using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class GetIntoPushingStanceAT : ActionTask<NavMeshAgent> 
	{
		public BBParameter<GameObject> eggTargetBBP;
		public float moveSpeed = 8;
		public float distanceFromTarget;

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() 
		{
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() 
		{
			if (eggTargetBBP.value == null)
			{
				EndAction();
			}

			Vector3 destination = eggTargetBBP.value.transform.position - eggTargetBBP.value.transform.right;
			destination.x -= distanceFromTarget;
			agent.SetDestination(destination);
			agent.speed = moveSpeed;

			if (agent.remainingDistance <= agent.stoppingDistance)
			{
				eggTargetBBP.value.transform.parent = agent.transform;
				EndAction(true);
			}
		}
	}
}