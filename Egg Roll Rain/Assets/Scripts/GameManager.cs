using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public float Duration=1f;
    public bool Switch;
    public GameObject ParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ParticleCreator(Duration));
        Switch = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Switch == false)
        {
            StartCoroutine(ParticleCreator(Duration));
            Switch = true;
        }

    }   

    IEnumerator ParticleCreator(float Duration)
    {
        yield return new WaitForSeconds(Duration);
        Switch = false;
        Vector3 Pos = new Vector3(gameObject.transform.position.x + Random.Range(-100,100),gameObject.transform.position.y, gameObject.transform.position.z + Random.Range(-100, 100));
        Instantiate(ParticleSystem, Pos,ParticleSystem.transform.rotation);
        
    }
}
