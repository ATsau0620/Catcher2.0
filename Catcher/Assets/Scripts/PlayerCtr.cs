using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtr : MonoBehaviour
{public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 PlayerCtr = transform.position;
       PlayerCtr.x = PlayerCtr.x + moveSpeed;
        transform.position = PlayerCtr;
    }

}
