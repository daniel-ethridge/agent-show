using UnityEngine;
using UnityEngine.InputSystem;

public class CameraAdjustment : MonoBehaviour
{
    public InputActionReference mvt;
    public InputActionReference fine;
    public InputActionReference zoom;

    public float coarseMvtSpd;
    public float fineMvtSpd;

    private Camera cam;
    private Vector2 coarse;
    private bool fineSwitch;
    private float zoomValue;

    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
    }

    void OnEnable()
    {
        if (mvt != null)
            mvt.action.Enable();

        if (fine != null)
            fine.action.Enable();

        if (zoom != null)
            zoom.action.Enable();
    }

    void OnDisable()
    {
        if (mvt != null)
            mvt.action.Disable();

        if (fine != null)
            fine.action.Disable();

        if (zoom != null)
            zoom.action.Disable();
    }

    void Update()
    {
        // Get inputs
        coarse = mvt.action.ReadValue<Vector2>();
        fineSwitch = fine.action.IsPressed();
        zoomValue = zoom.action.ReadValue<float>();
        float mvtSpeed = fineSwitch ? fineMvtSpd : coarseMvtSpd;

        if (coarse.sqrMagnitude > 0f)
        {
            transform.position = transform.position + new Vector3(
                coarse.x,
                0f,
                coarse.y
            ) * Time.deltaTime * mvtSpeed;
        }

        if (Mathf.Abs(zoomValue) >= 0f)
        {
            cam.orthographicSize -= zoomValue * Time.deltaTime * mvtSpeed;
        }
    }
}
