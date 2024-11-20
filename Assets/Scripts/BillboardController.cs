using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BillboardController : MonoBehaviour
{
    public MeshRenderer[] billboards;

    public string[] URLs;

    private Dictionary<string, Texture2D> dictionary = new();

    private void Awake()
    {
        for (int i = 0; i < billboards.Length; i++) AddImage(URLs[i], i);
    }

    private void AddImage(string url, int meshID)
    {
        if (dictionary.ContainsKey(url)) return;

        StartCoroutine(DownloadImage(url, tex =>
        {
            dictionary.Add(url, tex);
            billboards[meshID].material.mainTexture = tex;
        }));
    }

    public IEnumerator DownloadImage(string url, Action<Texture2D> callback)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();
        callback(DownloadHandlerTexture.GetContent(request));
    }

}