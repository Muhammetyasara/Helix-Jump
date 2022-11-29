using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTrigger : MonoBehaviour
{
    Rigidbody rb;

    bool isColEnter;

    public GameObject splashImg;
    public GameObject targetSplashImg;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bound") && !isColEnter)
        {
            targetSplashImg = Instantiate(splashImg, collision.collider.ClosestPoint(transform.position) + (Vector3.up * 0.0001f), Quaternion.Euler(90, 0, 0));
            targetSplashImg.transform.parent = collision.transform;
            rb.AddForce(0, 7, 0, ForceMode.Impulse);
            isColEnter = true;
            StartCoroutine(CollisionDelay());
        }
        else if(collision.gameObject.CompareTag("Finish"))
        {
            StartCoroutine(FinishGameDelay());
        }
    }
    IEnumerator CollisionDelay()
    {
        yield return new WaitForSeconds(0.25f);
        isColEnter = false;
    }
    IEnumerator FinishGameDelay()
    {
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene(0);
    }
}