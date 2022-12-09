using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
//using TMPro;

public class MyListener : MonoBehaviour
{
    public static MyListener instance;
    Thread thread;
    public int connectionPort = 25000;
    TcpListener server;
    TcpClient client;
    bool running;
    public bool startedReceivingData = false;
    private bool firstTime = true;
    //[SerializeField]
    //private Text text;
    [SerializeField]
    private GameObject startVMW;
    public int mmValue;
    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
        // Receive on a separate thread so Unity doesn't freeze waiting for data
        ThreadStart ts = new ThreadStart(GetData);
        thread = new Thread(ts);
        thread.Start();
    }

    void GetData()
    {
        // Create the server
        server = new TcpListener(IPAddress.Any, connectionPort);
        server.Start();

        // Create a client to get the data stream
        client = server.AcceptTcpClient();

        // Start listening
        running = true;
        while (running)
        {
            Connection();
        }
        server.Stop();
    }

    void Connection()
    {
        // Read data from the network stream
        NetworkStream nwStream = client.GetStream();
        byte[] buffer = new byte[client.ReceiveBufferSize];
        int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);
        Debug.Log("bytes: " +  bytesRead);
        // Decode the bytes into a string
        string dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);
        Debug.Log("data: " + dataReceived);

        //string dataReceived = bytesRead.ToString();

        // Make sure we're not getting an empty string
        //dataReceived.Trim();
        if (dataReceived != null && dataReceived != "")
        {
            startedReceivingData = true;
            
            Debug.Log("data: " + dataReceived);
            mmValue = int.Parse(dataReceived);
            // Convert the received string of data to the format we are using
            //position = ParseData(dataReceived);
            nwStream.Write(buffer, 0, bytesRead);
        }
    }

    // Use-case specific function, need to re-write this to interpret whatever data is being sent
    public static Vector3 ParseData(string dataString)
    {
        Debug.Log(dataString);
        // Remove the parentheses
        if (dataString.StartsWith("(") && dataString.EndsWith(")"))
        {
            dataString = dataString.Substring(1, dataString.Length - 2);
        }

        // Split the elements into an array
        string[] stringArray = dataString.Split(',');

        // Store as a Vector3
        Vector3 result = new Vector3(
            float.Parse(stringArray[0]),
            float.Parse(stringArray[1]),
            float.Parse(stringArray[2]));

        return result;
    }

    // Position is the data being received in this example
    //Vector3 position = Vector3.zero;

    void Update()
    {
        if (startedReceivingData)
        {
            if (firstTime)
            {
                //text.text = "Connected";
                startVMW.SetActive(true);
                firstTime = false;
            }
        }
        
        // Set this object's position in the scene according to the position received
        //transform.position = position;
    }
}