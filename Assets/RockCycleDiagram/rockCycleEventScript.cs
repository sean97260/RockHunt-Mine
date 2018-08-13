using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockCycleEventScript : MonoBehaviour {

    float granitePos_x;
    float granitePos_y;

    float rainPos_x;
    float rainPos_y;

    float pressurePos_x;
    float pressurePos_y;

    float sandPos_x;
    float sandPos_y;

    float heatPos_x;
    float heatPos_y;

    float heat1Pos_x;
    float heat1Pos_y;

    float pressure1Pos_x;
    float pressure1Pos_y;

    float coolingPos_x;
    float coolingPos_y;

    float windPos_x;
    float windPos_y;

    float sandstonePos_x;
    float sandstonePos_y;

    float metaqPos_x;
    float metaqPos_y;

    float magmaPos_x;
    float magmaPos_y;

    float riverPos_x;
    float riverPos_y;


    GameObject granite;
    GameObject sand;
    GameObject pressure;
    GameObject rain;
    GameObject river;
    GameObject metaq;
    GameObject sandstone;
    GameObject heat1;
    GameObject pressure1;
    GameObject wind;
    GameObject cooling;
    GameObject heat;
    GameObject magma;

    GameObject change1;
    GameObject change2;
    GameObject change3;
    GameObject change4;
    GameObject change5;


    bool f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13 = false;

	// Use this for initialization
	void Start () {
        granitePos_x = GameObject.Find("select (3)").transform.position.x;
        granitePos_y = GameObject.Find("select (3)").transform.position.y;
        rainPos_x = GameObject.Find("select (2)").transform.position.x;
        rainPos_y = GameObject.Find("select (2)").transform.position.y;
        windPos_x = GameObject.Find("select (5)").transform.position.x;
        windPos_y = GameObject.Find("select (5)").transform.position.y;
        riverPos_x = GameObject.Find("select (4)").transform.position.x;
        riverPos_y = GameObject.Find("select (4)").transform.position.y;
        pressure1Pos_x = GameObject.Find("select (8)").transform.position.x;
        pressure1Pos_y = GameObject.Find("select (8)").transform.position.y;
        sandstonePos_x = GameObject.Find("select (11)").transform.position.x;
        sandstonePos_y = GameObject.Find("select (11)").transform.position.y;
        pressurePos_x = GameObject.Find("select (7)").transform.position.x;
        pressurePos_y = GameObject.Find("select (7)").transform.position.y;
        heatPos_x = GameObject.Find("select (6)").transform.position.x;
        heatPos_y = GameObject.Find("select (6)").transform.position.y;
        heat1Pos_x = GameObject.Find("select (14)").transform.position.x;
        heat1Pos_y = GameObject.Find("select (14)").transform.position.y;
        magmaPos_x = GameObject.Find("select (13)").transform.position.x;
        magmaPos_y = GameObject.Find("select (13)").transform.position.y;
        coolingPos_x = GameObject.Find("select (9)").transform.position.x;
        coolingPos_y = GameObject.Find("select (9)").transform.position.y;
        metaqPos_x = GameObject.Find("select (10)").transform.position.x;
        metaqPos_y = GameObject.Find("select (10)").transform.position.y;
        sandPos_x = GameObject.Find("select (1)").transform.position.x;
        sandPos_y = GameObject.Find("select (1)").transform.position.y;

        granite = GameObject.Find("Granite");
        sand = GameObject.Find("sand");
        pressure = GameObject.Find("pressure");
        heat = GameObject.Find("heat");
        rain = GameObject.Find("rain");
        heat1 = GameObject.Find("heat (1)");
        pressure1 = GameObject.Find("pressure (1)");
        sandstone = GameObject.Find("sandstone");
        metaq = GameObject.Find("metaq");
        magma = GameObject.Find("magma");
        wind = GameObject.Find("wind");
        river = GameObject.Find("river");
        cooling = GameObject.Find("cooling");

        change1 = GameObject.Find("weathering and erosion");
        change2 = GameObject.Find("heatAndPressure");
        change3 = GameObject.Find("Melting");
        change4 = GameObject.Find("Cooling");
        change5 = GameObject.Find("Compacting");

        change1.SetActive(false);
        change2.SetActive(false);
        change3.SetActive(false);
        change4.SetActive(false);
        change5.SetActive(false);

	}

    // Update is called once per frame
    void Update()
    {
        if (!f1) { print("f1"); }
        if (!f2) { print("f2"); }
        if (!f3) { print("f3"); }
        if (!f4) { print("f4"); }
        if (!f5) { print("f5"); }
        if (!f6) { print("f6"); }
        if (!f7) { print("f7"); }
        if (!f8) { print("f8"); }
        if (!f9) { print("f9"); }
        if (!f10) { print("f10"); }


        if (f1 && f2 && f3 && f4 && f5 && f6 && f7 && f8 && f9 && f10){
            print("good to go!");
        }
        if (closeTo(granite.transform.position.x, granite.transform.position.y, granitePos_x, granitePos_y))
        {
            f1 = true;
        }
        else
        {
            f1 = false;
        }

        if (
            (closeTo(river.transform.position.x, river.transform.position.y, riverPos_x, riverPos_y)
             &&closeTo(wind.transform.position.x, wind.transform.position.y, windPos_x, windPos_y)
             &&closeTo(rain.transform.position.x, rain.transform.position.y, rainPos_x, rainPos_y))

            ||
            (closeTo(river.transform.position.x, river.transform.position.y, windPos_x, windPos_y)
             && closeTo(wind.transform.position.x, wind.transform.position.y, riverPos_x, riverPos_y)
             && closeTo(rain.transform.position.x, rain.transform.position.y, rainPos_x, rainPos_y))

            ||
            (closeTo(river.transform.position.x, river.transform.position.y, rainPos_x, rainPos_y)
             && closeTo(wind.transform.position.x, wind.transform.position.y, riverPos_x, riverPos_y)
             && closeTo(rain.transform.position.x, rain.transform.position.y, windPos_x, windPos_y))

            ||
            (closeTo(river.transform.position.x, river.transform.position.y, riverPos_x, riverPos_y)
             && closeTo(wind.transform.position.x, wind.transform.position.y, rainPos_x, rainPos_y)
             && closeTo(rain.transform.position.x, rain.transform.position.y, windPos_x, windPos_y))

            ||
            (closeTo(river.transform.position.x, river.transform.position.y, windPos_x, windPos_y)
             && closeTo(wind.transform.position.x, wind.transform.position.y, rainPos_x, rainPos_y)
             && closeTo(rain.transform.position.x, rain.transform.position.y, riverPos_x, riverPos_y))


            ||
            (closeTo(river.transform.position.x, river.transform.position.y, rainPos_x, rainPos_y)
             && closeTo(wind.transform.position.x, wind.transform.position.y, windPos_x, windPos_y)
             && closeTo(rain.transform.position.x, rain.transform.position.y, riverPos_x, riverPos_y))
           )
        {
            f2 = true;
            change1.SetActive(true);
        }
        else
        {
            f2 = false;
            change1.SetActive(false);
        }

        if (closeTo(sand.transform.position.x, sand.transform.position.y, sandPos_x, sandPos_y))
        {
            f3 = true;
        }
        else
        {
            f3 = false;
        }

        if (closeTo(pressure.transform.position.x, pressure.transform.position.y, pressure1Pos_x, pressure1Pos_y)
            || closeTo(pressure1.transform.position.x, pressure1.transform.position.y, pressure1Pos_x, pressure1Pos_y))
        {
            f4 = true;
            change5.SetActive(true);
        }
        else
        {
            f4 = false;
            change5.SetActive(false);
        }

        if ((closeTo(heat.transform.position.x, heat.transform.position.y, heatPos_x, heatPos_y)
             && closeTo(pressure.transform.position.x, pressure.transform.position.y, pressurePos_x, pressurePos_y))

            ||
            (closeTo(pressure.transform.position.x, pressure.transform.position.y, heatPos_x, heatPos_y)
             && closeTo(heat.transform.position.x, heat.transform.position.y, pressurePos_x, pressurePos_y))

            ||
            (closeTo(pressure1.transform.position.x, pressure1.transform.position.y, heatPos_x, heatPos_y)
             && closeTo(heat.transform.position.x, heat.transform.position.y, pressurePos_x, pressurePos_y))

            ||
            (closeTo(heat.transform.position.x, heat.transform.position.y, heatPos_x, heatPos_y)
             && closeTo(pressure1.transform.position.x, pressure1.transform.position.y, pressurePos_x, pressurePos_y))

            ||
            (closeTo(pressure.transform.position.x, pressure.transform.position.y, heatPos_x, heatPos_y)
             && closeTo(heat1.transform.position.x, heat1.transform.position.y, pressurePos_x, pressurePos_y))

            ||
            (closeTo(heat1.transform.position.x, heat1.transform.position.y, heatPos_x, heatPos_y)
             && closeTo(pressure.transform.position.x, pressure.transform.position.y, pressurePos_x, pressurePos_y))

            ||
            (closeTo(heat1.transform.position.x, heat1.transform.position.y, heatPos_x, heatPos_y)
             && closeTo(pressure1.transform.position.x, pressure1.transform.position.y, pressurePos_x, pressurePos_y))

            ||
            (closeTo(heat1.transform.position.x, heat1.transform.position.y, heatPos_x, heatPos_y)
             && closeTo(pressure1.transform.position.x, pressure1.transform.position.y, pressurePos_x, pressurePos_y))
             
            ||
            (closeTo(pressure1.transform.position.x, pressure1.transform.position.y, heatPos_x, heatPos_y)
             && closeTo(heat1.transform.position.x, heat1.transform.position.y, pressurePos_x, pressurePos_y))
            
            )
        {
            change2.SetActive(true);
            f5 = true;
        }
        else
        {
            change2.SetActive(false);
            f5 = false;
        }

        if (closeTo(heat1.transform.position.x, heat1.transform.position.y, heat1Pos_x, heat1Pos_y)
            || closeTo(heat.transform.position.x, heat.transform.position.y, heat1Pos_x, heat1Pos_y))
        {
            f6 = true;
            change3.SetActive(true);
        }
        else
        {
            f6 = false;
            change3.SetActive(false);
        }


        if (closeTo(sandstone.transform.position.x, sandstone.transform.position.y, sandstonePos_x, sandstonePos_y))
        {
            f7 = true;
        }
        else
        {
            f7 = false;
        }

        if (closeTo(metaq.transform.position.x, metaq.transform.position.y, metaqPos_x, metaqPos_y))
        {
            f8 = true;
        }
        else
        {
            f8 = false;
        }

        if (closeTo(magma.transform.position.x, magma.transform.position.y, magmaPos_x, magmaPos_y))
        {
            f9 = true;
        }
        else
        {
            f9 = false;
            print(magma.transform.position.x);
            print(magma.transform.position.y);
            print(magmaPos_x);
            print(magmaPos_y);
        }

        if (closeTo(cooling.transform.position.x, cooling.transform.position.y, coolingPos_x, coolingPos_y))
        {
            f10 = true;
            change4.SetActive(true);
        }
        else
        {
            f10 = false;
            change4.SetActive(false);
        }
    }

    bool closeTo(float x1, float y1, float x2, float y2){

        if(Mathf.Abs(x1-x2)<= 0.1 && Mathf.Abs(y1-y2)<= 0.6){
            return true;
        }
        return false;
    }
}
