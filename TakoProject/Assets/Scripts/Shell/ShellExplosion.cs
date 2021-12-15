using UnityEngine;

public class ShellExplosion : MonoBehaviour {
    public LayerMask m_TankMask;
    public ParticleSystem m_ExplosionParticles;       
    public AudioSource m_ExplosionAudio;              
    public float m_MaxDamage = 100f;                  
    public float m_ExplosionForce = 1000f;            
    public float m_MaxLifeTime = 2f;                  
    public float m_ExplosionRadius = 5f;              


    private void Start() {
        Destroy(gameObject, m_MaxLifeTime);
    }
   

    private void OnTriggerEnter(Collider other) {
		Debug.Log("거리" + Vector3.Distance(gameObject.transform.position, other.gameObject.transform.position));

        if (other.CompareTag("ITEM"))
        {
			if(Vector3.Distance(gameObject.transform.position, other.gameObject.transform.position) < 2.5f)
            {
				return;

			}
            else
            {
				Debug.Log("너냐");
				return;
			}

		
		}

		if (other.CompareTag("MAGNETICFIELD") || other.CompareTag("BULLET")  )
        {
			
			return;

		}
		Collider[] colliders = Physics.OverlapSphere (transform.position, m_ExplosionRadius, m_TankMask);

		for (int i = 0; i < colliders.Length; ++i) {
			Rigidbody targetRigidbody = colliders [i].GetComponent<Rigidbody> ();
			if (!targetRigidbody)
				continue;

			targetRigidbody.AddExplosionForce (m_ExplosionForce, transform.position, m_ExplosionRadius);

			TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth> ();
			if (!targetHealth)
				continue;

			float damage = CalculateDamage (targetRigidbody.position);
			targetHealth.TakeDamage (damage);
		}

		m_ExplosionParticles.transform.parent = null;
		m_ExplosionParticles.Play ();
		//m_ExplosionAudio.Play ();

		Destroy (m_ExplosionParticles.gameObject, m_ExplosionParticles.duration);
		Destroy (gameObject);
    }


    private float CalculateDamage(Vector3 targetPosition) {
		Vector3 explosionToTarget = targetPosition - transform.position;
		float explosionDistance = explosionToTarget.magnitude;
		float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;
		float damage = relativeDistance * m_MaxDamage;
		damage = Mathf.Max (0, damage);
		return damage;
    }
}