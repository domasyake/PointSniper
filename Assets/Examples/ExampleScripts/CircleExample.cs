using System;
using PointSniper;
using UnityEngine;

namespace Examples.ExampleScripts{
	public class CircleExample : BaseExample{
		[SerializeField] private RectTransform center;
		[SerializeField] private RectTransform radiusPoint;
		[SerializeField] private RectTransform circle;
		[SerializeField] private RectTransform lineStart;
		[SerializeField] private RectTransform lineEnd;
		

		private CircleSniper circleSniper;
		
		
		private void Update(){
			var center_pos = Screen2WorldPoint(center);
			var radius_point_pos = Screen2WorldPoint(radiusPoint);
			
			var world_radius = (float)Math.Sqrt(Math.Pow(radius_point_pos.x - center_pos.x, 2) +
			                       Math.Pow(radius_point_pos.y - center_pos.y, 2));

			Debug.DrawLine(center_pos,radius_point_pos,Color.blue);
			Debug.DrawLine(center_pos,center_pos+new Vector3(world_radius,0),Color.green);
			Debug.DrawLine(center_pos,center_pos+new Vector3(-world_radius,0),Color.green);
			Debug.DrawLine(center_pos,center_pos+new Vector3(0,world_radius,0),Color.green);
			Debug.DrawLine(center_pos,center_pos+new Vector3(0,-world_radius,0),Color.green);

			var start_pos = Screen2WorldPoint(lineStart);
			var end_pos=Screen2WorldPoint(lineEnd);
			Debug.DrawLine(start_pos,end_pos,Color.cyan);
			
			var anchored_center=center.anchoredPosition;
			var anchored_radius=radiusPoint.anchoredPosition;
			var radius = (float)Math.Sqrt(Math.Pow(anchored_radius.x - anchored_center.x, 2) +
			                       Math.Pow(anchored_radius.y - anchored_center.y, 2));

			circle.sizeDelta = new Vector2(radius*2.22f, radius*2.22f);
;			circleSniper=new CircleSniper(center.anchoredPosition,radius);
			myPointSniper = circleSniper;
		}

		public void OnCross(){
			icon.anchoredPosition = circleSniper.RandomSnipeOnCross();
		}

		public void GetLinePoint(){
			var points = circleSniper.RandomSnipesToLine();
			lineStart.anchoredPosition = points[0];
			lineEnd.anchoredPosition = points[1];
		}
	}
}