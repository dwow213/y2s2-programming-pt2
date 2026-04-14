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

		//Called once per frame while the action is active.
		protected override void OnUpdate() 
		{
			//if the eggTarget becomes null from anything (purposely and unexpectedly deleted), look for a new one
			if (eggTargetBBP.value == null)
			{
				EndAction();
			}

			//move to the egg's left side
			Vector3 destination = eggTargetBBP.value.transform.position - eggTargetBBP.value.transform.right;
			destination.x -= distanceFromTarget;
			agent.SetDestination(destination);
			agent.speed = moveSpeed;

			//when it's at the left side and close to the egg, it will start pushing
			if (agent.remainingDistance <= agent.stoppingDistance)
			{
				eggTargetBBP.value.transform.parent = agent.transform;
				EndAction(true);
			}
		}
	}
}