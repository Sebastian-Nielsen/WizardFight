using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    private PlatformEffector2D effector;
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.DownArrow))
        {
            effector.rotationalOffset = 180f;
            Invoke("resetEffectorRotOffset", 0.1f);
        }
    }

    private void resetEffectorRotOffset() => effector.rotationalOffset = 0;
}
