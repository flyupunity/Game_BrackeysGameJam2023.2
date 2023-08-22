using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Analytics;
using Unity.Services.Core;
using Unity.Services.Core.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class UGS_Analytics : MonoBehaviour
{
    /*async void Start()
    {
        try
        {
            await UnityServices.InitializeAsync();
            LevelCompletedCustomEvent();
        }
        catch (ConsentCheckException e)
        {
            Debug.Log(e.ToString());
        }
    }
    async void FixedUpdate()
    {
	if(SceneManager.GetActiveScene().name == "Game")
        {
            try
            {
                await UnityServices.InitializeAsync();
                AteFishCustomEvent();
            }
            catch (ConsentCheckException e)
            {
                Debug.Log(e.ToString());
            }
        }
    }
    private void LevelCompletedCustomEvent()
    {
        //int currentLevel = Random.Range(1, 4);
        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            { "levelName", SceneManager.GetActiveScene().name}
        };

        AnalyticsService.Instance.CustomData("levelCompleted", parameters);
        AnalyticsService.Instance.Flush();
        //Analytics.FlushEvents();
   }
    private void AteFishCustomEvent()
    {
        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            { "Ate fishes", GameObject.FindGameObjectsWithTag("Fish").Length}
        };

        AnalyticsService.Instance.CustomData("Ate_FishEvent", parameters);
        AnalyticsService.Instance.Flush();
        //Analytics.FlushEvents();
   }*/
}
