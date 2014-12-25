using UnityEngine;
using System.Collections;

public class GizmoIcon : MonoBehaviour
{

		public string icon;
	
		void OnDrawGizmos ()
		{
				Gizmos.DrawIcon (transform.position, icon + ".tif", true);
				//Gizmos.DrawCube (transform.position, new Vector3 (gizmoSize, gizmoSize));
		}
}

