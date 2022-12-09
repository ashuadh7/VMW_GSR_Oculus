using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class StereoCameras : MonoBehaviour
{
	// this class is important for the head, and we should make it standalone for inclusion in other projects - pete
	public float m_aspect = 1.6F; //16:10
	public float m_HFOV = 1.047F; //60 Degrees
	public float m_IOD = 0.063F; //63mm
	public float m_DisplayWidth = 2.5f; //meters
	public float m_ZPD = 4.0f; //Zero Parallax Distance
	public bool m_passive=true;
	private Camera LeftCamera;
	private Camera RightCamera;
	private GameObject ZPP;
	private GameObject BindiCamera;
	public  int m_ReflectionFactor=1;  // this should be an enum for clarity - pete
	
	private bool	m_SendCameraUpdate;
	
	public delegate void CameraChangeHandler( Camera cam );  // is this stuff important to this class, or just for AOTSM? - pete
	public event CameraChangeHandler CameraChange;

	void Start()
	{
		LeftCamera = transform.Find( "Left Camera" ).GetComponent<Camera>();
		RightCamera = transform.Find( "Right Camera" ).GetComponent<Camera>();
		ZPP = transform.Find( "ZPP" ).gameObject;
		BindiCamera = transform.Find( "Bindi Camera" ).gameObject;
		if(LeftCamera == null || RightCamera == null || ZPP == null) Debug.LogError("The Stereo Head is missing some pieces");

		// attach to the tweeker to get update events
//		GameObject MCP = GameObject.Find("MasterControlProgram");  // this is specific to AOTSM and should be factored out somehow - pete
//		Tweeker tw = MCP.GetComponent<Tweeker>( );
//		tw.TweekerUpdated += TweekerUpdated;
		
		m_SendCameraUpdate = true;
	}
	
	void LateUpdate()
	{
		if(m_passive && (LeftCamera != null || RightCamera != null || ZPP != null))
		{
			// it is very inefficient to do all this every frame - move it to TweekerUpdated ?
			BindiCamera.active = false;
			RightCamera.gameObject.tag="MainCamera";
			RightCamera.gameObject.active=true;
			LeftCamera.gameObject.active=true;
			LeftCamera.transform.localPosition=new Vector3(-m_IOD/2.0f, 0.0f, 0.0f);
			RightCamera.transform.localPosition=new Vector3(m_IOD/2.0f, 0.0f,0.0f);
			
			ZPP.transform.localScale=new Vector3( 2.0f * Mathf.Tan(m_HFOV/2.0f)*m_ZPD/10, 1.0f,  2.0f * Mathf.Tan(m_HFOV/2.0f)/m_aspect*m_ZPD/10); 
			ZPP.transform.localPosition=new Vector3(0.0f, 0.0f, m_ZPD);
	
			Matrix4x4 m = PerspectiveOffCenter(LeftCamera.nearClipPlane, LeftCamera.farClipPlane, m_HFOV, m_aspect, m_IOD, m_ZPD, true, m_ReflectionFactor);
			LeftCamera.projectionMatrix = m;
	
			m = PerspectiveOffCenter(RightCamera.nearClipPlane, RightCamera.farClipPlane, m_HFOV, m_aspect, m_IOD, m_ZPD, false, m_ReflectionFactor);
			RightCamera.projectionMatrix = m;

			SendCameraUpdate( RightCamera );
		}
		else
		{
			BindiCamera.active = true;
			BindiCamera.gameObject.tag="MainCamera";
			RightCamera.gameObject.active=false;
			LeftCamera.gameObject.active=false;
			SendCameraUpdate( BindiCamera.GetComponent<Camera>() );
		}
	}
	
	private void SendCameraUpdate( Camera cam )
	{
		if( m_SendCameraUpdate )
		{
			m_SendCameraUpdate = false;
			
			if( CameraChange != null )
				CameraChange( cam );
		}
	}
	
	static Matrix4x4 PerspectiveOffCenter(float near, float far, float m_HFOV, float m_aspect, float m_IOD, float m_ZPD, bool isLeft, int ReflectionFactor) {
		float VFOV = 2.0f * Mathf.Atan(Mathf.Tan(m_HFOV/2.0f)/m_aspect);
		float frustumShift = (m_IOD/2.0f)*near/m_ZPD;
		if(isLeft) frustumShift=-frustumShift;

		float top = near * Mathf.Tan(VFOV/2.0f);
		float bottom = -top;
		float left = -top*m_aspect - frustumShift;
		float right =  top*m_aspect - frustumShift;
		
		float x = (2.0F * near) / (right - left);
		float y = (2.0F * near) / (top - bottom);
		float a = (right + left) / (right - left);
		float b = (top + bottom) / (top - bottom);
		float c = -(far + near) / (far - near);
		float d = (-2.0F * far * near) / (far - near);
		float e = -1.0F;
		Matrix4x4 m = Matrix4x4.identity;
		m[0, 0] = ReflectionFactor*x;
		m[0, 1] = 0;
		m[0, 2] = ReflectionFactor*a;
		m[0, 3] = 0;
		m[1, 0] = 0;
		m[1, 1] = y;
		m[1, 2] = b;
		m[1, 3] = 0;
		m[2, 0] = 0;
		m[2, 1] = 0;
		m[2, 2] = c;
		m[2, 3] = d;
		m[3, 0] = 0;
		m[3, 1] = 0;
		m[3, 2] = e;
		m[3, 3] = 0;
		GL.SetRevertBackfacing(ReflectionFactor==-1);
		return m;
	}

//	public void TweekerUpdated( )
//	{
//		// we should find a better way to handle these updates that doesnt rely on direct connection to tweeker - pete
//		
//		float IOD = Tweeker.IOD.m_Data;
//		if( IOD != m_IOD )
//            m_IOD = IOD;
//	
//		float ZPD = Tweeker.ZPD.m_Data;
//		if( ZPD != m_ZPD )
//            m_ZPD = ZPD;
//		
//		bool passive = Tweeker.Passive3D.m_Data;
//		if( passive != m_passive )
//			m_passive = passive;
//		
//		int reflect;
//		if(Tweeker.MirrorImage.m_Data) 
//			reflect = -1;
//		else reflect = 1;
//		
//		if(reflect != m_ReflectionFactor)
//			m_ReflectionFactor=reflect;
//		
//		// lets always send a camera update - the logic is easier that way
//		m_SendCameraUpdate = true;
//	}

}