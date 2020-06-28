using UnityEngine;

public class MovingHead : MonoBehaviour
{
    public float x
    {
        get { return _headAxis.rotation.eulerAngles.x; }
        set { RotateHead(value); }
    }

    public float y
    {
        get { return _armAxis.rotation.eulerAngles.y; }
        set { RotateArm(value); }
    }

    [SerializeField] private Transform _armAxis; // rotate only y
    [SerializeField] private Transform _headAxis; // rotate only z
    public Transform target = null;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("target").transform;
    }


    private void Update()
    {
        // Keep spinning
        // AddHeadRotation(2);
        // AddArmRotation(1f);
        LookAt(target.position);
    }


    public void RotateHead(float pRotation)
    {
        Vector3 euler = new Vector3();
        euler.x = pRotation;
        _headAxis.localRotation = Quaternion.Euler(euler);
    }


    public void RotateArm(float pRotation)
    {
        Vector3 euler = new Vector3();
        euler.y = pRotation;
        _armAxis.localRotation = Quaternion.Euler(euler);
    }


    /// <summary>
    /// TODO: NOT WORKING YET
    /// </summary>
    /// <param name="pValue"></param>
    public void AddHeadRotation(float pValue)
    {
        float currentRotation = _headAxis.localRotation.eulerAngles.x;
        currentRotation += pValue;
        //  _headAxis.localRotation = Quaternion.Euler(euler);
        RotateHead(currentRotation);
    }


    public void AddArmRotation(float pValue)
    {
        Vector3 euler = _armAxis.localRotation.eulerAngles;
        euler.y += pValue;
        _armAxis.localRotation = Quaternion.Euler(euler);
    }


    public void LookAt(Vector3 pTargetPosition)
    {
        // Arm rotation
        _armAxis.LookAt(target, _armAxis.up);
        Vector3 armEuler = _armAxis.localRotation.eulerAngles;
        RotateArm(armEuler.y);

        // Head rotation
        _headAxis.LookAt(target, _headAxis.up);
        Vector3 headEuler = _headAxis.localRotation.eulerAngles;
        RotateHead(headEuler.x);
    }
}
