using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAOE : MonoBehaviour
{
	public Vector3 arenaCenter;
	public float arenaRadius;
	public int arrowsPerWave;
	public float timeBetweenWaves;
	public float timeToReact;
	public float AOERadius;
	public Transform arrow;
	public float arrowsStartingHeightOffset;
	public float arrowsVerticalRange;
	
	private bool isUsed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	GameObject DrawAOEIndicator(Vector3 center)
	{
		GameObject AOEIndicator = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
		AOEIndicator.transform.position = center;
		AOEIndicator.transform.localScale = new Vector3(2 * AOERadius, 0.001f, 2 * AOERadius);
		AOEIndicator.GetComponent<Collider>().isTrigger = true;
		Material AOEIndicatorMaterial = AOEIndicator.GetComponent<Renderer>().material;
		EnableMaterialTransparency(AOEIndicatorMaterial);
		AOEIndicatorMaterial.color = new Color(1.0f, 0.0f, 0.0f, 0.5f);
		return AOEIndicator;
	}
	
	void ShootArrows(Vector3 center)
	{
		
		for (int i = 0; i < arrowsPerWave; ++i)
		{
			float startingHeight = arrowsStartingHeightOffset + Random.Range(-arrowsVerticalRange, arrowsVerticalRange);
			Vector2 randomPos = Random.insideUnitCircle * AOERadius;
			Vector3 arrowPos = new Vector3(randomPos.x + center.x, startingHeight + center.y, randomPos.y + center.z);
			Instantiate(arrow, arrowPos, Quaternion.identity);
		}
	}
	
	IEnumerator NextWave() 
	{
		Vector2 randomPos = Random.insideUnitCircle * arenaRadius;
		Vector3 AOECenter = new Vector3(randomPos.x + arenaCenter.x, arenaCenter.y, randomPos.y + arenaCenter.z);
		GameObject AOEIndicator = DrawAOEIndicator(AOECenter);
		yield return new WaitForSeconds(timeToReact);
		ShootArrows(AOECenter);
		Destroy(AOEIndicator);
	}
	
	IEnumerator StartWaves() 
	{
		while(true)
		{
			StartCoroutine(NextWave());
			yield return new WaitForSeconds(timeBetweenWaves);
		}
	}
	
	private void OnTriggerEnter(Collider other)
    {
        if (!isUsed && other.gameObject.name == "Player") {
			StartCoroutine(StartWaves());
			isUsed = true;
		}
    }
	
	void EnableMaterialTransparency(Material material)
	{
		//wtf Unity???
		//all this shit to enable alpha channel
		material.SetOverrideTag("RenderType", "Transparent");
        material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
        material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        material.SetInt("_ZWrite", 0);
        material.DisableKeyword("_ALPHATEST_ON");
        material.DisableKeyword("_ALPHABLEND_ON");
        material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
        material.renderQueue = 3000;
	}
}
