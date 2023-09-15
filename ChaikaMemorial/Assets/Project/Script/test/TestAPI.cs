using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RestSharp;
using System.Net;
using UnityEngine.Networking;

public class TestAPI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SendHTTPRequest());
    }

    IEnumerator SendHTTPRequest()
    {
        string url = "http://162.43.28.83/game/UserTable";

        // UnityWebRequestを作成
        UnityWebRequest request = UnityWebRequest.Get(url);

        // リクエストを送信し、レスポンスを待つ
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("HTTPリクエストエラー: " + request.error);
        }
        else
        {
            // レスポンスを取得
            string responseText = request.downloadHandler.text;
            Debug.Log("HTTPレスポンス: " + responseText);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
