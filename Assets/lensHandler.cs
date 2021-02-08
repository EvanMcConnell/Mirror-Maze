using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lensHandler : MonoBehaviour
{
    [SerializeField] AudioClip switchSound;
    AudioSource audio;
    enum corner { a, b, c, d}
    [SerializeField] corner direction;

    void Start()
    {
        setRotation();

        audio = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioSource>();
    }

    public void rotateLens()
    {
        if (direction != corner.d)
            direction++;
        else
            direction = corner.a;
        setRotation();


        audio.PlayOneShot(switchSound);
    }

    void setRotation()
    {
        switch (direction)
        {
            case corner.a:
                transform.transform.eulerAngles = new Vector3(0, 0, 0);
                break;

            case corner.b:
                transform.transform.eulerAngles = new Vector3(0, 180, 0);
                break;

            case corner.c:
                transform.transform.eulerAngles = new Vector3(0, 0, 180);
                break;

            case corner.d:
                transform.transform.eulerAngles = new Vector3(0, 180, 180);
                break;
        }
    }
}
