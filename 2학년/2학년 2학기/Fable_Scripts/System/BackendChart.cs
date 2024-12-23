using BackEnd;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackendChart
{
    private static BackendChart instance;

    public static BackendChart Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new BackendChart();
            }
            return instance;
        }
    }

    public void GetChart(string chartId)
    {
        var bro = Backend.Chart.GetChartContents(chartId);

        if(bro.IsSuccess() == false)
        {
            return;
        }

        foreach(LitJson.JsonData gamedata in bro.FlattenRows())
        {
            Information.Instance.gameversion.Add(gamedata["gameversion"].ToString());
        }
    }
}
