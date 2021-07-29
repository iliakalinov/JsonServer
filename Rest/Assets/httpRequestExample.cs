using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

using UnityEngine.Networking;

public class httpRequestExample : MonoBehaviour
{
    [SerializeField] private string url;


    private void Start()
    {
        StartCoroutine(SendRequest());
    }



    private IEnumerator SendRequest()
    {



        //GET    получить------------------------------------------------
        /* UnityWebRequest request = UnityWebRequest.Get(this.url);

           yield return request.SendWebRequest();

           //  Debug.Log(request.downloadHandler.text);//write all


           //TODO
           string json = "{\"posts\":" + request.downloadHandler.text + "}";

           Response response = JsonUtility.FromJson<Response>(json);


           Debug.Log("UserID:" + response.posts[0].userId);
           Debug.Log("id:" + response.posts[0].id);
           Debug.Log("title:" + response.posts[0].title);
           Debug.Log("body:" + response.posts[0].body);*/



        //Post  создать------------------------------------------------------------

        /*  WWWForm formData = new WWWForm();

          PostStruct post = new PostStruct()
          {
              user    Id = 101,
              title = "test",
              body = "Created new Objects"
          };

          string json = JsonUtility.ToJson(post);
          UnityWebRequest request = UnityWebRequest.Post(this.url, formData);

          byte[] postBytes = Encoding.UTF8.GetBytes(json);

          UploadHandler uploadHandler = new UploadHandlerRaw(postBytes);

          request.uploadHandler = uploadHandler;

          request.SetRequestHeader("Content-Type", "application/json; charset= UTF-8");

          yield return request.SendWebRequest();

          PostStruct postFromServer = JsonUtility.FromJson<PostStruct>(request.downloadHandler.text);



          Debug.Log("UserID:" + postFromServer.userId);
          Debug.Log("id:" + postFromServer.id);
          Debug.Log("title:" + postFromServer.title);
          Debug.Log("body:" + postFromServer.body); */


        //Put           ---обновить

        /*PostStruct post = new PostStruct()
        {
            userId = 101,
            title = " Update test",
            body = "Update new Objects"
        };

        string json = JsonUtility.ToJson(post);

        UnityWebRequest request = UnityWebRequest.Put(this.url, json);

        request.SetRequestHeader("Content-Type", "application/json; charset= UTF-8");


        yield return request.SendWebRequest();

        PostStruct postFromServer = JsonUtility.FromJson<PostStruct>(request.downloadHandler.text);

        Debug.Log("UserID:" + postFromServer.userId);
        Debug.Log("id:" + postFromServer.id);
        Debug.Log("title:" + postFromServer.title);
        Debug.Log("body:" + postFromServer.body); 

         */

        //DELETE
        UnityWebRequest request = UnityWebRequest.Delete(this.url);
        yield return request.SendWebRequest();

        Debug.Log(request.responseCode); 




    }

}
