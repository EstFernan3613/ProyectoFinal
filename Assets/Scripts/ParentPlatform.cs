using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    private void onCollisionEnter(Collision other)
    {
        other.transform.SetParent(transform);
    }

    private void onCollisionExit(Collision other)
    {
        other.transform.SetParent(null);
    }
}
