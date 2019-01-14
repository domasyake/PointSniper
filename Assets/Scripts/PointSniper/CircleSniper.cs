using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PointSniper{
	public class CircleSniper:IPointSniper{

		private readonly Vector2 center;
		private readonly float radius;
		
		public CircleSniper(Vector2 center,float radius){
			this.center = center;
			this.radius = radius;
		}
		
		
		public Vector3 CenterSnipe(){
			return center;
		}

		public Vector3 RandomSnipe(){
			var rad=Random.Range(0,360f)*Mathf.Deg2Rad;
			var range = Random.Range(0, radius);
			return new Vector3(center.x+range*Mathf.Sin(rad),center.y+range*Mathf.Cos(rad));
		}

		public Vector3 RandomSnipeOnLine(){
			var rad=Random.Range(0,360f)*Mathf.Deg2Rad;
			return new Vector3(center.x+radius*Mathf.Sin(rad),center.y+radius*Mathf.Cos(rad));
		}

		public Vector3 RandomSnipeOnCross(float rotation_angle=0){
			var rad = 0f;
			var random = Random.Range(0, 4);
			switch (random){
				case 0:
					rad = 90;
					break;
				case 1:
					rad = 180;
					break;
				case 2:
					rad = 270;
					break;
			}

			rad = (rad+rotation_angle)* Mathf.Deg2Rad;
			var range = Random.Range(0, radius);
			return new Vector3(center.x+range*Mathf.Sin(rad),center.y+range*Mathf.Cos(rad));
		}

		public Vector3[] RandomSnipesToLine(){
			var start_point = RandomSnipeOnLine();
			var end_point=new Vector3(center.x*2-start_point.x,center.y*2-start_point.y);
			return new Vector3[]{start_point,end_point};
		}
	}
}