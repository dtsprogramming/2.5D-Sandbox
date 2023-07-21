using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTrigger : MonoBehaviour
{
    [SerializeField] private Transform tf;
    [SerializeField] private GameObject pushCrate;
    [SerializeField] private GameObject staticCrate;

    private void Start()
    {
        tf = GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            tf.eulerAngles = new Vector3(0, 0, -90f);
            staticCrate.SetActive(false);
            pushCrate.SetActive(true);
        }
    }
}
