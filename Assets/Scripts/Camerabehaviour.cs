using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.EventSystems;

public class Camerabehaviour : MonoBehaviour
{

 public enum CameraStates
    {
        entry,
        praktika
    }



    public CameraStates cameraState = CameraStates.entry;

    public GameObject virtualCamStartGameObject;
    private CinemachineVirtualCamera virtualCamStart;
    private CinemachineTrackedDolly virtualCamStartTrackedDolly;

    public GameObject virtualCamPraktikaGameObject;
    private CinemachineVirtualCamera virtualCamPraktika;
    private CinemachineTrackedDolly virtualCamPraktikaTrackedDolly;


    public List<GameObject> cameraList = new List<GameObject>();
    public GameObject praktikaButton;




    // Start is called before the first frame update
    void Start()
    {

        this.cameraList.Add(this.virtualCamStartGameObject);
        this.cameraList.Add(this.virtualCamPraktikaGameObject);
        this.virtualCamStart = this.virtualCamStartGameObject.GetComponent<CinemachineVirtualCamera>();
        this.virtualCamStartTrackedDolly = this.virtualCamStart.GetCinemachineComponent<CinemachineTrackedDolly>();
        this.virtualCamPraktika = this.virtualCamPraktikaGameObject.GetComponent<CinemachineVirtualCamera>();
        this.virtualCamPraktikaTrackedDolly = this.virtualCamPraktika.GetCinemachineComponent<CinemachineTrackedDolly>();

    }

    // Update is called once per frame
    void Update()
    {
           switch (this.cameraState)
        {
            case CameraStates.entry:
                activateCam(this.virtualCamStartGameObject);
                cameraRideIntro();
                break;

            case CameraStates.praktika:
                activateCam(this.virtualCamPraktikaGameObject);
                cameraRidePraktika();
                break;

            default:
                break;
        }



     

    }


    public void buttonPraktikaClicked()
    {
        this.cameraState = CameraStates.praktika;
    }


    private void activateCam(GameObject cam)
    {
        foreach (GameObject camera in this.cameraList)
        {
            if (camera != cam)
            {
                camera.SetActive(false);
            }else
            {
                camera.SetActive(true);
            }
        }
    }

    private void cameraRidePraktika()
    {
        if (this.virtualCamPraktikaTrackedDolly.m_PathPosition < (this.virtualCamPraktikaTrackedDolly.m_Path.MaxPos))
        {
            this.virtualCamPraktikaTrackedDolly.m_PathPosition += (Time.deltaTime / 3);
        }
        else
        {

        }
    }


    private void cameraRideIntro()
    {
        if (this.virtualCamStartTrackedDolly.m_PathPosition < (this.virtualCamStartTrackedDolly.m_Path.MaxPos))
        { 
            this.virtualCamStartTrackedDolly.m_PathPosition += (Time.deltaTime / 2);
        }
        else
        {
                  
        }
    }

}
