using NodeCanvas.Framework;
using System.Collections.Generic;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class GuardMoveAT : ActionTask 
	{
		public BBParameter<List<Transform>> pointsBBP;
		public BBParameter<int> targetPointBBP;
		public BBParameter<float> moveSpeedBBP;
		public BBParameter<GameObject> targetPointObjBBP;

		protected override void OnExecute()
		{
            List<Transform> pointsList = pointsBBP.value;
			targetPointObjBBP.value = pointsList[targetPointBBP.value].gameObject;

            agent.transform.position = Vector3.MoveTowards(agent.transform.position, targetPointObjBBP.value.transform.position, moveSpeedBBP.value * Time.deltaTime);
            EndAction();
        }
	}
}