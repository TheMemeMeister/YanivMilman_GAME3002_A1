using UnityEngine.Assertions;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
//[RequireComponent(typeof(ProjectileComponent))]
public class ProjectileController : MonoBehaviour
{
    [SerializeField]
    private float m_fInputDeltaVal = 0.1f;

    
    

    private ProjectileComponent m_projectile = null;

    // Start is called before the first frame update
    void Start()
    {
        m_projectile = GetComponent<ProjectileComponent>();
        Assert.IsNotNull(m_projectile, "Houston, we've got a problem! ProjectileComponent is not attached!");
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleUserInput();    
    }

    private void HandleUserInput()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            m_projectile.OnLaunchProjectile();
            LaunchDelay();
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            m_projectile.OnMoveForward(m_fInputDeltaVal);
           
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            m_projectile.OnMoveBackward(m_fInputDeltaVal);

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            m_projectile.OnMoveRight(m_fInputDeltaVal);
            
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_projectile.OnMoveLeft(m_fInputDeltaVal);
        }
        if (Input.GetKey(KeyCode.W))
        {
            m_projectile.OnMoveUP(m_fInputDeltaVal);
        }
        if (Input.GetKey(KeyCode.S))
        {
            m_projectile.OnMoveDown(m_fInputDeltaVal);
        }
    }
    public void ResetProjectile()
    {

        m_projectile.transform.position = new Vector3(0.0f, 0.5f, -10.0f);
        m_projectile.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
    
    IEnumerator LaunchDelay()
    {
        yield return new WaitForSeconds(1.0f);
    }
   
}
