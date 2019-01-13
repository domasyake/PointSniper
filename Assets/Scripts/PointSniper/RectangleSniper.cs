using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PointSniper{
	public class RectangleSniper:IPointSniper{

		private readonly Vector2 leftUnder;
		private readonly Vector2 rightTop;

		private readonly Vector2 center;
		
		public RectangleSniper(Vector2 start_point,Vector2 end_point){
			leftUnder=new Vector2(Math.Min(start_point.x,end_point.y),Math.Min(start_point.y,end_point.y));
			rightTop=new Vector2(Math.Max(start_point.x,end_point.x),Math.Max(start_point.y,end_point.y));
			
			center=new Vector2((Math.Abs(rightTop.x)-Math.Abs(leftUnder.x))/2,(Math.Abs(rightTop.y)-Math.Abs(leftUnder.y))/2);
		}
		
		public Vector3 CenterSnipe(){
			return center;
		}

		public Vector3 RandomSnipe(){
			return new Vector2(Random.Range(leftUnder.x,rightTop.x),Random.Range(leftUnder.y,rightTop.y));
		}

		public Vector3 RandomSnipeOnLine(){
			var line = Random.Range(0, 4);
			if (line == 0){
				return new Vector2(leftUnder.x,Random.Range(leftUnder.y,rightTop.y));
			}else if (line == 1){
				return new Vector2(rightTop.x,Random.Range(leftUnder.y,rightTop.y));
			}else if (line == 2){
				return new Vector2(Random.Range(leftUnder.x,rightTop.x),leftUnder.y);
			}else{
				return new Vector2(Random.Range(leftUnder.x,rightTop.x),rightTop.y);
			}
		}

		public Vector3 RandomSnipeOnDiagonal(){
			var x = Random.Range(leftUnder.x, rightTop.x);
			var rt = rightTop;
			var lu = leftUnder;
			if (Random.Range(0, 2) == 1){
				var temp = rt.x;
				rt.x = lu.x;
				lu.x = temp;
			}
			var y = (rt.y - lu.y) / (rt.x - lu.x) * (x - lu.x) + lu.y;
			return new Vector3(x,y);
		}
	}
}
