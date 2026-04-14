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

		//reset speed and set up chicken for targetting
		protected override void OnExecute() 
		{
			agent.speed = speed;
			hasTurned = false;
		}

		protected override void OnUpdate() 
		{
            //stops attacking when the chicken has hit their target
			if (!currentlyAttackingBBP.value)
                EndAction(true);

			//first, check if the chicken has turned to their target (signifier)
			if (!hasTurned)
			{
                //chicken looks at their target
				agent.transform.LookAt(pushTargetBBP.value.transform);
				Quaternion rotation = agent.transform.rotation;
				rotation.x = 0;
				rotation.z = 0;
				agent.transform.rotation = rotation;

				//get the dot product to check whether the chicken is looking relatively where the target is
				Vector3 dirToTarget = pushTargetBBP.value.transform.position - agent.transform.position;
                float dotProduct = Vector3.Dot(agent.transform.forward, dirToTarget.normalized);

				Debug.Log($"dir to target: {dirToTarget}");
				if (dotProduct > targetDirection)
					hasTurned = true;
			}
			//move the agent to the target's position to attack
			else
				agent.SetDestination(pushTargetBBP.value.transform.position);
        }
	}
}