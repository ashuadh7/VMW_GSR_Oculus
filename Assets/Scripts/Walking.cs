using UnityEngine;
using System.Collections;
using System.IO;

public class Walking : MonoBehaviour {

	public GameObject m_Waypoint;
	public GameObject m_splinePath;
	public Vector3 m_footOffset;
	public float	m_walkSpeed = 1.4f;
	public float m_bioMontrics = 0.0001f;
	private Vector3 ground;
	
	// Use this for initialization
	void Start () {
		iTween.Init(gameObject);
		//RenderSettings.fogDensity=m_bioMontrics;
		//StreamWriter dataFile = new StreamWriter("Path.csv");
		//string nextLine = "Time,PosX,PosY,PosZ,AngX,AngY,AngZ";
		//dataFile.WriteLine(nextLine);
		//dataFile.Close();
		//StartCoroutine(SaveInfo());
	}

	void Update() {
		//RenderSettings.fogDensity=m_bioMontrics;
	}
	
	void Awake() {
		Vector3[] pathArray = iTweenPath.GetPath(m_splinePath.name);
		iTween.MoveTo(gameObject,iTween.Hash("name", "Walk", "path", pathArray, "speed", m_walkSpeed, "easetype", iTween.EaseType.linear, "orienttopath", true, "lookahead", 0.01, "delay", 5, "looptype",iTween.LoopType.none));
		print("Path length:" + iTween.PathLength(pathArray));
		for(int x=0; x<pathArray.Length; x++) {
			RaycastHit hit;
			Physics.Raycast(pathArray[x], Vector3.down, out hit, 100f);
			//print("Path Height " + (x + 1.0f)  + "=" + (hit.distance));
			
		}
		
	}
	
	void OnGUI() {
		if(Event.current.type==EventType.ScrollWheel) {

			Vector2 dB=Event.current.delta;
			string readout = "";
			if(Mathf.Abs(dB.x)>1.0f) {
				m_bioMontrics-=( dB.x * (m_bioMontrics*0.1f + 0.00001f));
				if(m_bioMontrics<0f) m_bioMontrics=0f;
				//RenderSettings.fogDensity=m_bioMontrics;
				//readout = "Fog Density:" + m_bioMontrics;
			}

			if(Mathf.Abs(dB.y)>1.0f) {
				m_walkSpeed+=(Event.current.delta.y*0.25f);
				readout += "Speed:" + m_walkSpeed;
			}
			
			iTween tween = gameObject.GetComponent("iTween") as iTween;
			if(tween != null) tween.setPathSpeed(m_walkSpeed);

			//print(readout);
		}
	
	}

	//private IEnumerator SaveInfo()
	//{
	//	while (true)
	//	{
	//		StreamWriter dataFile = new StreamWriter("Path.csv", true, System.Text.Encoding.UTF8, 1024 * 3);
	//		string nextLine = Time.realtimeSinceStartup + "," + this.transform.position.x + "," + this.transform.position.y + "," + this.transform.position.z + ",";
	//		nextLine += this.transform.rotation.eulerAngles.x + "," + this.transform.rotation.eulerAngles.y + "," + this.transform.rotation.eulerAngles.z;
	//		//string nextLine = "Time,PosX,PosY,PosZ,AngX,AngY,AngZ";
	//		dataFile.WriteLine(nextLine);
	//		dataFile.Close();
	//		yield return new WaitForSeconds(2f);
	//	}
		
	//}
}
