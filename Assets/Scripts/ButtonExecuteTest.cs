using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Включение и выключение шланга с интервалом в 5 секунд.
/// </summary>
public class ButtonExecuteTest : MonoBehaviour 
{
    private GameObject startButton, stopButton;
    private bool on = false;
    private float timer = 5;


    #region MonoBehaviour

    void Start () 
    {
        startButton = GameObject.Find("StartButton");
        stopButton = GameObject.Find("StopButton");
    }
	
    void Update () 
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            on = !on;
            timer = 5;

            PointerEventData data = new PointerEventData(EventSystem.current);

            if (on)
            {
                // Посылаем событие OnClick кнопке.
                ExecuteEvents.Execute<IPointerClickHandler>(startButton, data, ExecuteEvents.pointerClickHandler);
            }
            else
            {
                ExecuteEvents.Execute<IPointerClickHandler>(stopButton, data, ExecuteEvents.pointerClickHandler);
            }
        }
    }
	
    #endregion
}
