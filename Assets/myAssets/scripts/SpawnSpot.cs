using UnityEngine;
using System.Collections;

public class SpawnSpot : MonoBehaviour
{

		public int teamId = 0;
		public string icon;

		void OnDrawGizmos ()
		{
				Gizmos.DrawIcon (transform.position, icon + ".tif", true);
				//Gizmos.DrawCube (transform.position, new Vector3 (gizmoSize, gizmoSize));
		}
}
