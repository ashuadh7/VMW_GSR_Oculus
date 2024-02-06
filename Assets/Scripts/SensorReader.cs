using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorReader : MonoBehaviour
{
    private RealTimeScaler scaler;
    private float sensorValue;

    void Start()
    {
        // Initialize scaler (3 minutes = 180 seconds)
        scaler = new RealTimeScaler(180, 150, 700, 0.1f);
    }

    void Update()
    {
        // Get sensor value
        sensorValue = ReadSensor();  // Replace this with your actual sensor reading function

        // Pass sensor value to scaler
        float scaledValue = scaler.ObserveAndScale(sensorValue);

        // Use scaled value
        Debug.Log("Scaled Value: " + scaledValue);
    }

    private float ReadSensor()
    {
        // Replace this with your actual sensor reading function
        return Random.Range(5, 100);  // For testing purposes, generate a random float between 5 and 100
    }
}

public class RealTimeScaler
{
    private float observationTime;
    private float lowerLimit;
    private float upperLimit;
    private float marginPercent;
    private List<float> observationData = new List<float>();
    private bool observationPeriod = true;
    private float minVal;
    private float maxVal;
    private bool hasCrossedThreshold = false;

    public RealTimeScaler(float observationTime, float lowerLimit, float upperLimit, float marginPercent)
    {
        this.observationTime = observationTime;
        this.lowerLimit = lowerLimit;
        this.upperLimit = upperLimit;
        this.marginPercent = marginPercent;
    }

    public float ObserveAndScale(float value)
    {
        this.observationData.Add(value);

        if (this.observationData.Count * (1f / 60f) > this.observationTime)  // convert data points to time
        {
            if (this.observationPeriod)  // just finished observation period
            {
                this.maxVal = Mathf.Max(this.observationData.ToArray());
                this.minVal = Mathf.Min(this.observationData.ToArray());
                float rangeVal = this.maxVal - this.minVal;
                this.maxVal += this.marginPercent * rangeVal;
                this.minVal -= this.marginPercent * rangeVal;
                this.observationPeriod = false;  // Now, we are out of the observation period
            }

            // Scale the value and reverse
            value = this.upperLimit - ((value - this.minVal) / (this.maxVal - this.minVal)) * (this.upperLimit - this.lowerLimit);

            // Apply constraints
            if (value > 500)
            {
                this.hasCrossedThreshold = true;
            }
            if (value < 150)
            {
                value = 150;
            }
            else if (this.hasCrossedThreshold && value < 500)
            {
                value = 500;
            }
            if (value > 1000)  // Limit maximum to 1000
            {
                value = 1000;
            }
        }

        return value;
    }
}
