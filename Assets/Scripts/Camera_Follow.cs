//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Camera_Follow : MonoBehaviour {

//    public Transform player;
//    public Vector3 offset;

//    public int x_offset = 8;

//    void Update()
//    {
//        Vector3 cameraPosition = this.transform.position;
//        var x = player.transform.position.x - cameraPosition.x;
//        //var y = player.transform.position.y - cameraPosition.y;
//        Debug.Log(x);
//        if (x > x_offset || x < -x_offset)
//        {
//            //transform.position = new Vector3(player.position.x + offset.x, offset.y, offset.z);
//            //transform.position = Vector3.Lerp(transform.position, player.transform.position, 0.1f)
//        }


//        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);
//    }
//}

using UnityEngine;
using System.Collections;

public class Camera_Follow : MonoBehaviour
{

    float interpVelocity;

    //public GameObject target;
    public Vector3 offset;
    Vector3 targetPos;
    // Use this for initialization
    void Start()
    {
        //targetPos = transform.position;
        targetPos = Camera.main.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (target)
        //{
            //Vector3 posNoZ = transform.position;
        Vector3 posNoZ = Camera.main.transform.position;
            posNoZ.z = transform.position.z;

            Vector3 targetDirection = (transform.position - posNoZ);

            interpVelocity = targetDirection.magnitude * 5f;

            targetPos = Camera.main.transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, targetPos, 0.25f);

        //}
    }
}
