using NodeCanvas.Framework;
using System.Collections.Generic;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions 
{

	public class ChangePointAT : ActionTask 
	{
		public BBParameter<List<Transform>> pointsBBP;
		public BBParameter<int> targetPointBBP;
		public BBParameter<GameObject> targetPointObjBBP;

		//Called once per frame while the action is active.
		protected override void OnExecute() 
		{
			targetPointBBP.value++;
			if (targetPointBBP.value >= pointsBBP.value.Count)
			{
				targetPointBBP.value = 0;
			}

			targetPointObjBBP.value = pointsBBP.value[targetPointBBP.value].gameObject;

			EndAction();
		}
	}
}