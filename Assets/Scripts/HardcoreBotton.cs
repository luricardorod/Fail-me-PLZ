using UnityEngine;
using System.Collections;

public class HardcoreBotton : MonoBehaviour
{
    public string ButtonName;
    public int TimesToBePressed = 10, TimesPressed = 0;
    public float TimeToPress = 3, TimeLeftToPress = 5f;
    public bool isTheBottomOnScreen = false;
    public GameObject textoRevivir;
    public GameObject personaje;
    public GameObject gameOver;

    // Use this for initialization
    void Start()
    {
        ButtonName = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        //Si tienes el boton en la pantalla
        Debug.Log(isTheBottomOnScreen);
        if(isTheBottomOnScreen)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            transform.position = new Vector3(transform.position.x, personaje.transform.position.y, transform.position.z);
            textoRevivir.transform.position = new Vector3(transform.position.x, transform.position.y, -4);
            textoRevivir.GetComponent<TextMesh>().text = TimesPressed.ToString() + "/" + TimesToBePressed.ToString() + "\n" + "¡NO TE RINDAS!" + "\n" + TimeLeftToPress.ToString("F2");
            //textoTiempoRestante.transform.position = new Vector3(transform.position.x, transform.position.y, -1);
            //textoTiempoRestante.GetComponent<TextMesh>().text = TimeLeftToPress.ToString();

            //Si aun tienes tiempo y aun no llegas a la meta de clics
            if (TimeLeftToPress > 0 && TimesPressed < TimesToBePressed)
            {
                //Disminuir el tiempo restante
                TimeLeftToPress -= Time.deltaTime;
                //Permitir clic
                if (Input.GetMouseButtonUp(0) && Physics.Raycast(ray, out hit) && hit.collider.name == ButtonName)
                {
                    TimesPressed++;
                };
            };
            //Si aun tienes tiempo y llegaste a la meta de clics
           if (TimeLeftToPress > 0 && TimesPressed >= TimesToBePressed)
            {
                TimesToBePressed *= 2; //Incrementar en 8 cuantas veces se debe presionar el boton.
                TimesPressed = 0; //Resetear el numero de veces tocadas el boton.
                TimeToPress += 1; //Incrementar en 1 el tiempo para presionar el boton.
                TimeLeftToPress = TimeToPress; //Resetear el tiempo restante para tocar el boton al maximo.
                isTheBottomOnScreen = false;
                gameObject.SetActive(false);
                textoRevivir.GetComponent<TextMesh>().text = "";
                personaje.SetActive(true);
                //codigo de revivir al jugador
            }
            //Si se te acabo el tiempo y no haz llegado a la meta de clics
            else if (TimeLeftToPress < 0 && TimesPressed < TimesToBePressed)
            {
                //Regresar las variables del boton a sus originales.
                Debug.Log("lola");
                StartCoroutine(Wait());
                //Codigo de valer madres
            };
        };
	}

  IEnumerator Wait()  {
    Debug.Log("pancho");
        // suspend execution for 5 seconds
        gameOver.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z -1);
        gameOver.SetActive(true);
        gameObject.SetActive(false);
				yield return new WaitForSeconds(4f);
        Application.LoadLevel("Menu");
  }


}
