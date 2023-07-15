using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwap : MonoBehaviour
{
    [SerializeField] GameObject player2D;
    [SerializeField] GameObject player3D;

    [SerializeField] CinemachineVirtualCamera vc;

    private bool playerSwap = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            player2D.SetActive(playerSwap);
            player3D.SetActive(!playerSwap);

            playerSwap = !playerSwap;
        }

        if (!playerSwap)
        {
            vc.Follow = player2D.transform;
            vc.LookAt = player2D.transform;
            vc.Priority = 1;
        }
        else
        {
            vc.Follow = player3D.transform;
            vc.LookAt = player3D.transform;
            vc.Priority = 1;
        }
    }
}
