using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target; //sets the target to follow
	public Vector3 offset;  //offset

	private void FixedUpdate()
	{
		transform.position = target.position + offset; //keeps the camera at the same position as the player with an offset
	}
}
