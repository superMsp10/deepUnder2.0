using  UnityEngine;
using System.Collections.Generic;
using UnityEngine.Serialization;



public class Mob1 : Entity {
	public List<BodyParts>parts;
	public float HP;
	public int Dmg;
	public int blunt, point, slash;

	public void takeDmg(int damage, string type){
		if(type=="blunt"){
			HP -=(damage-blunt);

		}else if(type=="point"){
			HP-=(damage-point)/2;
			
		}else if(type=="slash"){
			int preDmg =0;
			preDmg=(Random.Range(0,damage)/(slash*Random.Range(-2,slash)));
			HP-=(preDmg+Random.Range(-slash,slash));
			
		}


	}

}
