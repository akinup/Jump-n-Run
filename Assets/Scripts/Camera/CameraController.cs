using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        Debug.Log(transform.name + " is spwaned and follows " + player.name + ".");
        offset.z = transform.position.z - player.transform.position.z;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}