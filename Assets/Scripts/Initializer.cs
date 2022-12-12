using UnityEngine;
using System.Collections;
using System.IO;

public class Initializer : MonoBehaviour
{
	public bool ready;
	public FogController fogController;
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
		myListener = (MyListener)GameObject.FindObjectOfType(typeof(MyListener));
		//string dataPath = Application.streamingAssetsPath;
		dataPath = Application.dataPath;
		dataPath += "\\Resources\\";
		dateAndTime = System.DateTime.Now.ToString("yyyyMMdd_HHmmss");
		FileStream file = File.Create(dataPath + "Readings\\" + "GSR_" + dateAndTime + ".csv");
		file.Close();
		dataFile = new StreamWriter(dataPath + "Readings\\" + "GSR_" + dateAndTime + ".csv",true, System.Text.Encoding.UTF8, 1024 * 3);
		string nextLine = "Time, X Position, Y Position, Z Position, GSR, m, b, distance";
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

		if (m_timer > duration * 60)
		{
			ready = true;
			// calculate mapping m,b from y=mx+b
			float normalizedInitMax = m_initMax - m_initMin;
			float normalizedGlobalMax = mapGlobalMax - mapGlobalMin;

			// m = desired data/current data
			// y = ( x - current data global min )*m + desired global min
			//   Subtract and add the two mins so that both current and desired data starts at 0, for multiplication.  
			float m = 0;
			float b = 200;
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
		string nextLine = m_timer + "," + head.transform.position.x + "," + head.transform.position.y + "," + head.transform.position.z + "," + data;
		nextLine += "," + fogController.mapFcn_m + "," + fogController.mapFcn_b + "," + RenderSettings.fogEndDistance;
		dataFile.WriteLine(nextLine);
		dataFile.Close();
	}
}
