using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

	public class Jugador : MonoBehaviour
	{
		[Header("Movimiento")]
		private float movimientoX;
		public float velocidad = 2;
		private Rigidbody2D rb2d;

		[Header("************ Salto ************")]
		public float fuerzaSalto = 2;

		[Header("******* CompruebaSuelo *******")]
		private bool estaEnSuelo = false;
		public LayerMask layerSuelo;
		private float radioEsferaTocaSuelo = 0.1f;
		public Transform compruebaSuelo;

		[Header("******Sonido****")]
		 public AudioSource audioSource;
		 public AudioClip clipZanahoria;
		
		void Start()
		{
			rb2d = GetComponent<Rigidbody2D>();
		}	
		
		 void FixedUpdate()
		 {
			 estaEnSuelo = Physics2D.OverlapCircle(compruebaSuelo.position, radioEsferaTocaSuelo, layerSuelo);
		 }

		 private void OnTriggerEnter2D(Collider2D collision)
		{
			 if (collision.transform.CompareTag("Zanahoria"))
			{
				FindObjectOfType<GameManager>().SumarPuntos();
				Destroy(collision.gameObject);
				audioSource.PlayOneShot(clipZanahoria);
			}

			if (collision.transform.CompareTag("SueloMuerte") || collision.transform.CompareTag("Enemigo"))
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}

			if (collision.transform.CompareTag("Estrella"))
			 {
			 
			 }

			if (collision.transform.CompareTag("Casa"))
			 {
			 SceneManager.LoadScene("Victoria");
			 }
		}

			
		void Update()
		{
		 
		 rb2d.linearVelocity = new Vector2(movimientoX * velocidad, rb2d.linearVelocity.y);		

		}
		
		private void OnMove(InputValue inputMovimiento)
		{
			movimientoX = inputMovimiento.Get<Vector2>().x;

			if (movimientoX != 0)
			{
				transform.localScale = new Vector3(Mathf.Sign(movimientoX), 1, 1);
			}
		}
		
		private void OnJump(InputValue inputSalto)
		{
			if (estaEnSuelo)
			{
				rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, fuerzaSalto);
			}
		}
	}
