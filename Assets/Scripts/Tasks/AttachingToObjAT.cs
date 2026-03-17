using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;

namespace NodeCanvas.Tasks.Actions {

	public class AttachingToObjAT : ActionTask 
	{
		public BBParameter<GameObject> movingObjHolderBBP;
		public BBParameter<List<GameObject>> movingObjListBBP;
		public BBParameter<GameObject> targetObjBBP;
		public BBParameter<bool> attachingProcessBBP;

		protected override void OnExecute() 
		{
			List<GameObject> tempList = new List<GameObject>();
			GameObject movingObjHolder = movingObjHolderBBP.value;

            //update the list just in case moving objects change during runtime
            //honestly this list might be a bit pointless if i end up not using it for something else
            for (int i = 0; i < movingObjHolder.transform.childCount; i++)
			{
				tempList.Add(movingObjHolder.transform.GetChild(i).gameObject);
			}

			movingObjListBBP.value = tempList;

			//initial value of the target obj for comparison later
			GameObject originalTargetObj = movingObjListBBP.value[0];
			if (targetObjBBP.value != null)
			{
                //originalTargetObj = targetObjBBP.value;
                agent.transform.position = targetObjBBP.value.transform.position;
            }
				

			
			
			//check each moving obj to decide which one to attach to
			foreach (GameObject movingObj in movingObjListBBP.value)
			{
				//if the moving obj would move the agent away from its destination (the right side),
				//ignore it
				if (movingObj.transform.position.x <= agent.transform.position.x)
					continue;

				//if the moving obj is the object character is currently on, ignore it
				if (movingObj == targetObjBBP.value)
					continue;

				//get the directions 
                Vector3 originalVector = originalTargetObj.transform.position - agent.transform.position;
                Vector3 directionVector = movingObj.transform.position - agent.transform.position;
				
				//check if the current moving object is closer to the agent than the original one
				if (directionVector.magnitude < originalVector.magnitude)
				{
                    originalTargetObj = movingObj;
				}
			}

            Debug.Log($"Attaching to {originalTargetObj}. Time: {Time.frameCount}");

            //update target obj for attaching, start attaching process and end action
            targetObjBBP.value = originalTargetObj;
            attachingProcessBBP.value = true;
            EndAction();
        }
	}
}