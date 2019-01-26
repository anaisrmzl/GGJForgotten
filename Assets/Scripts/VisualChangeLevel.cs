using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualChangeLevel : MonoBehaviour
{

    [SerializeField]
    GameObject MaskObject;
    bool ChangeVisualLevel = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            ChangeVisualLevel = !ChangeVisualLevel;
            MaskObject.SetActive(ChangeVisualLevel);
        }
    }
}
