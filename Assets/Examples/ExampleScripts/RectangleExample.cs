using PointSniper;
using UnityEngine;

namespace Examples.ExampleScripts{
	public class RectangleExample : MonoBehaviour{
		[SerializeField] private RectTransform icon;
		[SerializeField] private RectTransform leftUnder;
		[SerializeField] private RectTransform rightTop;


		private RectangleSniper rectangleSniper;
		private Canvas canvas;

		private void Awake(){
			canvas = this.GetComponent<Canvas>();
		}

		private void Update(){
			var lu_screen_pos = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, leftUnder.position);
			var lu = Vector3.zero;
			RectTransformUtility.ScreenPointToWorldPointInRectangle(leftUnder, lu_screen_pos, canvas.worldCamera, out lu);
			var rt_screen_pos = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera,rightTop.position);
			var rt = Vector3.zero;
			RectTransformUtility.ScreenPointToWorldPointInRectangle(rightTop, rt_screen_pos, canvas.worldCamera, out rt);
			
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
		}

		public void Center(){
			icon.anchoredPosition = rectangleSniper.CenterSnipe();
		}
		
		public void Random(){
			icon.anchoredPosition = rectangleSniper.RandomSnipe();
		}

		public void OnLine(){
			icon.anchoredPosition = rectangleSniper.RandomSnipeOnLine();
		}

		public void OnDiagonal(){
			icon.anchoredPosition = rectangleSniper.RandomSnipeOnDiagonal();
		}
	}
}