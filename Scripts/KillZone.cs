using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D colission)
    {
        if (colission.tag == "Player")
        {
            PlayerController controller = colission.GetComponent<PlayerController>();
            controller.Die();
        }
    }
}
