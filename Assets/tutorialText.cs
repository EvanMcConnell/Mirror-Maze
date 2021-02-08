using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialText : MonoBehaviour
{
    [SerializeField] GameObject text;
    [SerializeField] GameObject target;
    private void Start() {
        if(target == null)
            target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) < 1.2f)
            text.SetActive(true);
        else
            text.SetActive(false);
    }
}
