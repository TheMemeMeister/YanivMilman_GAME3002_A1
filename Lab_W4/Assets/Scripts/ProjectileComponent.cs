using UnityEngine.Assertions;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
//[RequireComponent(typeof(Rigidbody))]
public class ProjectileComponent : MonoBehaviour
{
    [SerializeField]
    private Vector3 m_vInitialVelocity = Vector3.zero;

    private Rigidbody m_rb = null;
    public LineRenderer line;
    public int lineSegment = 10;
    private GameObject m_landingDisplay = null;

    private bool m_bIsGrounded = true;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        Assert.IsNotNull(m_rb, "Houston, we've got a problem! Rigidbody is not attached!");

        CreateLandingDisplay();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Shoot"))
        {
            GetComponent<Rigidbody>().velocity = m_vInitialVelocity;
            GetComponent<Rigidbody>().position = m_rb.transform.position;
            // Get mouse position (in screen-space) and convert to world-space

        }
        UpdateLandingPosition();
       
    }

    private void CreateLandingDisplay()
    {
        m_landingDisplay = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        m_landingDisplay.transform.position = Vector3.zero;
        m_landingDisplay.transform.localScale = new Vector3(1f, 0.1f, 1f);

        m_landingDisplay.GetComponent<Renderer>().material.color = Color.blue;
        m_landingDisplay.GetComponent<Collider>().enabled = false;
        
    }

    private void UpdateLandingPosition()
    {
        if (m_landingDisplay != null)
        {
            m_landingDisplay.transform.position = GetLandingPosition();
            Visualize(m_vInitialVelocity);
        }
    }

    private Vector3 GetLandingPosition()
    {
        float fTime = 2f * (0f - m_vInitialVelocity.y / Physics.gravity.y);

        Vector3 vFlatVel = m_vInitialVelocity;
        vFlatVel.y = 0f;
        vFlatVel *= fTime;

        return transform.position + vFlatVel;

    }
    Vector3 CalcPosInTime(Vector3 m_vInitialVelocity, float fTime)
    {
        Vector3 VXZ = m_vInitialVelocity;
       

        Vector3 result = m_rb.position + m_vInitialVelocity * fTime;
        float FinalPosition = (-0.5f * Mathf.Abs(Physics.gravity.y) * (fTime * fTime)) + (VXZ.y * fTime);
        result.y = FinalPosition;

        return result;
    }
    void Visualize(Vector3 m_vInitialVelocity)
    {
        for (int i = 0; i < lineSegment; i++)
        {
            Vector3 pos = CalcPosInTime(m_vInitialVelocity, i / (float)lineSegment);
            line.SetPosition(i, pos);
        }
    }

    #region CALLBACKS
    public void OnLaunchProjectile()
    {
        if (!m_bIsGrounded)
        {
            return;
        }
        Recalculating();
        m_landingDisplay.transform.position = GetLandingPosition();
        m_bIsGrounded = false;

        transform.LookAt(m_landingDisplay.transform.position, Vector3.up);

        m_rb.velocity = m_vInitialVelocity;
    }

    public void OnMoveForward(float fDelta)
    {
        m_vInitialVelocity.z += fDelta;
    }

    public void OnMoveBackward(float fDelta)
    {
        m_vInitialVelocity.z -= fDelta;
    }

    public void OnMoveRight(float fDelta)
    {
        m_vInitialVelocity.x += fDelta;
    }

    public void OnMoveLeft(float fDelta)
    {
        m_vInitialVelocity.x -= fDelta;
    }
    public void OnMoveUP(float fDelta)
    {
        m_vInitialVelocity.y += fDelta;
    }
    public void OnMoveDown(float fDelta)
    {
        m_vInitialVelocity.y -= fDelta;
    }

    IEnumerator Recalculating()
    {
        yield return new WaitForSeconds(1.5f);
    }
    #endregion
}
