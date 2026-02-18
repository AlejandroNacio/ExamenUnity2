using UnityEngine;
using UnityEngine.SceneManagement;

public class Derrota : MonoBehaviour
{
 public void Jugar()
 {
 SceneManager.LoadScene("Jugar");
 }


 public void Salir()
 {
 Application.Quit();
 Debug.Log("Saliendo del juego...");
 }
}
