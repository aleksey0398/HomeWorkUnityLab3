using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Transform transform;
    private Animator animator;

    private bool platfromIsFalling = false;

    private const string ANIMATION_NAME_SHAKE = "Shake";

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
        animator = GetComponent<Animator>();

        animator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void PlatformMoving()
    {
        rigidbody.isKinematic = true;

        float x = UnityEngine.Random.Range(-3f, 4f);
        float z = UnityEngine.Random.Range(-5f, 3f);
        float y = UnityEngine.Random.Range(2f, 4f);

        Vector3 newVector = new Vector3(x, y, z);

        transform.position = newVector;
        transform.rotation = new Quaternion(0f, 0f, 0f, 0f);

        platfromIsFalling = false;
    }

    private void StartAnimationBeforeFalling()
    {
        platfromIsFalling = true;

        animator.enabled = true;
        StartCoroutine(ExecuteAfterTime(1.5f, PlatformFalling));
    }

    private void PlatformFalling()
    {
        animator.enabled = false;
        rigidbody.isKinematic = false;
        StartCoroutine(ExecuteAfterTime(1.3f, PlatformMoving));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!platfromIsFalling)
            StartAnimationBeforeFalling();
    }

    IEnumerator ExecuteAfterTime(float time, Action task)
    {
        yield return new WaitForSeconds(time);
        task();
    }
}
