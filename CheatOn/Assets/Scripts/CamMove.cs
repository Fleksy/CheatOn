using UnityEngine;

public class CamMove : MonoBehaviour
{
	public Transform target;
	 Vector3 delta;
   void Start()
	{
		delta = transform.position - target.position;
	}
	void Update()
	{
		transform.position = target.position + delta;
	}
}