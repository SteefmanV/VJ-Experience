using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{

    [Header("Targets")]
    [SerializeField] private Transform target1;
    [SerializeField] private Transform target2;
    [SerializeField] private Transform target3;
    [SerializeField] private Transform target4;


    [Header("Positions")]
    [SerializeField] private Transform actualTargetPosition;
    [SerializeField] private float _moveTime = 1;

    private Vector3 previousPosition;
    private Vector3 targetPosition;
    private float _timer = 0;
    private bool positionSelected = false;


    [Header("Position Presets")]
    [SerializeField] private Transform position1;
    [SerializeField] private Transform position2;
    [SerializeField] private Transform position3;
    [SerializeField] private Transform position4;
    [SerializeField] private Transform position5;

    private LightRow[] lightRows;

    private void Start()
    {
        lightRows = FindObjectsOfType<LightRow>();
    }

    void Update()
    {
        loopSelectionInput();
        positionSelectionInput();

        lightPositionUpdate();
    }

    private void setTarget(Transform pTarget)
    {
        foreach(LightRow light in lightRows)
        {
            light.SetTarget(pTarget);
        }
    }

    private void selectPosition(Transform pTargetPosition)
    {
        Debug.Log("Selected position");
        previousPosition = actualTargetPosition.position;
        targetPosition = pTargetPosition.position;
        positionSelected = true;
        setTarget(actualTargetPosition);
        _timer = 0;
    }

    //private void groupSelectionInput()
    //{
    //    if (Input.GetKeyDown(KeyCode.Alpha1)) SelectLightGroup(0);
    //    if (Input.GetKeyDown(KeyCode.Alpha2)) SelectLightGroup(1);
    //    if (Input.GetKeyDown(KeyCode.Alpha3)) SelectLightGroup(2);
    //    if (Input.GetKeyDown(KeyCode.Alpha4)) SelectLightGroup(3);
    //    if (Input.GetKeyDown(KeyCode.Alpha5)) SelectLightGroup(4);
    //    if (Input.GetKeyDown(KeyCode.Alpha6)) SelectLightGroup(5);
    //    if (Input.GetKeyDown(KeyCode.Alpha7)) SelectLightGroup(6);
    //    if (Input.GetKeyDown(KeyCode.Alpha8)) SelectLightGroup(7);
    //    if (Input.GetKeyDown(KeyCode.Alpha9)) SelectLightGroup(8);
    //}

    private void loopSelectionInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            setTarget(target1);
            positionSelected = false;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            setTarget(target2);
            positionSelected = false;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            setTarget(target3);
            positionSelected = false;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            setTarget(target4);
            positionSelected = false;
        }
    }

    private void positionSelectionInput()
    {
        if (Input.GetKeyDown(KeyCode.A)) selectPosition(position1);
        if (Input.GetKeyDown(KeyCode.S)) selectPosition(position2);
        if (Input.GetKeyDown(KeyCode.D)) selectPosition(position3);
        if (Input.GetKeyDown(KeyCode.F)) selectPosition(position4);
        if (Input.GetKeyDown(KeyCode.G)) selectPosition(position5);
    }


    private void lightPositionUpdate()
    {
        if (positionSelected)
        {
            _timer += Time.deltaTime;
            float time = _timer / _moveTime;
            Vector3 delta = targetPosition - previousPosition;
            actualTargetPosition.position = previousPosition + (delta * time);
            if (_timer > _moveTime) positionSelected = false;
        }
    }
}
