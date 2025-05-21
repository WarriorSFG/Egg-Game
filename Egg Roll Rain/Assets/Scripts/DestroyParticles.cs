using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyParticles : MonoBehaviour
{
    public float TimeTillDestruction=5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroy(TimeTillDestruction));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Destroy(float Duration)
    {
        yield return new WaitForSeconds(Duration);
        Destroy(gameObject);

    }
}
