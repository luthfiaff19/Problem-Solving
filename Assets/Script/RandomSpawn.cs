using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
	public Transform[] Positions;
	public GameObject Object;

	public Transform Location;

	public bool ToSpawn = true;

	// Pembaruan akan dipanggil satu-persatu
	void Update()
	{
		Location = Positions[Random.Range(0, Positions.Length)];

		if (ToSpawn == true)
		{
			Instantiate(Object, Location);
			ToSpawn = false;
			StartCoroutine(ToSpawnTrue());
		}
	}

	// Setel acak posisi titik saat di run
	IEnumerator ToSpawnTrue()
	{
		yield return new WaitForSeconds(0.75f);
		ToSpawn = true;
	}
}