using Cinemachine;
using UnityEngine;

public class PlayerSwap : MonoBehaviour
{
    [SerializeField] private GameObject player2D;
    [SerializeField] private GameObject player3D;

    [SerializeField] private CinemachineVirtualCamera vc2d;

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
            vc2d.enabled = true;
        }
        else
        {
            vc2d.enabled = false;
        }
    }
}
