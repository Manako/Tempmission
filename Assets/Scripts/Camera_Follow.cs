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
