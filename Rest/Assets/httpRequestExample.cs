using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

using UnityEngine.Networking;

public class httpRequestExample : MonoBehaviour
{
    [SerializeField] private string url;

    delegate void Message();
    private Message mes;

    //for message 
    private const string type = "testType";
    private const string data = "testdata";


    //time
    private float cooldownBeforeSend=5f;


    private void Start()
    {

    }

    private void Update()
    {
        if (mes!=null) {
            Invoke(nameof(sendEvents), cooldownBeforeSend); 
        }

    }


    private void newEvetn()
    {
        StartCoroutine(TrackEvent(type.ToString(), data.ToString()));

    }
    private IEnumerator TrackEvent(string type, string data)
    {

        //Post  создать------------------------------------------------------------

        WWWForm formData = new WWWForm();

        PostStruct post = new PostStruct()
        {
            title = type,                                               
            body = data
        };

          string json = JsonUtility.ToJson(post);
          UnityWebRequest request = UnityWebRequest.Post(this.url, formData);

          byte[] postBytes = Encoding.UTF8.GetBytes(json);

          UploadHandler uploadHandler = new UploadHandlerRaw(postBytes);

          request.uploadHandler = uploadHandler;

          request.SetRequestHeader("Content-Type", "application/json; charset= UTF-8");

          yield return request.SendWebRequest();

        if(request.isNetworkError)
        {
            Debug.Log("NetworkError");
        }
        else
        {
            Debug.Log("Response Code :" + request.responseCode);

            PostStruct postFromServer = JsonUtility.FromJson<PostStruct>(request.downloadHandler.text);

            Debug.Log("id:" + postFromServer.id);
            Debug.Log("type:" + postFromServer.title);            //type
            Debug.Log("data:" + postFromServer.body);             //data
        }

    }

    public void addnewEvent()
    {
         mes += newEvetn;
    }

    public void sendEvents()
    {
        mes?.Invoke();
        mes = null;
    }

}
