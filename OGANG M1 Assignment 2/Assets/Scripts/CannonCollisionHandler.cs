using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CannonCollisionHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverText;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision detected with: {collision.gameObject.name}");

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Game Over triggered!");

            if (gameOverText != null)
            {
                gameOverText.SetActive(true);
            }

            Time.timeScale = 0f;

            StartCoroutine(ReloadScene());
        }
    }

    private System.Collections.IEnumerator ReloadScene()
    {
        yield return new WaitForSecondsRealtime(2.5f); 
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
