using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ClickButtonNext : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2; 
    public GameObject button3; 
    public GameObject button4; 
    public GameObject button5; 
    public GameObject A; 
    public GameObject B;
    public GameObject C;
    public GameObject D;
    public GameObject E;
    public GameObject stend;
    public GameObject finish;

    // Start is called before the first frame update
    void Start()
    {
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(false);
        button5.SetActive(false);
        B.SetActive(false);
        C.SetActive(false);
        D.SetActive(false);
        E.SetActive(false);
        stend.SetActive(false);
        finish.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Next(int step){
        Debug.Log(step);
        switch (step)
        {
            case 1:
                A.SetActive(false);
                B.SetActive(true);
                button1.SetActive(false);
                button2.SetActive(true);
                break;
            case 2:
                B.SetActive(false);
                C.SetActive(true);
                button2.SetActive(false);
                button3.SetActive(true);
                break;
            case 3:
                C.SetActive(false);
                D.SetActive(true);
                button3.SetActive(false);
                button4.SetActive(true);
                break;
            case 4:
                D.SetActive(false);
                E.SetActive(true);
                button4.SetActive(false);
                button5.SetActive(true);
                break;
            case 5:
                E.SetActive(false);
                stend.SetActive(true);
                button5.SetActive(false);
                finish.SetActive(true);
                break;
            case 6:
                StartCoroutine(SendPostCoroutine());
                stend.SetActive(false);
                finish.SetActive(false);
                break;
        }
    }

    IEnumerator SendPostCoroutine()
    {
        WWWForm form = new WWWForm();
        form.AddField("valueOne", "some stuff");

        using (UnityWebRequest www = UnityWebRequest.Post("http://indieteam.online/api/v1/control_points/ivanov", form))
        {
            yield return www.Send();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("POST successful!");
                StringBuilder sb = new StringBuilder();
                foreach (System.Collections.Generic.KeyValuePair<string, string> dict in www.GetResponseHeaders())
                {
                    sb.Append(dict.Key).Append(": \t[").Append(dict.Value).Append("]\n");
                }

                // Print Headers
                Debug.Log(sb.ToString());

                // Print Body
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
}
