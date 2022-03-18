using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SettingsModel;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    Transform targetTransform;
    GameManager gameManager;

    [Header("Settings")]
    public CameraSettingsModel cameraSettings;



    void Start()
    {

        targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = new Vector3(targetTransform.position.x, transform.position.y, transform.position.z);

        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Follow();
    }







    void Follow()
    {
        float ClampedY = Mathf.Clamp(transform.position.y, gameManager.minCameraY, gameManager.maxCameraY);
        float ClampedX = Mathf.Clamp(transform.position.x, gameManager.minCameraX, gameManager.maxCameraX);
        transform.position = new Vector3(ClampedX, ClampedY,transform.position.z);
     

        Vector3 smoothPosition = Vector3.Lerp(transform.position, new Vector3(targetTransform.position.x,targetTransform.position.y,transform.position.z), cameraSettings.CameraSpeed * Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}
