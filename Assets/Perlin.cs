using UnityEngine;
using System.Collections;

public class Perlin : MonoBehaviour {
	public int pixWidth;
	public int pixHeight;
	private Texture2D noiseTex;
	private Color pix;
	private Renderer rend;
	float r;
	float g;
	float b;
	float a;
	void Start() {
		//pixWidth = pixHeight = 300;
		rend = GetComponent<Renderer>();
		noiseTex = new Texture2D(pixWidth, pixHeight);

		rend.material.mainTexture = noiseTex;
	}
	void CalcNoise() {
		for (int y = 0; y<noiseTex.height; y++){
			
			for (int x = 0; x<noiseTex.height; x++){
				/*
				r = Random.Range(0f, 1f);
				g = Random.Range(0f, 1f);
				b = Random.Range(0f, 1f);
				*/
				r=g=1f;
				b=0.2f;
				a=Mathf.PerlinNoise(Time.time,x*y);


				pix = new Color(r, g, b, a);
				noiseTex.SetPixel(x,y,pix);
			}
		}
	
		noiseTex.Apply();
	}
	void Update() {
		CalcNoise();
		rend.material.mainTexture = noiseTex;
	}
}