using UnityEngine;

public class CameraLook : MonoBehaviour {

    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    //Follow player
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    public Transform camTarget;
    private float lookAhead;
    public bool followPlayer;
    public bool inCombat;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        //Lock camera
        if (inCombat == true)
        {
            followPlayer = false;
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(camTarget.position.x, camTarget.position.y, transform.position.z), ref velocity, speed);
        }

        //Follow player
        if (followPlayer == true)
        {
            inCombat = false;
            transform.position = new Vector3(player.position.x + lookAhead, player.position.y, transform.position.z);
            lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
        }
    }
}