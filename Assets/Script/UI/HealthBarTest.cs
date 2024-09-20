using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ACF.Tests
{
	// [ExecuteAlways]
	[RequireComponent(typeof(Image))]
	public class HealthBarTest : MonoBehaviour
	{
		private const string STEP = "_Steps";
		private const string RATIO = "_HSRatio";
		private const string WIDTH = "_Width";
		private const string THICKNESS = "_Thickness";
		
		private static readonly int floatSteps = Shader.PropertyToID(STEP);
		private static readonly int floatRatio = Shader.PropertyToID(RATIO);
		private static readonly int floatWidth = Shader.PropertyToID(WIDTH);
		private static readonly int floatThickness = Shader.PropertyToID(THICKNESS);
		
		[Range(0, 2800f)] public float Hp = 5;
		[Range(0, 2800f)] public float MaxHp = 5;
		[Range(0, 920f)] public float Sp = 0f;
		[Range(0, 10f)] public float speed = 3f;
		
		public float hpShieldRatio = 1.13f;
		public float RectWidth = 100f;
		public float Thickness;
		
		public Image hp;
		public Image damaged;
		public Image sp;
		public Image separator;

		private GameObject enemy;

		[ContextMenu("Create Material")]
		private void CreateMaterial()
		{
			// if (separator.material == null)
			{
				separator.material = new Material(Shader.Find("ABS/UI/Health Separator"));
			}
		}

        private void Start()
        {
			enemy = transform.parent.gameObject.transform.parent.gameObject;
			Thickness = enemy.GetComponent<Enemy_Skel>().HP;
		}
        /*private IEnumerator Start()
		{
			yield return new WaitForSeconds(2.0f);

			Hp = 5;
			MaxHp = 5;
			Sp = 400;

			while (Sp > 0)
			{
				Sp -= 280 * Time.deltaTime;
				yield return null;
			}

			Sp = 0;

			yield return new WaitForSeconds(2f);

			for (int i = 0; i < 8; i++)
			{
				Hp -= 120;
				yield return new WaitForSeconds(1f);
			}
			
			for (int i = 0; i < 8; i++)
			{
				MaxHp += 200;
				Hp = MaxHp;
				
				yield return new WaitForSeconds(1f);
			}
			
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#endif
		}*/


        private void Update()
		{
			float step;

			// 쉴드가 존재 할 때
			step = MaxHp / 1;

			// sp.fillAmount = 1 - hpShieldRatio;

			damaged.fillAmount = Mathf.Lerp(damaged.fillAmount, hp.fillAmount, Time.deltaTime * speed);
			
			separator.material.SetFloat(floatSteps, step);
			separator.material.SetFloat(floatRatio, hpShieldRatio);
			separator.material.SetFloat(floatWidth, RectWidth);
			separator.material.SetFloat(floatThickness, Thickness);
		}
	}
}