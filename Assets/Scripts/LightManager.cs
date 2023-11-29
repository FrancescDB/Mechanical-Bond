using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(timeRotation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator timeRotation()
    {
        for (int i = 0; i < 120*10; i++)
        {
          //  Debug.Log("GOLA");
            transform.Rotate(new Vector3(transform.rotation.x + 0.15f, transform.rotation.y, transform.rotation.z));
            yield return new WaitForSeconds(0.1f);
        }
    }
}
