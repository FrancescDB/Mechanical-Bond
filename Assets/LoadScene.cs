using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Skip());
    }

    private IEnumerator Skip()
    {
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene("MainScene");
    }
}
