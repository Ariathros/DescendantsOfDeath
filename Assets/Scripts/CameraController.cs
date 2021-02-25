using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float offset;
    private Vector3 playerPosition;
    public float offsetSmoothing;

    // Update is called once per frame
    void Update()
    {
        CameraChase();
    }

    void CameraChase()
    {
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z - 1);
        if (player.transform.localScale.x > 0f)
        {
            playerPosition = new Vector3(player.transform.position.x + offset, player.transform.position.y + 2, player.transform.position.z - 1);
        }
        else
        {
            playerPosition = new Vector3(player.transform.position.x - offset, player.transform.position.y + 2, player.transform.position.z - 1);
        }
        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
    }


}
