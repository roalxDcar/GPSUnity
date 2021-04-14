using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPSLocation : MonoBehaviour
{
    // Start is called before the first frame update

    public float latitud;
    public float longitud;
    public Text gpsText;
    public Text placeText;
    void Start()
    {
        if(Input.location.isEnabledByUser)
        StartCoroutine(GetLocation());
    }

    private IEnumerator GetLocation()
    {
        Input.location.Start();
        while(Input.location.status == LocationServiceStatus.Initializing)
        {
            yield return new WaitForSeconds(0.2f);
            // yield return new WaitForSeconds(0.5f);
        }

        latitud = Input.location.lastData.latitude;
        longitud = Input.location.lastData.longitude;
        yield break;

    }

    // Update is called once per frame
    void Update()
    {
        latitud = Input.location.lastData.latitude;
        longitud = Input.location.lastData.longitude;
      	gpsText.text = "Latitud:"+latitud + " Longitud "+ longitud;
        
        // Hogar
        //  && latitud>=(-16.50423+0.00010) && longitud<(-68.20837-0.00010) && longitud>(-68.20837+0.00010)
        if(latitud>(-16.50423-0.00010)&& latitud<(-16.50423+0.00010) && longitud>(-68.20837-0.00010) && longitud<(-68.20837+0.00010)){
            placeText.text = "Lugar de Ubicación de la familia Mollericona // Z. Pedro Domingo Murillo C. Gregorio Garcia Lanza ";
        }else if(latitud>(-16.50550-0.00010)&& latitud<(-16.50550+0.00010) && longitud>(-68.20692-0.00010) && longitud<(-68.20692+0.00010)){
            placeText.text = "Colegio San Vicente de Paúl Z. Pedro Domingo Murillo C. Gregorio Garcia Lanza // Av. Bartolome Andrade";
    	}else if(latitud>(-16.50478-0.00010)&& latitud<(-16.50478+0.00010) && longitud>(-68.20615-0.00010) && longitud<(-68.20615+0.00010)){
            placeText.text = "Capilla VIRGEN MILAGROSA // Calle Landaveri";
        }else if(latitud>(-16.50394-0.00010)&& latitud<(-16.50394+0.00010) && longitud>(-68.20488-0.00010) && longitud<(-68.20488+0.00010)){
            placeText.text = "Plaza Cívica // Av. AYO AYO";
        }else{
            placeText.text = "";
        }
    }
}