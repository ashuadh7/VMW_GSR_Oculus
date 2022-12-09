using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityOSC;
using UnityEngine.UI;
public class OSCManager : MonoBehaviour
{
    public static OSCManager instance = null;
    public Text text;

    public float CurrentOSCReading { get; private set; }

   
    //private Dictionary<string, ClientLog> clients;
	// Use this for initialization
    private Dictionary<string, ServerLog> servers;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
	void Start ()
	{
	    //CurrentOSCReading = 1.0f;
	    CurrentOSCReading = 0.0f;
	    OSCHandler.Instance.Init();
	    //OSCHandler.Instance.CreateClient("BioGraph", IPAddress.Parse("127.0.0.1"), 9109);
	    OSCHandler.Instance.CreateServer("BioGraphOSC", 9109);
	    servers = new Dictionary<string, ServerLog>();
        //clients = new Dictionary<string, ClientLog>();
    }
	
	// Update is called once per frame
    void Update()
    {
           for (var i = 0; i < OSCHandler.Instance.packets.Count; i++)
           {
               ReceivedOSC(OSCHandler.Instance.packets[i]);
               
            }
        OSCHandler.Instance.packets.Clear();
        //Dictionary<string, ServerLog> servers = new Dictionary<string, ServerLog>();
        //servers = OSCHandler.Instance.Servers;
        //foreach (var serverLog in servers)
        //{
        //serverLog.Value.server.LastReceivedPacket.Data
        //}
        //servers = OSCHandler.Instance.Servers;
        //OSCHandler.Instance.UpdateLogs();
        //foreach (KeyValuePair<string, ServerLog> item in servers)
        //{
        //    // If we have received at least one packet,
        //    // show the last received from the log in the Debug console
        //    if (item.Value.log.Count > 0)
        //    {
        //        int lastPacketIndex = item.Value.packets.Count - 1;
        //        UnityEngine.Debug.Log(String.Format("SERVER: {0} ADDRESS: {1} VALUE : {2}",
        //            item.Key, // Server name
        //            item.Value.packets[lastPacketIndex].Address, // OSC address
        //            item.Value.packets[lastPacketIndex].Data[0].ToString())); //First data value
        //        //converts the values into MIDI to scale the cube
        //        Byte tempVal = Byte.Parse(item.Value.packets[lastPacketIndex].Data[0].ToString());
        //        Debug.Log(tempVal);
        //        //cube.transform.localScale = new Vector3(tempVal, tempVal, tempVal);
        //    }

    }

    private void ReceivedOSC(OSCPacket pckt)
    {
        if (pckt == null)
        {
            Debug.Log("Empty packet");
            return;
        }
        
        int serverPort = pckt.server.ServerPort;
        string address = pckt.Address.Substring(1);
        //for (int i = 0; i < pckt.Data.Count; i++)
        //{
        //    Debug.Log(pckt.BinaryData[i]);

        //Debug.Log(i + " " + OSCBundle.Unpack(pckt.BinaryData));
        //}
        
        string data0 = pckt.Data[0].ToString();
        //Debug.Log("Input port: " + serverPort.ToString() + "\nAddress: " + address + "\nData [0]: " + data0);
        if (text != null)
        {
            text.text = "Input port: " + serverPort.ToString() + "\nAddress: " + address + "\nData [0]: " + data0;
        }
        CurrentOSCReading = float.Parse(data0); //  should have tried TryParse
    }

    
}
