using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    private GameObject player;
    private Vector3 offset;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        Debug.Log(transform.name + " is spwaned and follows " + player.name + ".");
        offset.z = transform.position.z - player.transform.position.z;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}