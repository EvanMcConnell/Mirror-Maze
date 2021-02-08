using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserHandler : MonoBehaviour
{
    enum direction { up, down, left, right }
    [SerializeField]
    direction
        laserDir,
        beamDir;
    [SerializeField]
    Sprite
        laserSprite,
        fullBlock;
    [SerializeField]
    GameObject laserObject;
    bool on = false;

    public void fire(LayerMask wallLayer, LayerMask boxLayer, LayerMask lensLayer, LayerMask goalLayer)
    {
        beamDir = laserDir;
        bool end = false;
        Transform currentLocation = transform;

        if (!on)
        {
            int beamNumber = 1;
            while (!end)
            {
                print("fired" + beamDir);
                switch (beamDir)
                {
                    case direction.right:
                        print("we goin right");
                        if (Physics2D.Raycast(currentLocation.position, currentLocation.right, 0.75f, goalLayer))
                        {
                            GameObject goal = Physics2D.Raycast(currentLocation.position, currentLocation.right, 0.75f, goalLayer).transform.gameObject;

                            if (goal.transform.rotation.eulerAngles == new Vector3(0, 0, 0))
                                GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().won = true;

                            end = true;
                        }
                        else if (Physics2D.Raycast(currentLocation.position, currentLocation.right, 0.75f, wallLayer) || Physics2D.Raycast(currentLocation.position, currentLocation.right, 0.75f, boxLayer))
                        {
                            print("hit wall or box");
                            end = true;
                        }
                        else if (Physics2D.Raycast(currentLocation.position, currentLocation.right, 0.75f, lensLayer))
                        {
                            Transform lensTransform = Physics2D.Raycast(currentLocation.position, currentLocation.right, 0.75f, lensLayer).transform;

                            if (lensTransform.localRotation.eulerAngles == new Vector3(0, 0, 0))
                            {
                                GameObject newBeam = Instantiate(laserObject, currentLocation);
                                newBeam.transform.position = lensTransform.position - transform.up;
                                newBeam.transform.rotation = Quaternion.Euler(180, 0, 90);
                                beamDir = direction.down;
                                currentLocation = newBeam.transform;
                                newBeam.name = beamNumber.ToString();
                                beamNumber++;
                            }
                            else if (lensTransform.localRotation.eulerAngles == new Vector3(0, 180, 180))
                            {
                                GameObject newBeam = Instantiate(laserObject, currentLocation);
                                newBeam.transform.position = lensTransform.position + transform.up;
                                newBeam.transform.rotation = Quaternion.Euler(0, 0, 90);
                                beamDir = direction.up;
                                currentLocation = newBeam.transform;
                                newBeam.name = beamNumber.ToString();
                                beamNumber++;
                            }
                            else
                            {
                                print("hit incompatible lens");
                                end = true;
                            }
                        }
                        else
                        {
                            print("place beam - right");
                            GameObject newBeam = Instantiate(laserObject, currentLocation);
                            newBeam.transform.position += newBeam.transform.right;

                            currentLocation = newBeam.transform;
                            on = true;

                            newBeam.name = beamNumber.ToString();
                            beamNumber++;
                        }
                        break;

                    case direction.left:
                        if (Physics2D.Raycast(currentLocation.position, currentLocation.right, 0.75f, goalLayer))
                        {
                            GameObject goal = Physics2D.Raycast(currentLocation.position, currentLocation.right, 0.75f, goalLayer).transform.gameObject;

                            if (goal.transform.rotation.eulerAngles == new Vector3(0, 180, 0))
                                GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().won = true;

                            end = true;
                        }
                        else if (Physics2D.Raycast(currentLocation.position, currentLocation.right, 0.75f, wallLayer) || Physics2D.Raycast(currentLocation.position, currentLocation.right, 0.75f, boxLayer))
                        {
                            print("hit wall or box");
                            end = true;
                        }
                        else if (Physics2D.Raycast(currentLocation.position, currentLocation.right, 0.75f, lensLayer))
                        {
                            Transform lensTransform = Physics2D.Raycast(currentLocation.position, currentLocation.right, 0.75f, lensLayer).transform;


                            if (lensTransform.localRotation.eulerAngles == new Vector3(0, 180, 0))
                            {
                                GameObject newBeam = Instantiate(laserObject, currentLocation);
                                newBeam.transform.position = lensTransform.position - transform.up;
                                newBeam.transform.rotation = Quaternion.Euler(180, 0, 90);
                                beamDir = direction.down;
                                currentLocation = newBeam.transform;
                                newBeam.name = beamNumber.ToString();
                                beamNumber++;
                            }
                            else if (lensTransform.localRotation.eulerAngles == new Vector3(0, 0, 180))
                            {
                                GameObject newBeam = Instantiate(laserObject, currentLocation);
                                newBeam.transform.position = lensTransform.position + transform.up;
                                newBeam.transform.rotation = Quaternion.Euler(0, 0, 90);
                                beamDir = direction.up;
                                currentLocation = newBeam.transform;
                                newBeam.name = beamNumber.ToString();
                                beamNumber++;
                            }
                            else
                            {
                                print("hit incompatible lens" + " " + lensTransform.name + " " + currentLocation.transform.rotation.eulerAngles);
                                end = true;
                            }
                        }
                        else
                        {
                            print("place beam - right");
                            GameObject newBeam = Instantiate(laserObject, currentLocation);
                            newBeam.transform.position += newBeam.transform.right;

                            currentLocation = newBeam.transform;
                            on = true;

                            newBeam.name = beamNumber.ToString();
                            beamNumber++;
                        }
                        break;

                    case direction.up:
                        if (Physics2D.Raycast(currentLocation.position, currentLocation.right, 0.75f, goalLayer))
                        {
                            GameObject goal = Physics2D.Raycast(currentLocation.position, currentLocation.right, 0.75f, goalLayer).transform.gameObject;

                            if (goal.transform.rotation.eulerAngles == new Vector3(0, 0, 90))
                                GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().won = true;

                            end = true;
                        }
                        else if (Physics2D.Raycast(currentLocation.position, currentLocation.right, 0.75f, wallLayer) || Physics2D.Raycast(currentLocation.position, currentLocation.right, 0.75f, boxLayer))
                        {
                            print("hit wall or box");
                            end = true;
                        }
                        else if (Physics2D.Raycast(currentLocation.position, currentLocation.right, 0.75f, lensLayer))
                        {
                            Transform lensTransform = Physics2D.Raycast(currentLocation.position, currentLocation.right, 0.75f, lensLayer).transform;


                            if (lensTransform.localRotation.eulerAngles == new Vector3(0, 0, 0))
                            {
                                print("we going left lens");
                                GameObject newBeam = Instantiate(laserObject, currentLocation);
                                newBeam.transform.position = lensTransform.position - transform.right;
                                newBeam.transform.rotation = Quaternion.Euler(0, 180, 0);
                                beamDir = direction.left;
                                currentLocation = newBeam.transform;
                                newBeam.name = beamNumber.ToString();
                                beamNumber++;
                            }
                            else if (lensTransform.localRotation.eulerAngles == new Vector3(0, 180, 0))
                            {
                                print("we going right lens");
                                GameObject newBeam = Instantiate(laserObject, currentLocation);
                                newBeam.transform.rotation = Quaternion.Euler(0, 0, 0);
                                newBeam.transform.position = lensTransform.position + newBeam.transform.right;
                                beamDir = direction.right;
                                currentLocation = newBeam.transform;
                                newBeam.name = beamNumber.ToString();
                                beamNumber++;
                            }
                            else
                            {

                                print("hit incompatible lens" + " " + lensTransform.name + " " + currentLocation.transform.rotation);
                                end = true;
                            }
                        }
                        else
                        {
                            print("place beam - up");
                            GameObject newBeam = Instantiate(laserObject, currentLocation);
                            newBeam.transform.position += newBeam.transform.right;

                            currentLocation = newBeam.transform;
                            on = true;

                            newBeam.name = beamNumber.ToString();
                            beamNumber++;
                        }
                        break;

                    case direction.down:
                        if (Physics2D.Raycast(currentLocation.position, currentLocation.right, 0.75f, goalLayer))
                        {
                            GameObject goal = Physics2D.Raycast(currentLocation.position, currentLocation.right, 0.75f, goalLayer).transform.gameObject;

                            if (goal.transform.rotation.eulerAngles == new Vector3(0, 180, 90))
                                GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().won = true;

                            end = true;
                        }
                        else if (Physics2D.Raycast(currentLocation.position, currentLocation.right, 0.75f, wallLayer) || Physics2D.Raycast(currentLocation.position, currentLocation.right, 0.75f, boxLayer))
                        {
                            print("hit wall or box");
                            end = true;
                        }
                        else if (Physics2D.Raycast(currentLocation.position, currentLocation.right, 0.75f, lensLayer))
                        {
                            Transform lensTransform = Physics2D.Raycast(currentLocation.position, currentLocation.right, 0.75f, lensLayer).transform;


                            if (lensTransform.localRotation.eulerAngles == new Vector3(0, 180, 180))
                            {
                                print("we going left lens - down");
                                GameObject newBeam = Instantiate(laserObject, currentLocation);
                                newBeam.transform.position = lensTransform.position - transform.right;
                                newBeam.transform.rotation = Quaternion.Euler(0, 180, 0);
                                beamDir = direction.left;
                                currentLocation = newBeam.transform;
                                newBeam.name = beamNumber.ToString();
                                beamNumber++;
                            }
                            else if (lensTransform.localRotation.eulerAngles == new Vector3(0, 0, 180))
                            {
                                print("we going right lens");
                                GameObject newBeam = Instantiate(laserObject, currentLocation);
                                newBeam.transform.rotation = Quaternion.Euler(0, 0, 0);
                                newBeam.transform.position = lensTransform.position + newBeam.transform.right;
                                beamDir = direction.right;
                                currentLocation = newBeam.transform;
                                newBeam.name = beamNumber.ToString();
                                beamNumber++;
                            }
                            else
                            {

                                print("hit incompatible lens" + lensTransform.name);
                                end = true;
                            }
                        }
                        else
                        {
                            print("place beam - down");
                            GameObject newBeam = Instantiate(laserObject, currentLocation);
                            newBeam.transform.position += newBeam.transform.right;

                            currentLocation = newBeam.transform;
                            on = true;

                            newBeam.name = beamNumber.ToString();
                            beamNumber++;
                        }
                        break;
                }
            }
        }
        else
        {
            Destroy(transform.GetChild(0).gameObject);
            on = false;
        }
    }
}
