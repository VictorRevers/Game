using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject chickenPlayer;
    Vector3 shouldPos;

    Vector3 offset;

    void Update()
    {
        shouldPos = Vector3.Lerp (gameObject.transform.position, chickenPlayer.transform.position, Time.deltaTime);
        gameObject.transform.position = new Vector3 (shouldPos.x,2,shouldPos.z);
    }
}
