using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Launcher : MonoBehaviour
{

    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject launcherAmmo;

    [Header("Settings")]
    public float fireRate;

    [Header("Keybinds")]
    public KeyCode launchKey = KeyCode.Mouse0;

    [Header("projectileSettings")]
    public float launchForce;
    public float launchUpwardForce;

    bool readyToFire;

    private LineRenderer lr;
    private int predictionSteps = 30;
    private float timeBetweenSteps = 0.1f;

    private void Start()
    {
        readyToFire = true;

        lr = GetComponent<LineRenderer>();

        if (lr != null)
        {
            lr.positionCount = 0;
        }


    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            ShowTrajectory();
        }
        else
        {
            ClearTrajectory();
        }

        if (readyToFire && Input.GetKeyDown(launchKey))
        {
            readyToFire = false;

            // instantiate projectile
            GameObject projectile = Instantiate(launcherAmmo, attackPoint.position, cam.rotation);

            Destroy(projectile, 5.0f);

            // get rigidbody component
            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

            // calculate direction
            Vector3 forceDirection = cam.transform.forward;

            RaycastHit hit;

            if (Physics.Raycast(cam.position, cam.forward, out hit, 500f))
            {
                forceDirection = (hit.point - attackPoint.position).normalized;
            }

            // add force to projectile
            Vector3 forceToAdd = forceDirection * launchForce + transform.up * launchUpwardForce;

            projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

            Invoke(nameof(ResetFire), fireRate);
        }

    }

    void ResetFire()
    {
        readyToFire = true;
    }

    void ShowTrajectory()
    {
        List<Vector3> points = new List<Vector3>();

        Vector3 startPosition = attackPoint.position;
        Vector3 startVelocity = cam.forward * launchForce + transform.up * launchUpwardForce;
        Vector3 currentPosition = startPosition;
        Vector3 currentVelocity = startVelocity;

        points.Add(currentPosition);

        for (int i = 0; i < predictionSteps; i++)
        {
            currentVelocity += Physics.gravity * timeBetweenSteps;
            Vector3 nextPosition = currentPosition + currentVelocity * timeBetweenSteps;

            if(Physics.Raycast(currentPosition, nextPosition - currentPosition, out RaycastHit hit, (nextPosition - currentPosition).magnitude))
            {
                points.Add(hit.point);
                break;
            }

            points.Add(nextPosition);
            currentPosition = nextPosition;
        }

        if (lr != null)
        {
            lr.positionCount = points.Count;
            lr.SetPositions(points.ToArray());
        }
    }

    void ClearTrajectory()
    {
        if (lr != null)
        {
            lr.positionCount = 0;
        }
    }
}
