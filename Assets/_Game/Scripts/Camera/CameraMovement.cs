using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    private Vector3 offset;
    private Vector3 newtrans;
    [SerializeField] private Transform lookTarget;
    private Transform _transform;
    [SerializeField] private float lookSpeed = 1f;
    public Transform target;

    public float smoothSpeed = 0.1f;

    private void Start()
    {

        // You can also specify your own offset from inspector as it is public variable
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        SmoothFollow();
    }

    public void SmoothFollow()
    {
        Vector3 targetPos = target.position + offset;
        Vector3 smoothFollow = Vector3.Lerp(transform.position, targetPos, smoothSpeed);

        transform.position = smoothFollow;
        transform.LookAt(target);


    }

}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CameraMovement : MonoBehaviour
//{   
//    [SerializeField] private Transform _targetTransform = null;
//    [SerializeField] private Transform lookTarget;

//    [SerializeField] private float damping = 20f;
//    [SerializeField] private float lookSpeed = 1f;


//    private Transform _transform;

//    private Vector3 offset = new Vector3();
//    private Vector3 motionPosition = new Vector3();
//    private Vector3 currentPosition = new Vector3();

//    private void Start()
//    {
//        Initialization();
//    }

//    private void LateUpdate()
//    {
//        Move();


//    }

//    private void Initialization()
//    {
//        _transform = GetComponent<Transform>();

//        offset = _transform.position - _targetTransform.position;
//    }

//    private void Move()
//    {
//        motionPosition = _targetTransform.position + offset;
//        currentPosition = Vector3.Lerp(_transform.position, motionPosition, damping * Time.deltaTime);

//        _transform.position = currentPosition;

//        if (lookTarget)
//        {
//            Quaternion tempRot = Quaternion.LookRotation((lookTarget.position) - _transform.position);
//            _transform.rotation = Quaternion.Slerp(_transform.rotation, tempRot, Time.deltaTime * lookSpeed);
//        }
//    }
//}
