using PointSniper;
using UnityEngine;

namespace Examples.ExampleScripts{
	public class BaseExample : MonoBehaviour{
		[SerializeField] public RectTransform icon;
		
		
		private Canvas canvas;
		protected IPointSniper myPointSniper;

		private void Awake(){
			canvas=this.GetComponent<Canvas>();
		}

		protected Vector3 Screen2WorldPoint(RectTransform rect_transform){
			var screen_pos = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, rect_transform.position);
			Vector3 result_pos;
			RectTransformUtility.ScreenPointToWorldPointInRectangle(rect_transform, screen_pos, canvas.worldCamera, out result_pos);
			return result_pos;
		}
		
		public void Center(){
			icon.anchoredPosition = myPointSniper==null?Vector3.zero:myPointSniper.CenterSnipe();
		}
		
		public void Random(){
			icon.anchoredPosition = myPointSniper==null?Vector3.zero:myPointSniper.RandomSnipe();
		}

		public void OnLine(){
			icon.anchoredPosition = myPointSniper==null?Vector3.zero:myPointSniper.RandomSnipeOnLine();
		}
	}
}