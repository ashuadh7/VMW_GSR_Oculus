using UnityEngine;
using System.Collections;

public class HeadFollower : MonoBehaviour
{

	private Transform		m_ThingToFollow;
	private Transform		m_Self;
	
	void Start()
	{
		m_ThingToFollow = GameObject.Find( "Head" ).transform;
		m_Self = transform;
		m_Self.position = new Vector3( m_ThingToFollow.position.x, m_Self.position.y, m_ThingToFollow.position.z );
	}
	
	void Update()
	{
		m_Self.position = new Vector3( m_ThingToFollow.position.x, m_Self.position.y, m_ThingToFollow.position.z );
	}
}
