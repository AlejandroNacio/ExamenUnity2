using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
	 public int puntos = 0;
	 public TMP_Text textoPuntos;

	 public int vidas = 2;
	 public TMP_Text textoVidas;

	 public void SumarVida(){
		 vidas +=1;
		 ActualizarUI();
	 }

	 public void SumarPuntos(){
		 puntos +=1;
		 ActualizarUI();
	 }

	 public void QuitarVida(){
		 vidas -=1;
		 ActualizarUI();
	 }


	 void ActualizarUI()
	 {
		if (textoPuntos != null)
		{
			textoPuntos.text = puntos.ToString();
		}
		if (textoVidas != null)
		{
			textoVidas.text = vidas.ToString();
		}

	 }
}

