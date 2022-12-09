using System.IO;
using UnityEngine;

public class ScaleBehaviour : MonoBehaviour
{
    private bool isScaleActive;
    private float counter, 
                  hoverCounter;
    private SpriteRenderer panelRenderer, 
                           confirmRenderer;
    private int lastSelectedDigit;

    [SerializeField]
    private float timer,
                  hoverTimer,
                  panelDistance,
                  gazeMoveRate;

    [SerializeField]
    private GameObject[] digits,
                         digitColliders;

    [SerializeField]
    private Vector3[] indicatorPositions;

    [SerializeField]
    private GameObject confirmButton,
                       gazeIndicator;

    [SerializeField]
    private Sprite confirmHoverSprite, 
                   confirmSprite;


    [SerializeField]
    private string appName;

	private void Start ()
    {
        panelRenderer = GetComponent<SpriteRenderer>();
        confirmRenderer = confirmButton.GetComponent<SpriteRenderer>();
        isScaleActive = false;
        counter = 0.0f;
        hoverCounter = 0.0f;
        lastSelectedDigit = -1;
        gazeMoveRate = Mathf.Approximately(gazeMoveRate, 0.0f) ? 20.0f : gazeMoveRate;
        panelDistance = Mathf.Approximately(panelDistance, 0.0f) ? 20.0f : panelDistance;
	}
	
	private void Update ()
    {
        CheckActive();
        CheckGaze();
	}

    private void CheckActive()
    {
        if (isScaleActive == false)
        {
            counter += Time.deltaTime;
            if(counter >= timer)
            {
                isScaleActive = true;
                gazeIndicator.SetActive(true);
                confirmButton.SetActive(true);
            }
        }
    }

    private void TurnOffPanel()
    {
        isScaleActive = false;
        gazeIndicator.SetActive(false);
        confirmButton.SetActive(false);
        counter = 0.0f;
        hoverCounter = 0.0f;
        WriteToFile();    
        Debug.Log("User selected digit: " + lastSelectedDigit.ToString());
    }

    private void WriteToFile()
    {
        var now = System.DateTime.Now;
        string path = Application.dataPath + "/" +appName + "_" + now.Month.ToString("00") +
                          now.Day.ToString("00") +
                          now.Year.ToString() + ".txt";
        string content = lastSelectedDigit.ToString() + "\t" +
            now.ToString() + System.Environment.NewLine;
        if (File.Exists(path))
        {
            File.AppendAllText(path, content);
        }
        else
        {
            File.WriteAllText(path, content);
        }
    }

    private void CheckGaze()
    {
        if (isScaleActive)
        {
            var cam = Camera.main.transform;
            var ray = new Ray(cam.position, cam.forward);
            RaycastHit[] hits;
            hits = Physics.RaycastAll(ray, panelDistance);
            foreach (RaycastHit hit in hits)
            {
                for (int i = 0; i < digits.Length; i++)
                {
                    if (hit.collider.gameObject == digits[i])
                    {
                        Debug.Log(i);
                        gazeIndicator.transform.position = Vector3.Lerp(gazeIndicator.transform.position,
                                                                        digits[i].transform.position,
                                                                        Time.deltaTime * gazeMoveRate);
                        confirmButton.transform.position = gazeIndicator.transform.position + Vector3.down * 1.0f + Vector3.forward * 1.0f;
                        lastSelectedDigit = i;
                    }
                    else if (hit.collider.gameObject == confirmButton)
                    {
                        if (confirmRenderer.sprite == confirmHoverSprite)
                        {
                            hoverCounter += Time.deltaTime;
                            if (hoverCounter >= hoverTimer)
                            {
                                TurnOffPanel();
                            }
                        }
                        else
                        {
                            confirmRenderer.sprite = confirmHoverSprite;
                            hoverCounter = Time.deltaTime;
                        }
                    }

                }
            }
        }
    }
}
