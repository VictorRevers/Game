using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGenerator : MonoBehaviour
{
	public float speed;
	public float minSpeed;
	public float maxSpeed;
	public Transform endPosition;
	public float minDistance= 1f;
	Vector3 begingPosition;

    // Start is called before the first frame update
    void Start()
    {
        begingPosition= transform.position;
		speed = Random.Range(minSpeed, maxSpeed);
	}

    // Update is called once per frame
    void Update()
    {
        //transform.position += new Vector3 (transform.position.x,transform.position.y,transform.position.z)* Time.deltaTime;
		if(Vector3.Distance(transform.position, endPosition.position) <= minDistance){
			transform.position = begingPosition;
			speed = Random.Range(minSpeed, maxSpeed);
		}

		transform.position +=  Vector3.right  * speed * Time.deltaTime;
    }
}
