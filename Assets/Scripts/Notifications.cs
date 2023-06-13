using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class Notifications : MonoBehaviour
{
    private bool isGameRunning = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    void Start()
    {
        //Creating new channel to show notifications
        var channel = new AndroidNotificationChannel()
        {
            Id = "channel id",
            Name = "Default Channel",
            Description = "Default",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        // Game is now running
        isGameRunning = true;
    }

    private void OnDestroy()
    {
        if (isGameRunning)
        {
            ScheduleNotification();
        }
    }

    private void ScheduleNotification()
    {
        var notification = new AndroidNotification();
        notification.Title = "Missed you!";
        notification.Text = "I was joking!";
        notification.FireTime = System.DateTime.Now.AddMinutes(1);
        AndroidNotificationCenter.SendNotification(notification, "channel id");
    }
}