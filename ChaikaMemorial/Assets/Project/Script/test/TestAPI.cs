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

        // UnityWebRequest���쐬
        UnityWebRequest request = UnityWebRequest.Get(url);

        // ���N�G�X�g�𑗐M���A���X�|���X��҂�
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("HTTP���N�G�X�g�G���[: " + request.error);
        }
        else
        {
            // ���X�|���X���擾
            string responseText = request.downloadHandler.text;
            Debug.Log("HTTP���X�|���X: " + responseText);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
