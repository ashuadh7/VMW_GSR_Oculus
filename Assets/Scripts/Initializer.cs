using UnityEngine;
using System.Collections;
using System.IO;

public class Initializer : MonoBehaviour
{
	public bool ready;
	public bool walkDone;
	public FogController fogController;
	public GameObject cameraRig;
	public GameObject head;
	private MyListener myListener;
	public float mapGlobalMax;
	public float mapGlobalMin;
	public float m_timer = 0f;
	private float m_initMax = -1;
	private float m_initMin = 10000;
	[SerializeField]
	private float duration = 4;
	private StreamWriter dataFile;
	string dateAndTime;
	string dataPath;


	// Use this for initialization
	void Start()
	{
		ready = false;
		walkDone = false;
		myListener = (MyListener)GameObject.FindObjectOfType(typeof(MyListener));
		//string dataPath = Application.streamingAssetsPath;
		dataPath = Application.dataPath;
		dataPath += "\\Resources\\";
		dateAndTime = System.DateTime.Now.ToString("yyyyMMdd_HHmmss");
		FileStream file = File.Create(dataPath + "Readings\\" + "GSR_" + dateAndTime + ".csv");
		file.Close();
		dataFile = new StreamWriter(dataPath + "Readings\\" + "GSR_" + dateAndTime + ".csv",true, System.Text.Encoding.UTF8, 1024 * 3);
		string nextLine = "Time, CameraRig_X_Pos, CameraRig_Y_Pos, CameraRig_Z_Pos, Head_X_Pos, Head_Y_Pos," +
						   "Head_Z_Pos, Head_X_Rot, Head_Y_Rot, Head_Z_Rot, GSR, m, b, distance";
		dataFile.WriteLine(nextLine);
		dataFile.Close();
	}

	// Update is called once per frame
	void Update()
	{
		m_timer += Time.deltaTime;
		float data = myListener.mmValue;
		if (data < m_initMin) m_initMin = data;
		if (data > m_initMax) m_initMax = data;

		if (m_timer > duration * 60 && !walkDone)
		{
			ready = true;
			// calculate mapping m,b from y=mx+b
			float normalizedInitMax = m_initMax - m_initMin;
			float normalizedGlobalMax = mapGlobalMax - mapGlobalMin;

			// m = desired data/current data
			// y = ( x - current data global min )*m + desired global min
			//   Subtract and add the two mins so that both current and desired data starts at 0, for multiplication.  
			float m = 0;
			float b = 550;
			if (normalizedInitMax != 0)
			{
				m = normalizedGlobalMax / normalizedInitMax;
				b = -m * m_initMin + mapGlobalMin;
			}
			fogController.mapFcn_b = b;
			fogController.mapFcn_m = m;
			Debug.Log("m: " + m);
			Debug.Log("b: " + b);
		}

		if (m_timer > 1250)
		{
			mapGlobalMax = 1500;
			mapGlobalMin = 700;
			walkDone = true;
			float normalizedInitMax = m_initMax - m_initMin;
			float normalizedGlobalMax = mapGlobalMax - mapGlobalMin;

			// m = desired data/current data
			// y = ( x - current data global min )*m + desired global min
			//   Subtract and add the two mins so that both current and desired data starts at 0, for multiplication.  
			float m = 0;
			float b = 550;
			if (normalizedInitMax != 0)
			{
				m = normalizedGlobalMax / normalizedInitMax;
				b = -m * m_initMin + mapGlobalMin;
			}
			fogController.mapFcn_b = b;
			fogController.mapFcn_m = m;
			Debug.Log("m: " + m);
			Debug.Log("b: " + b);
		}
		Debug.Log("mmValue: " + myListener.mmValue);
		//RenderSettings.fogEndDistance += 8 * Time.deltaTime;
		dataFile = new StreamWriter(dataPath + "Readings\\" + "GSR_" + dateAndTime + ".csv", true, System.Text.Encoding.UTF8, 1024 * 3);
		string nextLine = m_timer + "," + cameraRig.transform.position.x + "," + cameraRig.transform.position.y + "," + cameraRig.transform.position.z;
		nextLine += "," + head.transform.position.x + "," + head.transform.position.y + "," + head.transform.position.z;
		nextLine += "," + head.transform.rotation.eulerAngles.x + "," + head.transform.rotation.eulerAngles.y + "," + head.transform.rotation.eulerAngles.z;
		nextLine += "," +data + "," + fogController.mapFcn_m + "," + fogController.mapFcn_b + "," + RenderSettings.fogEndDistance;
		dataFile.WriteLine(nextLine);
		dataFile.Close();
	}
}
