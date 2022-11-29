using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySlice : MonoBehaviour
{
    public GameObject enemySlice;

    private void OnCollisionEnter(Collision collision)
    {
        if (enemySlice.GetComponent<Renderer>().material.color == Color.red && collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(GameOverDelay());
        }
    }
    IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(0);
    }
}
