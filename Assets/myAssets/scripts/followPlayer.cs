using UnityEngine;
using System.Collections;

public class followPlayer : Entity
{
		public GameObject target;
		public float xOff;
		public float yOff;
		public bool move = true;

		void Start ()
		{
				thisManage = gameManager.thisM;
				thisLevel.addEntity (this);
				transform.parent = null;
		}

		void FixedUpdate ()
		{
				if (move) {
						Vector2 raw = target.transform.position;
						Vector2 offPos = new Vector2 (raw.x + xOff, raw.y + yOff);
						transform.position = new Vector3 (offPos.x, offPos.y, transform.position.z);
				}
		}
}

