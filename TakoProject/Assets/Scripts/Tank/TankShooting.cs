using UnityEngine;
using UnityEngine.UI;

public class TankShooting : MonoBehaviour {
    public int m_PlayerNumber = 1;       
    public Rigidbody m_Shell;            
    public Transform m_FireTransform;
    public Transform thirdFireLeftTrm;
    public Transform thirdFireRightTrm;
    public Slider m_AimSlider;           
    public AudioSource m_ShootingAudio;  
    public AudioClip m_ChargingClip;     
    public AudioClip m_FireClip;         
    public float m_MinLaunchForce = 15f; 
    public float m_MaxLaunchForce = 30f; 
    public float m_MaxChargeTime = 0.75f;
    public float currentTime;
    public float lastFireTime;
 
    private string m_FireButton;         
    private float m_CurrentLaunchForce;  
    private float m_ChargeSpeed;         
    private bool m_Fired;
    public bool isFireItem = false;
 

    private void OnEnable() {
        m_CurrentLaunchForce = m_MinLaunchForce;
        m_AimSlider.value = m_MinLaunchForce;
    }


    private void Start() { 
        currentTime = Time.time;

        isFireItem = false;
        m_FireButton = "Fire" + m_PlayerNumber;
    
        m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;
    } 

    private void Update() {
		m_AimSlider.value = m_MinLaunchForce;

		if (m_CurrentLaunchForce >= m_MaxLaunchForce && !m_Fired) {
			m_CurrentLaunchForce = m_MaxLaunchForce;
            if(isFireItem)
            {
                FireThird();
            }else
            {
                Fire();
            }
		
		} else if (Input.GetButtonDown (m_FireButton)) {
			m_Fired = false;
			m_CurrentLaunchForce = m_MinLaunchForce;
			m_ShootingAudio.clip = m_ChargingClip;
			m_ShootingAudio.Play ();
		} else if (Input.GetButton (m_FireButton) && !m_Fired) {
			m_CurrentLaunchForce += m_ChargeSpeed * Time.deltaTime;
			m_AimSlider.value = m_CurrentLaunchForce;
		}
        else if (Input.GetButtonUp(m_FireButton) && !m_Fired && isFireItem)
        {
            FireThird();
            
        }
        else if (Input.GetButtonUp(m_FireButton) && !m_Fired && !isFireItem)
        {
            Fire();
        }
			
		 
    }


    private void Fire() {
		m_Fired = true;

		Rigidbody shellInstance = Instantiate (m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
		shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward;

		m_ShootingAudio.clip = m_FireClip;
		m_ShootingAudio.Play ();

		m_CurrentLaunchForce = m_MinLaunchForce;
    }

    void FireThird()
    {
        m_Fired = true;
        Rigidbody shellInstance = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
        shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward;

        Rigidbody shellInstance_1 = Instantiate(m_Shell, thirdFireLeftTrm.position, thirdFireLeftTrm.rotation) as Rigidbody;
        shellInstance_1.velocity = m_CurrentLaunchForce * thirdFireLeftTrm.forward;
       

        Rigidbody shellInstance_2 = Instantiate(m_Shell, thirdFireRightTrm.position, thirdFireRightTrm.rotation) as Rigidbody;
        shellInstance_2.velocity = m_CurrentLaunchForce * thirdFireRightTrm.forward;

        m_ShootingAudio.clip = m_FireClip;
        m_ShootingAudio.Play();

        m_CurrentLaunchForce = m_MinLaunchForce;

        
    }
}