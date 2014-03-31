using UnityEngine;
using System.Collections;

public class BlackScreenScript : MonoBehaviour {


	public Color color = new Color(0.3F, 0.4F, 0.6F);
	public void Start() {
		print(color.grayscale);
		StartCoroutine(ToHalfAlpha());
	}
	public void ToHalfAlphaFunction(){
		StartCoroutine(ToHalfAlpha());
	}
	public IEnumerator ToHalfAlpha () {
		
		float alpha = transform.renderer.material.color.a;
		
		while(alpha > 0) {
			
			alpha -= Time.deltaTime;
			print (alpha);
			Color newColor = new Color(0.3F, 0.4F, 0.6F, alpha);
			transform.renderer.material.color = newColor;
			StartCoroutine("ToHalfAlpha");
		}
		yield return null;
	}
}
