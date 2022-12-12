using UnityEngine;
using System.Collections;
using System.IO;

public class FogController : MonoBehaviour 
{
	[HideInInspector]
	public float mapFcn_m;
	[HideInInspector]
	public float mapFcn_b;
	public float distance;

	//public GameObject head;

	public Datamanager m_data;
	public Initializer m_initializer;

	//[SerializeField]
    private float m_modifier = 1;
	[SerializeField]
	private float m_maxChange;
	//private string dateAndTime;
	//private new StreamWriter dataFile;
	private void Start()
	{
		RenderSettings.fog = true;
		RenderSettings.fogMode = FogMode.Linear;
		RenderSettings.fogEndDistance = 350;
		//dateAndTime = System.DateTime.Now.ToString("yyyyMMdd_HHmmss");
		//dataFile = new StreamWriter("Readings\\" + "Later_" + dateAndTime + ".csv", true, System.Text.Encoding.UTF8, 1024 * 3);
		//string nextLine = "Time, X Position, Y Position, Z Position, GSR";
		//dataFile.WriteLine(nextLine);
		//dataFile.Close();
	}

	private void Update()
	{

		float curData = m_data.currData;
		float prevData = m_data.prevData;

		float newFogDensity = curData * m_modifier;
		float prevFogDensity = prevData * m_modifier;

		if (m_initializer.ready)
		{
			newFogDensity = -(mapFcn_m * newFogDensity) + m_initializer.mapGlobalMax - mapFcn_b;
			//newFogDensity = (newFogDensity - mapFcn_b) * mapFcn_m + 10;
			Debug.Log("Fog Density: " + newFogDensity);
			//if (newFogDensity > 0)
			{
				RenderSettings.fogEndDistance = newFogDensity;
				print("Change to: " + RenderSettings.fogEndDistance);
				print("Current Data: " + curData + " Modifier: " + m_modifier);
			}
			
			//dataFile = new StreamWriter("Readings\\" + "Later_" + dateAndTime + ".csv", true, System.Text.Encoding.UTF8, 1024 * 3);
			//string nextLine = m_initializer.m_timer + "," + head.transform.position.x + "," + head.transform.position.y + "," + head.transform.position.z + "," + curData;
			//dataFile.WriteLine(nextLine);
			//dataFile.Close();
		}
	}

}
