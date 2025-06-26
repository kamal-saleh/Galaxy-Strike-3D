using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private GameObject[] lasers;
    [SerializeField] private RectTransform crosshair;
    [SerializeField] private Transform targetPoint;
    [SerializeField] private float targetDistance = 100f;

    private bool isFiring;

    void Start()
    {
        Cursor.visible = false;
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    private void Update()
    {
        MoveCrosshair();
        ProcessFiring();
        MoveTargetPoint();
    }

    private void ProcessFiring()
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;
        }
    }

    private void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;
    }

    private void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }
}
