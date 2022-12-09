using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//using Vectrosity;
using UnityEngine.UI;

public class Plotter : MonoBehaviour
{
    
    #region private fields
    [SerializeField] private Text debugText;
    [SerializeField] private Bloom cameraBloom;
    //private CircularBuffer<Vector2> readingsBuffer;
    //private int currentCursor;
    //private VectorLine line;
    private Vector2 point;
    private float x = 0;
    private float increment = 0.5f;
    private List<float> lastReadings;   // utility field for the readings, to calc. mean/std dev
    private int currentInd;
    #endregion
    #region  public fields
    public const int MAX_READINGS = 150;
    //public const float TIME_BETWEEN_READINGS = 1.0f;
    //public const float PLOT_SPREAD = 250.0f;
    #endregion

    void Start ()
    {
        //Debug.Log("Fog density: " + RenderSettings.fogDensity);
        //Debug.Log("Fog color: " + RenderSettings.fogColor);
        //RenderSettings.fogDensity = 0.5f;
		//readingsBuffer = new CircularBuffer<Vector2>(MAX_READINGS);
        lastReadings = new List<float>();
        currentInd = 0;
        for (int i = 0; i < MAX_READINGS; ++i)
        {
            lastReadings.Add(0);
        }
        //currentCursor = 0;
        //for (int i = 0; i < readingsBuffer.Count; i++)
        //{
        //    x += increment;
        //    point = new Vector2(x, 250);
        //    readingsBuffer.Add(point);
        //}
        //x = 0;
        //line = new VectorLine("MyLine", readingsBuffer.ToList(), 3.0f, LineType.Continuous);
        //line.SetColor(Color.black);
        //line.Draw();
        if (cameraBloom == null)
        {
            cameraBloom = Camera.main.GetComponent<Bloom>();
            if (cameraBloom == null)
            {
                Camera.main.gameObject.AddComponent<Bloom>();
                cameraBloom = Camera.main.GetComponent<Bloom>();
                cameraBloom.quality = Bloom.BloomQuality.Cheap;
                cameraBloom.tweakMode = Bloom.TweakMode.Complex;
                cameraBloom.screenBlendMode = Bloom.BloomScreenBlendMode.Screen;
                cameraBloom.hdr = Bloom.HDRBloomMode.Auto;
                cameraBloom.bloomIntensity = 2.0f;
                cameraBloom.bloomThreshhold = 0.5f;
                cameraBloom.bloomThreshholdColor = Color.white;
                cameraBloom.bloomBlurIterations = 4;
                cameraBloom.blurWidth = 2.0f;
                cameraBloom.lensflareMode = Bloom.LensFlareStyle.Anamorphic;
                cameraBloom.lensflareIntensity = 0;
                cameraBloom.lensflareThreshhold = 0.3f;
            }
        }
    }
	
	void Update ()
	{
        
	}

    private void FixedUpdate()
    {
        var reading = OSCManager.instance.CurrentOSCReading;
        //x += increment;
        //if (x >= Screen.width)
        //{
        //    x = 0.0f;
        //    while (readingsBuffer.Count > 0)
        //    {
        //        readingsBuffer.Read();
        //    }
        //}
        //readingsBuffer.Add(new Vector2(x,  PLOT_SPREAD *reading));
        //line.points2 = readingsBuffer.ToList();
        //line.SetColor(Color.black);
        //line.Draw();
        //yield return new WaitForSeconds(TIME_BETWEEN_READINGS);
        // mean std.dev of the last readings
        //int ind = 0;
        //foreach (var readingVector2 in readingsBuffer.ToList())
        //{
        //    lastReadings[ind] = (readingVector2.y / PLOT_SPREAD) - 1.0f;
        //    ind++;
        //}
        lastReadings[currentInd] = reading;
        float oldestVal = currentInd == 0 ? lastReadings[MAX_READINGS - 1] : lastReadings[currentInd - 1];
        // TODO: find a better routine for trends
        // look at the individual differences between each of the data
        // points, then see if they are more likely to increase or decrease (inc/dec amount)
        // if std.dev is > threshold, go to the inc/dec amount's direction
        bool isTrendNotDownwards = reading - oldestVal >= 0.00f;
        string trendStr = isTrendNotDownwards ? "Not downwards" : "Downwards";
        currentInd = currentInd == (MAX_READINGS - 1) ? 0 : currentInd + 1;
        float mean = lastReadings.Average();
        float sumOfSquaredDifferences = lastReadings.Select(val => (val - mean) * (val - mean)).Sum();
        float stdDev = Mathf.Sqrt(sumOfSquaredDifferences / MAX_READINGS);
        if (isTrendNotDownwards)
        {
            cameraBloom.bloomIntensity =
                Mathf.Lerp(cameraBloom.bloomIntensity, 0f, Time.deltaTime  * 1.25f);

          //  Mathf.Lerp(cameraBloom.bloomIntensity, 0f, Time.fixedDeltaTime * stdDev * 2.5f);
            cameraBloom.bloomThreshhold =
                Mathf.Lerp(cameraBloom.bloomThreshhold, 0.5f, Time.deltaTime * 1.25f);
            cameraBloom.bloomThreshholdColor =
                Color.Lerp(cameraBloom.bloomThreshholdColor, Color.white, Time.deltaTime * 1.25f);
        }
        else
        {
            cameraBloom.bloomIntensity =
                Mathf.Lerp(cameraBloom.bloomIntensity, -2.0f, Time.fixedDeltaTime * 1.25f);
            //Mathf.Lerp(cameraBloom.bloomIntensity, -2.0f, Time.fixedDeltaTime * stdDev * 2.5f);
            cameraBloom.bloomThreshhold =
                Mathf.Lerp(cameraBloom.bloomThreshhold, 0.1f, Time.deltaTime * 1.25f);
            //Mathf.Lerp(cameraBloom.bloomThreshhold, 0.1f, Time.deltaTime * stdDev * 5.0f);
            cameraBloom.bloomThreshholdColor =
                Color.Lerp(cameraBloom.bloomThreshholdColor, Color.black, Time.deltaTime * 1.25f);
        }
        if (debugText != null)
        {
            debugText.text = "Mean: " + mean.ToString("0.0") + "\nStd.Dev: " + stdDev.ToString("0.00") + "\n" +
                             lastReadings[0] + " " + lastReadings[MAX_READINGS - 1] + " " + trendStr;

        }
    }

}
