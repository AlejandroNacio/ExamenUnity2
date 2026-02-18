using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
	 public int puntos = 0;
	 public TMP_Text textoPuntos;

	 public void SumarPuntos()
	 {
		 puntos += 1;
		 ActualizarUI();
	 }

	 void ActualizarUI()
	 {
		if (textoPuntos != null)
		{
			textoPuntos.text = puntos.ToString();
		}
	 }
}

