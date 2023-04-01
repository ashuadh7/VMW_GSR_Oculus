using UnityEngine;
using System.Collections;
using System.IO;

public class FogController : MonoBehaviour 
{
	[HideInInspector]
	public float mapFcn_m = 0;
	[HideInInspector]
	public float mapFcn_b = 550;
	public float distance;

	//public GameObject head;

	public Datamanager m_data;
	public Initializer m_initializer;

	//[SerializeField]
    private float m_modifier = 1;
	[SerializeField]
	private float distance_maxChange = 50;
	[SerializeField]
	private int average_over = 100;
	private float[] running_distance;
	private float average_distance;
	private int count = 0;
	private int counter = 0;
	private float prevFogDistance = 150;
	//private string dateAndTime;
	//private new StreamWriter dataFile;
	private void Start()
	{
		RenderSettings.fog = true;
		RenderSettings.fogMode = FogMode.Linear;
		RenderSettings.fogEndDistance = 150;
		//dateAndTime = System.DateTime.Now.ToString("yyyyMMdd_HHmmss");
		//dataFile = new StreamWriter("Readings\\" + "Later_" + dateAndTime + ".csv", true, System.Text.Encoding.UTF8, 1024 * 3);
		//string nextLine = "Time, X Position, Y Position, Z Position, GSR";
		//dataFile.WriteLine(nextLine);
		//dataFile.Close();
		running_distance = new float[average_over];
		for (int i = 0; i < average_over; i++)
        {
			running_distance[i] = 150;
        }
	}

	private void Update()
	{
		
		float curData = m_data.currData;
		float prevData = m_data.prevData;

		float newFogDensity = curData * m_modifier;

		if (m_initializer.ready)
		{
			newFogDensity = -(mapFcn_m * newFogDensity) + m_initializer.mapGlobalMax - mapFcn_b;
			if (float.IsNaN(newFogDensity) || newFogDensity < 150)
			{
				newFogDensity = 150;
			}
			if (count < average_over)
			{
				running_distance[count] = newFogDensity;
				count++;
			}
			else
			{
				if (counter < average_over)
				{
					running_distance[counter] = newFogDensity;
					counter++;
				}
				else
                {
					running_distance[0] = newFogDensity;
					counter = 1;
                }

				for (int i = 0; i < average_over; i++)
                {
					average_distance += running_distance[i];
                }
				average_distance /= average_over;
				newFogDensity = average_distance;
				RenderSettings.fogEndDistance = newFogDensity;
			}
			prevFogDistance = newFogDensity;
		}
	}

}
