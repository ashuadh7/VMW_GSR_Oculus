using UnityEngine;
using System.Collections;

public class VMW_Master : MonoBehaviour
{
	
	// mouse looking
	private float		sensitivityX = 2f;
    private float		sensitivityY = 2f;
	private float		speedH = .5f;
    private float		speedV = .5f;
    private float		minimumX = -360f;
    private float		maximumX = 360f;
    private float		minimumY = -30f;
    private float		maximumY = 30f;
    private float		rotationX = 0F;
    private float		rotationY = 0F;
    private Quaternion	originalRotation;
	private Transform 	m_Head;
	
	// FPS
	private bool			m_ShowFps;
	private float			m_Fps;
	private float			m_FpsUpdateInterval;
	private float			m_FpsAccum;
	private int				m_FpsFrames;
	private float			m_FpsTimeleft;
	
	void Start()
	{
		m_Head = transform;
		originalRotation = m_Head.localRotation;
		Cursor.visible = false;
		
		m_ShowFps = false;
		m_Fps = 0.0f;
		m_FpsUpdateInterval = 0.5f;
		m_FpsAccum = 0.0f;
		m_FpsFrames = 0;
		m_FpsTimeleft = m_FpsUpdateInterval;
		
	}
	
	void Update()
	{
		if( m_ShowFps )
		{
			m_FpsTimeleft -= Time.deltaTime;
		    m_FpsAccum += Time.timeScale/Time.deltaTime;
		    ++m_FpsFrames;
		   
		    if( m_FpsTimeleft <= 0.0 )
		    {
				m_Fps = Mathf.RoundToInt( m_FpsAccum/m_FpsFrames );
		        m_FpsTimeleft = m_FpsUpdateInterval;
		        m_FpsAccum = 0.0F;
		        m_FpsFrames = 0;
		    }
		}
		
		if( Input.GetKeyDown( "f" ) )
		{
			Debug.Log( "f" );
			if( m_ShowFps )
				m_ShowFps = false;
			else
				m_ShowFps = true;
		}

		if( Input.GetKeyDown( KeyCode.Escape ) )
		{
			Debug.Log( "Esc" );
			Application.LoadLevel(Application.loadedLevel);
		}

			
		rotationX += Input.GetAxis("Mouse X") * sensitivityX + Input.GetAxis("Horizontal") * speedH;
		rotationY += Input.GetAxis("Mouse Y") * sensitivityY + Input.GetAxis("Vertical") * speedV;
		
		rotationX = ClampAngle (rotationX, minimumX, maximumX);
		rotationY = ClampAngle (rotationY, minimumY, maximumY);
		
		Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
		Quaternion yQuaternion = Quaternion.AngleAxis (rotationY, -Vector3.right);

		// Commenting out next line will disable mouse updates, it messes up w/Oculus head tracking
		//m_Head.localRotation = originalRotation * xQuaternion * yQuaternion;
		
	}
	
	void OnGUI()
	{
		if( m_ShowFps )
		{
			// show FPS in upper left
			int x = 10;
			int y = 70;
			GUI.Label( new Rect( x,y,200,25 ), "FPS: " + m_Fps.ToString() );
		}
	}
	
	
	public void ResetScene()
	{		
		//RenderSettings.fogDensity = m_DefaultFogDensity;
	}
	
    private static float ClampAngle (float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp (angle, min, max);
    }
	
}
