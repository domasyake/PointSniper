using UnityEngine;

namespace PointSniper{
	public interface IPointSniper{
		Vector3 CenterSnipe();
		Vector3 RandomSnipe();
		Vector3 RandomSnipeOnLine();
	}
}