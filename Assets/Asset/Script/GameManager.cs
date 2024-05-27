using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour
{
    public static Action<string[]> startGame = delegate { };
    const string testurl = "https://pas2-game-rd-lb.sayyogames.com:61337/api/unityexam/getroll";
    private string status;
    private string msg;
    private string[] currentroll = {"a","a","a","a","a","a","a","a","a","a","a","a","a","a","a"};
    
    // Start is called before the first frame update
    void Start()
    {
    }

    public string GetStatus() => status;
    public string GetMsg() => msg;
    public string[] GetRoll() => currentroll;

    public void OnClick() {
        _ = StartCoroutine(PostRequest());       
    }

    IEnumerator PostRequest()
    {
        string method = "spin";
        string param = "test";
        // Create a WWWForm
        WWWForm form = new WWWForm();
        form.AddField("METHOD", method);
        form.AddField("PARAMS", param);
      
        using (UnityWebRequest www = UnityWebRequest.Post(testurl, form))
        {
            // Send the request
            yield return www.SendWebRequest();
            bool success = false;
            if (www.result == UnityWebRequest.Result.Success)
            {
                success = true;
                Debug.Log("POST Success: " + www.downloadHandler.text);
            }
            else
            {
                success = false;
                Debug.Log("POST Error: " + www.error);
            }
            
            string[] json;
            json = www.downloadHandler.text.Split(",");
            if (json[0].Contains("0")|| !success)
            {
                yield break;
            }
            string[][] jsonfield = new string[3][];
            for (int i=0;i<3;i++) {
                jsonfield[i] = json[i].Split(":");
            }
            status = jsonfield[0][1];
            msg = jsonfield[1][1];
            string temp = www.downloadHandler.text[www.downloadHandler.text.IndexOf("[")..www.downloadHandler.text.IndexOf("]")];
            currentroll = temp[1..].Replace("\"","").Split(",");
            //Debug.Log("Status: " + status);
            //Debug.Log("MSG: " + msg);
            //Debug.Log("Currentroll: " + string.Concat(currentroll));
            startGame(currentroll);
        }
    }
}
