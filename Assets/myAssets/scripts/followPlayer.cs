using UnityEngine;
using System.Collections;

public class followPlayer : Entity
{
		public GameObject target;

		void Start ()
		{
				thisManage = gameManager.thisM;
				thisLevel.addEntity (this);
				transform.parent = null;
		}

		public void moveCamera (Vector2 Pos)
		{
				Vector3 p = new Vector3 (Pos.x, Pos.y, transform.position.z);
				transform.position = p;
				//Vector3.Lerp (transform.position, p, Time.deltaTime * 0.3f);
		}
}

