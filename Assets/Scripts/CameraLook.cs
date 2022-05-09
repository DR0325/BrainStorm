using UnityEngine;

public class CameraLook : MonoBehaviour {

	public Transform target;
	public GameObject player;

	public float cameraDistance;
	public float cameraDistanceY;
	public float diff;
	public float speedSmooth;
	public float speed;
	public float diffY;
	public float distanceOfMap;
	public float remainDistance;
	public float remainDistanceY;
	public float remainDistanceYdown;
	public float positionPlayer;

	private float t;
	private float k;


	void Start()
	{
		positionPlayer = player.transform.position.y;
	}

	void FixedUpdate ()
	{
		diff = transform.position.x - target.position.x;

		CameraX ();

		diffY = player.transform.position.y - transform.position.y;

		remainDistanceY = player.transform.position.y - cameraDistanceY - transform.position.y;

		if (diffY > cameraDistanceY) 
		{
			transform.position = new Vector3 (transform.position.x,Mathf.Lerp(transform.position.y,transform.position.y+remainDistanceY,k),transform.position.z);
		}
		if (diffY < cameraDistanceY - 1f && transform.position.y > 0f) 
		{
			remainDistanceYdown = player.transform.position.y - transform.position.y - cameraDistanceY - 1f;

			transform.position = new Vector3 (transform.position.x,Mathf.Lerp(transform.position.y,transform.position.y+remainDistanceYdown,k),transform.position.z);
		}
		if (transform.position.y < 0f)
			transform.position = new Vector3 (transform.position.x,0f,transform.position.z);
			
		CameraX ();

		k = speedSmooth * Time.deltaTime; 

	}

	void Interpolate()
	{

		transform.position = new Vector3 (Mathf.Lerp(transform.position.x,15f,t),transform.position.y,transform.position.z);

		t += 0.025f * Time.deltaTime;
	}
	void CameraX()
	{
		if (target.position.x > 3.8f && target.position.x < distanceOfMap) {
			if (target.localScale.x > 0) {
				Vector3 thePosition = transform.position;

				thePosition.x = target.position.x + cameraDistance;

				if (diff < cameraDistance) {
					remainDistance = cameraDistance - diff;

					transform.position = new Vector3 (Mathf.Lerp (transform.position.x, transform.position.x + remainDistance, t), transform.position.y, transform.position.z);

					t = 2.5f * Time.deltaTime;
				} else {
					transform.position = thePosition;
				}
			} 
			if (target.localScale.x < 0 && target.position.x > 3.8f ) {
				Vector3 thePosition = transform.position;

				thePosition.x = target.position.x - cameraDistance;

				if (diff > -cameraDistance) {
					remainDistance = -cameraDistance - diff;
					transform.position = new Vector3 (Mathf.Lerp (transform.position.x, transform.position.x + remainDistance, t), transform.position.y, transform.position.z);
				} else {
					transform.position = thePosition;
				}
			}
		}
	}
}