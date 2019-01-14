using PointSniper;
using UnityEngine;

namespace Examples.ExampleScripts{
	public class RectangleExample : BaseExample{
		
		[SerializeField] private RectTransform leftUnder;
		[SerializeField] private RectTransform rightTop;


		private RectangleSniper rectangleSniper;


		private void Update(){
			var lu = Screen2WorldPoint(leftUnder);
			var rt = Screen2WorldPoint(rightTop);
			
			var left = lu.x;
			var right = rt.x;
			var under = lu.y;
			var top = rt.y;
			Debug.DrawLine(new Vector3(left,under),new Vector3(left,top),Color.blue);
			Debug.DrawLine(new Vector3(left,top),new Vector3(right,top),Color.blue);
			Debug.DrawLine(new Vector3(right,top),new Vector3(right,under),Color.blue);
			Debug.DrawLine(new Vector3(right,under),new Vector3(left,under),Color.blue);
			Debug.DrawLine(new Vector3(left,under),new Vector3(right,top),Color.green);
			Debug.DrawLine(new Vector3(right,under),new Vector3(left,top),Color.green);
			
			
			rectangleSniper=new RectangleSniper(leftUnder.anchoredPosition,rightTop.anchoredPosition);
			myPointSniper = rectangleSniper;
		}

		public void OnDiagonal(){
			icon.anchoredPosition = rectangleSniper.RandomSnipeOnDiagonal();
		}
	}
}