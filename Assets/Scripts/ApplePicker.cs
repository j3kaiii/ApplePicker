using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -4f;
    public float basketSpacingY = 1f;
    public List<GameObject> basketsList;
    // Start is called before the first frame update
    void Start()
    {
        basketsList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject basketGO = Instantiate<GameObject>(basketPrefab);
            Vector2 pos = Vector2.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            basketGO.transform.position = pos;
            basketsList.Add(basketGO);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AppleDestroyed()
    {
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject go in appleArray)
        {
            Destroy(go);
        }

        int basketIndex = basketsList.Count - 1;
        GameObject basketGO = basketsList[basketIndex];
        basketsList.RemoveAt(basketIndex);
        Destroy(basketGO);

        if (basketsList.Count == 0)
        {
            SceneManager.LoadScene("Outro");
        }
    }
}
