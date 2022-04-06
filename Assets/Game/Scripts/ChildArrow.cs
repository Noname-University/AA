using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildArrow : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
         Time.timeScale =0;
    }
}
