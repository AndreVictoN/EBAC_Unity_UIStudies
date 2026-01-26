using UnityEngine;

public class Car : MonoBehaviour
{
    public GameObject carPrefab;

    public int speed = 20;
    public int gear = 5;

    public int TotalSpeed
    {
        get { return speed * gear; }
    }

    public void InstantiateCar()
    {
        var car = Instantiate(carPrefab);
        if(car) car.transform.localPosition = Vector3.zero;
    }
}
