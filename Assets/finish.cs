using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class finish : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("checkpoint nice!");
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "graysprite") {
            CompleteLevel();
        }
    }

    private void CompleteLevel() {
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
