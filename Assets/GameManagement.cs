using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManagement : MonoBehaviour {

    public static bool isClear;

    public Text ClearText;
    public Text TimeText;

    public GameObject[] MapList;
    public GameObject[] LightList;
    public Color[] ColorList;
    public GameObject Player;

    int Count = 0;
    float countTime = 0;
    GameObject CurrentMap;
    GameObject CurrentLight;

    Vector3 MapPosition = new Vector3(-7.5f, 0, 7.5f);
    Quaternion MapRotation = Quaternion.Euler(0, 0, 0);

    Vector3 PlayerPosition;
    Quaternion PlayerRotation;
	// Use this for initialization
	void Start () {
        CurrentMap = Instantiate(MapList[Count], MapPosition, MapRotation);
        PlayerPosition = Player.transform.position;
        PlayerRotation = Player.transform.rotation;

    }
	
	// Update is called once per frame
	void Update () {
        if(!isClear)
            TimeCalc();
        if (isClear)
        {
            ClearText.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Count++;

                Destroy(CurrentMap);
                foreach(GameObject light in LightList)
                {
                    light.GetComponent<Light>().color = ColorList[Count];
                }

                CurrentMap = Instantiate(MapList[Count],MapPosition, MapRotation);

                isClear = false;
                countTime = 0;
                ClearText.gameObject.SetActive(false);
                Player.transform.position = PlayerPosition;
                Player.transform.rotation = PlayerRotation;

            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void TimeCalc()
    {
        countTime += Time.deltaTime;

        int min = Mathf.FloorToInt(countTime / 60);
        float sec = Mathf.FloorToInt(countTime % 60);
        if (sec < 10)
            TimeText.text = min + ":0" + sec;
        else
            TimeText.text = min + ":" + sec;
    }
}
