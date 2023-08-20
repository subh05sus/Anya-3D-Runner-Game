using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] section;
    public float zPos= 126.5f;
    public bool creatingSection = false;
    public int secNum;
    public float xPos = 9.9f;
    public float yPos = 0.593475f;

    void Update()
    {
        if (creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }

    IEnumerator GenerateSection()
    {
        secNum = Random.Range(0,5);
        Instantiate(section[secNum], new Vector3(xPos,yPos,zPos), Quaternion.identity);
        zPos += 100;
        yield return new WaitForSeconds(4);
        creatingSection = false;
    }
}
