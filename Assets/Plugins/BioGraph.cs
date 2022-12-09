using UnityEngine;
using System.Runtime.InteropServices;

public class BioGraph : MonoBehaviour
{
	
	[DllImport ("BioGraphUnity")]
	private static extern bool DoInitialize(); 

	[DllImport ("BioGraphUnity")]
	private static extern bool DoConnect(); 

	[DllImport ("BioGraphUnity")]
	private static extern void DoTerminate(); 

	[DllImport ("BioGraphUnity")]
	private static extern void DoDisconnect(); 

	[DllImport ("BioGraphUnity")]
	private static extern float GetValue( int channel ); 
	
	bool Initialize( )
	{
	    return DoInitialize();
	}
	
	void Terminate( )
	{
	    DoTerminate();
	}
	
	bool Connect( )
	{
	    return DoConnect();
	}
	
	void Disconnect( )
	{
	    DoDisconnect();
	}
	
	float GetChannelValue( int channel )
	{
	    return GetValue( channel );
	}

    private bool isInit = false;
    private bool isConnected = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isInit = Initialize();
            Debug.Log(isInit + " init");
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Terminate();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            isConnected = Connect();

            Debug.Log(isConnected + " connect");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Disconnect();
        }
        if (isConnected)
        {
            for (int i = 0; i < 8; i++)
            {
                Debug.Log("Channel " + i + " value: " + GetChannelValue(i));
            }
        }
    }
}
