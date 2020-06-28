using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRow : MonoBehaviour
{
    public Transform lightTarget;

    private MovingHead[] movingHeads;

    void Start()
    {
        getMovingHeads();
    }

    public void SetTarget(Transform pTarget)
    {
        foreach(MovingHead mh in movingHeads)
        {
            mh.target = pTarget;
        }
    }


    private void getMovingHeads()
    {
        movingHeads = GetComponentsInChildren<MovingHead>();
    }
}
