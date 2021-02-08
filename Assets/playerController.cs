using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    [SerializeField] AudioClip laserClip, stepClip, winClip;
    AudioSource audio;

    bool canMove = true;
    bool upWall, downWall, leftWall, rightWall;
    bool upLaser, downLaser, leftLaser, rightLaser;
    bool upLens, downLens, leftLens, rightLens;
    bool upBox, downBox, leftBox, rightBox;
    bool upBox2, downBox2, leftBox2, rightBox2;
    bool upGoal, downGoal, leftGoal, rightGoal;
    float wallCheckDistance;
    [SerializeField] LayerMask wallLayer;
    [SerializeField] LayerMask boxLayer;
    [SerializeField] LayerMask laserLayer;
    [SerializeField] LayerMask lensLayer;
    [SerializeField] LayerMask goalLayer;
    public bool won = false;


    void Start() => audio = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioSource>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

        //Box Check - define wall check depending on if next to box
        upBox = Physics2D.Raycast(transform.position, new Vector2(0, 1), 0.75f, boxLayer);
        upBox2 = upBox ?
            Physics2D.Raycast(transform.position + new Vector3(0, 1.75f, 0), new Vector2(0, 1), .5f, boxLayer) :
            false;
        upWall = upBox ?
            Physics2D.Raycast(transform.position, new Vector2(0, 1), 1.75f, wallLayer):
            Physics2D.Raycast(transform.position, new Vector2(0, 1), 0.75f, wallLayer);
        upLaser = upBox ?
            Physics2D.Raycast(transform.position, new Vector2(0, 1), 1.75f, laserLayer) :
            Physics2D.Raycast(transform.position, new Vector2(0, 1), 0.75f, laserLayer);
        upLens = upBox ?
            Physics2D.Raycast(transform.position, new Vector2(0, 1), 1.75f, lensLayer) :
            Physics2D.Raycast(transform.position, new Vector2(0, 1), 0.75f, lensLayer);
        upGoal = upBox ?
            Physics2D.Raycast(transform.position, new Vector2(0, 1), 1.75f, goalLayer) :
            Physics2D.Raycast(transform.position, new Vector2(0, 1), 0.75f, goalLayer);

        downBox = Physics2D.Raycast(transform.position, new Vector2(0, -1), 0.75f, boxLayer);
        downBox2 = downBox ?
            Physics2D.Raycast(transform.position + new Vector3(0, -1.75f, 0), new Vector2(0, -1), .5f, boxLayer) :
            false;
        downWall = downBox ?
            Physics2D.Raycast(transform.position, new Vector2(0, -1), 1.75f, wallLayer):
            Physics2D.Raycast(transform.position, new Vector2(0, -1), 0.75f, wallLayer);
        downLaser = downBox ?
            Physics2D.Raycast(transform.position, new Vector2(0, -1), 1.75f, laserLayer) :
            Physics2D.Raycast(transform.position, new Vector2(0, -1), 0.75f, laserLayer);
        downLens = downBox ?
            Physics2D.Raycast(transform.position, new Vector2(0, -1), 1.75f, lensLayer) :
            Physics2D.Raycast(transform.position, new Vector2(0, -1), 0.75f, lensLayer);
        downGoal = downBox ?
            Physics2D.Raycast(transform.position, new Vector2(0, -1), 1.75f, goalLayer) :
            Physics2D.Raycast(transform.position, new Vector2(0, -1), 0.75f, goalLayer);

        leftBox = Physics2D.Raycast(transform.position, new Vector2(-1, 0), 0.75f, boxLayer);
        leftBox2 = leftBox ?
            Physics2D.Raycast(transform.position + new Vector3(-1.75f, 0, 0), new Vector2(-1, 0), .5f, boxLayer) :
            false;
        leftWall = leftBox ?
            Physics2D.Raycast(transform.position, new Vector2(-1, 0), 1.75f, wallLayer):
            Physics2D.Raycast(transform.position, new Vector2(-1, 0), 0.75f, wallLayer);
        leftLaser = leftBox ?
            Physics2D.Raycast(transform.position, new Vector2(-1, 0), 1.75f, laserLayer) :
            Physics2D.Raycast(transform.position, new Vector2(-1, 0), 0.75f, laserLayer);
        leftLens = leftBox ?
            Physics2D.Raycast(transform.position, new Vector2(-1, 0), 1.75f, lensLayer) :
            Physics2D.Raycast(transform.position, new Vector2(-1, 0), 0.75f, lensLayer);
        leftGoal = leftBox ?
            Physics2D.Raycast(transform.position, new Vector2(-1, 0), 1.75f, goalLayer) :
            Physics2D.Raycast(transform.position, new Vector2(-1, 0), 0.75f, goalLayer);

        rightBox = Physics2D.Raycast(transform.position, new Vector2(1, 0), 0.75f, boxLayer);
        rightBox2 = rightBox ?
            Physics2D.Raycast(transform.position + new Vector3(1.75f, 0, 0), new Vector2(1, 0), .5f, boxLayer) :
            false;
        rightWall = rightBox ?
            Physics2D.Raycast(transform.position, new Vector2(1, 0), 1.75f, wallLayer):
            Physics2D.Raycast(transform.position, new Vector2(1, 0), 0.75f, wallLayer);
        rightLaser = rightBox ?
            Physics2D.Raycast(transform.position, new Vector2(1, 0), 1.75f, laserLayer) :
            Physics2D.Raycast(transform.position, new Vector2(1, 0), 0.75f, laserLayer);
        rightLens = rightBox ?
            Physics2D.Raycast(transform.position, new Vector2(1, 0), 1.75f, lensLayer) :
            Physics2D.Raycast(transform.position, new Vector2(1, 0), 0.75f, lensLayer);
        rightGoal = rightBox ?
           Physics2D.Raycast(transform.position, new Vector2(1, 0), 1.75f, goalLayer) :
           Physics2D.Raycast(transform.position, new Vector2(1, 0), 0.75f, goalLayer);


        if (Input.GetKeyDown(KeyCode.UpArrow) && !upWall && !upLaser && !upLens && !upGoal && !upBox2 && canMove)
        {
            transform.position += new Vector3(0, 1, 0);
            audio.PlayOneShot(stepClip);
            if (upBox)
            {
                GameObject box = Physics2D.Raycast(transform.position, new Vector2(0, 1), 0.75f, boxLayer).transform.gameObject;
                box.transform.position += new Vector3(0, 1, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && !downWall && !downLaser && !downLens && !downGoal && !downBox2 && canMove)
        {
            transform.position += new Vector3(0, -1, 0);
            audio.PlayOneShot(stepClip);
            if (downBox)
            {
                GameObject box = Physics2D.Raycast(transform.position, new Vector2(0, -1), 0.75f, boxLayer).transform.gameObject;
                box.transform.position += new Vector3(0, -1, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && !leftWall && !leftLaser && !leftLens && !leftGoal && !leftBox2 && canMove)
        {
            transform.position += new Vector3(-1, 0, 0);
            audio.PlayOneShot(stepClip);
            if (leftBox)
            {
                GameObject box = Physics2D.Raycast(transform.position, new Vector2(-1, 0), 0.75f, boxLayer).transform.gameObject;
                box.transform.position += new Vector3(-1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && !rightWall && !rightLaser && !rightLens && !rightGoal && !rightBox2 && canMove)
        {
            transform.position += new Vector3(1, 0, 0);
            audio.PlayOneShot(stepClip);
            if (rightBox)
            {
                GameObject box = Physics2D.Raycast(transform.position, new Vector2(1, 0), 0.75f, boxLayer).transform.gameObject;
                box.transform.position += new Vector3(1, 0, 0);
            }
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            //using laser
            if (upLaser)
            {
                print("laser");
                GameObject laser = Physics2D.Raycast(transform.position, new Vector2(0, 1), 0.75f, laserLayer).transform.gameObject;
                StartCoroutine(useLaser(laser.GetComponent<laserHandler>()));
            }
            else if (downLaser)
            {
                GameObject laser = Physics2D.Raycast(transform.position, new Vector2(0, -1), 0.75f, laserLayer).transform.gameObject;
                StartCoroutine(useLaser(laser.GetComponent<laserHandler>()));
            }
            else if (rightLaser)
            {
                GameObject laser = Physics2D.Raycast(transform.position, new Vector2(1, 0), 0.75f, laserLayer).transform.gameObject;
                StartCoroutine(useLaser(laser.GetComponent<laserHandler>()));
            }
            else if (leftLaser)
            {
                GameObject laser = Physics2D.Raycast(transform.position, new Vector2(-1, 0), 0.75f, laserLayer).transform.gameObject;
                StartCoroutine(useLaser(laser.GetComponent<laserHandler>()));
            }

            //flipping lens
            if (upLens)
            {
                GameObject lens = Physics2D.Raycast(transform.position, new Vector2(0, 1), 0.75f, lensLayer).transform.gameObject;
                lens.GetComponent<lensHandler>().rotateLens();
            }
            else if (downLens)
            {
                GameObject lens = Physics2D.Raycast(transform.position, new Vector2(0, -1), 0.75f, lensLayer).transform.gameObject;
                lens.GetComponent<lensHandler>().rotateLens();
            }
            else if (rightLens)
            {
                GameObject lens = Physics2D.Raycast(transform.position, new Vector2(1, 0), 0.75f, lensLayer).transform.gameObject;
                lens.GetComponent<lensHandler>().rotateLens();
            }
            else if (leftLens)
            {
                GameObject lens = Physics2D.Raycast(transform.position, new Vector2(-1, 0), 0.75f, lensLayer).transform.gameObject;
                lens.GetComponent<lensHandler>().rotateLens();
            }
        }
    }

    IEnumerator useLaser(laserHandler lh)
    {
        canMove = false;
        lh.fire(wallLayer, boxLayer, lensLayer, goalLayer);
        audio.volume = 0.7f;
        audio.clip = laserClip;
        audio.Play();
        audio.volume = 1;

        yield return new WaitForSecondsRealtime(0.25f);


        if (won)
        {
            audio.clip = winClip;
            audio.PlayOneShot(winClip);

            yield return new WaitForSecondsRealtime(1.5f);
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            audio.Stop();
            canMove = true;
            lh.fire(wallLayer, boxLayer, lensLayer, goalLayer);
        }
    }
}
