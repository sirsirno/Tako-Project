using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public int m_NumRoundsToWin = 2;        
    public float m_StartDelay = 3f;         
    public float m_EndDelay = 3f;           
    public CameraControl m_CameraControl;   
    public Text m_MessageText;              
    public GameObject m_TankPrefab;
    public GameObject m_TankPrefab_sqr;
    public TankManager[] m_Tanks;
    public static GameManager instance;
    public bool isPlaying = false;
    public bool isInvinsible = false;

    private int m_RoundNumber;              
    private WaitForSeconds m_StartWait;     
    private WaitForSeconds m_EndWait;       
    private TankManager m_RoundWinner;
    private TankManager m_GameWinner;
    public Text gameTimer;

    private void Awake()
    {

        if (instance != null)
        {
            Debug.LogError("아 하지말라고");
        }
        else
        {
            instance = this;
        }
    }

    public void GameStart() {
        m_StartWait = new WaitForSeconds(m_StartDelay);
        m_EndWait = new WaitForSeconds(m_EndDelay);

        SpawnAllTanks();
        SetCameraTargets();

        StartCoroutine(GameLoop());
    }

    private void SpawnAllTanks() {
        for (int i = 0; i < m_Tanks.Length; i++) {
            if(i > 0)
            {
                m_Tanks[i].m_Instance =
              Instantiate(m_TankPrefab_sqr, m_Tanks[i].m_SpawnPoint.position, m_Tanks[i].m_SpawnPoint.rotation) as GameObject;
                m_Tanks[i].m_PlayerNumber = i + 1;
                m_Tanks[i].Setup();
            }else
            {
                m_Tanks[i].m_Instance =
              Instantiate(m_TankPrefab, m_Tanks[i].m_SpawnPoint.position, m_Tanks[i].m_SpawnPoint.rotation) as GameObject;
                m_Tanks[i].m_PlayerNumber = i + 1;
                m_Tanks[i].Setup();
            }         
        }
    }


    private void SetCameraTargets() {
        Transform[] targets = new Transform[m_Tanks.Length];

        for (int i = 0; i < targets.Length; i++) {
            targets[i] = m_Tanks[i].m_Instance.transform;
        }

        m_CameraControl.m_Targets = targets;
    }


    private IEnumerator GameLoop() {
        yield return StartCoroutine(RoundStarting());
        yield return StartCoroutine(RoundPlaying());
        yield return StartCoroutine(RoundEnding());

        if (m_GameWinner != null) {
            SceneManager.LoadScene(0);
        }
        else {
            StartCoroutine(GameLoop());
        }
	}


    private IEnumerator RoundStarting() {
		ResetAllTanks ();
		DisableTankControl ();

        isInvinsible = true;

        m_CameraControl.SetStartPositionAndSize ();
		++m_RoundNumber;
		m_MessageText.text = "ROUND " + m_RoundNumber;
        isPlaying = false;

        yield return m_StartWait;     
    }


    private IEnumerator RoundPlaying() {

        StartCoroutine(InGameTimer.instance.Timer());
        StartCoroutine(SetInvinsible());
        EnableTankControl ();
        

		m_MessageText.text = string.Empty;
        isPlaying = true;


        while ( !OneTankLeft() ) {
			yield return null;	
		}
    }


    public IEnumerator RoundEnding() {
        InGameTimer.instance.timer.text = InGameTimer.instance.InitTimer();
		DisableTankControl ();

		m_RoundWinner = GetRoundWinner ();
		if (m_RoundWinner != null) 
			m_RoundWinner.m_Wins++;

		m_GameWinner = GetGameWinner ();
		string message = EndMessage ();
		m_MessageText.text = message;
        isPlaying = false;

        yield return m_EndWait;
    }


    private bool OneTankLeft() {
        int numTanksLeft = 0;

        for (int i = 0; i < m_Tanks.Length; i++) {
            if (m_Tanks[i].m_Instance.activeSelf)
                numTanksLeft++;
        }

        return numTanksLeft <= 1;
    }

    private TankManager GetRoundWinner() {
        for (int i = 0; i < m_Tanks.Length; i++) {
            if (m_Tanks[i].m_Instance.activeSelf)
                return m_Tanks[i];
        }

        return null;
    }


    private TankManager GetGameWinner() {
        for (int i = 0; i < m_Tanks.Length; i++) {
            if (m_Tanks[i].m_Wins == m_NumRoundsToWin)
                return m_Tanks[i];
        }

        return null;
    }


    private string EndMessage() {
        string message = "DRAW!";

        if (m_RoundWinner != null)
            message = m_RoundWinner.m_ColoredPlayerText + " WINS THE ROUND!";

        message += "\n\n\n\n";

        for (int i = 0; i < m_Tanks.Length; i++) {
            message += m_Tanks[i].m_ColoredPlayerText + ": " + m_Tanks[i].m_Wins + " WINS\n";
        }

        if (m_GameWinner != null)
            message = m_GameWinner.m_ColoredPlayerText + " WINS THE GAME!";

        return message;
    }

    public void ResetAllTanks() {
        for (int i = 0; i < m_Tanks.Length; i++) {
            m_Tanks[i].Reset();
        }
    }


    public void EnableTankControl() {
        for (int i = 0; i < m_Tanks.Length; i++) {
            m_Tanks[i].EnableControl();
        }
    }


    public void DisableTankControl() {
        for (int i = 0; i < m_Tanks.Length; i++) {
            m_Tanks[i].DisableControl();
        }
    }

    private IEnumerator SetInvinsible()
    {
        yield return new WaitForSeconds(3f);

        isInvinsible = false;
    }
}