// =======================================================================================
// Wovencore
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using Wovencode;
using Wovencode.Network;
using Wovencode.Database;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Mirror;

namespace Wovencode.Network
{

    // ===================================================================================
	// NetworkManager
	// ===================================================================================
	public partial class NetworkManager
	{
				
		protected List<GameObject> _playerPrefabs = null;
		
		// -------------------------------------------------------------------------------
		// LoginPlayer_PlayerComponent
		// -------------------------------------------------------------------------------
		[DevExtMethods("LoginPlayer")]
		public void LoginPlayer_PlayerComponent(GameObject player, string userName)
		{
			player.GetComponent<PlayerComponent>().tablePlayer.Update(player, true, userName);
		}
		
		// -------------------------------------------------------------------------------
		// RegisterPlayer_PlayerComponent
		// -------------------------------------------------------------------------------
		[DevExtMethods("RegisterPlayer")]
		public void RegisterPlayer_PlayerComponent(GameObject player, string userName, string prefabName)
		{
			player.transform.position = GetStartPosition(player).position;
			player.GetComponent<PlayerComponent>().tablePlayer.Create(player, userName, prefabName);
		}
		
		// ================================== PUBLIC =====================================
		
		// -------------------------------------------------------------------------------
		// playerPrefabs
		// -------------------------------------------------------------------------------
		public List<GameObject> playerPrefabs
		{
			get
			{
				if (_playerPrefabs == null)
					FilterPlayerPrefabs();
				return _playerPrefabs;
			}
		}

		// ================================== PROTECTED ==================================
		
		// -------------------------------------------------------------------------------
		// GetStartPosition
		// -------------------------------------------------------------------------------
		protected Transform GetStartPosition(GameObject player)
		{
			
			//TODO: Add start position randomization here
			
			foreach (Transform startPosition in startPositions)
			{
			
				Wovencode.Network.NetworkStartPosition position = startPosition.GetComponent<Wovencode.Network.NetworkStartPosition>();
				
				if (position == null || position.archeTypes.Length == 0)
					continue;
				
				PlayerComponent playerComponent = player.GetComponent<PlayerComponent>();
				
				foreach (ArchetypeTemplate template in position.archeTypes)
					if (template == playerComponent.archeType)
						return position.transform;
						
			}
			
			return GetStartPosition();
		
		}
		
		// -------------------------------------------------------------------------------
		// ValidatePlayerPosition
		// -------------------------------------------------------------------------------
		protected void ValidatePlayerPosition(GameObject player)
		{
			Transform transform = player.transform;
			
			if (!NavMesh.SamplePosition(player.transform.position, out NavMeshHit hit, 0.1f, NavMesh.AllAreas))
				transform = GetStartPosition(player);
				
			player.GetComponent<NavMeshAgent>().Warp(transform.position);
			
		}
		
		// -------------------------------------------------------------------------------
		// GetPlayerPrefab
		// -------------------------------------------------------------------------------
		protected override GameObject GetPlayerPrefab(string prefabName)
		{
			
			GameObject prefab = playerPrefabs.Find(p => p.name == prefabName);

			if (prefab == null)
				return playerPrefab;
			
			return prefab;
			
		}
		
		// -------------------------------------------------------------------------------
		// FilterPlayerPrefabs
		// -------------------------------------------------------------------------------
		protected void FilterPlayerPrefabs()
    	{
       		
       		_playerPrefabs = new List<GameObject>();
        	
        	foreach (GameObject prefab in spawnPrefabs)
        	{
            	PlayerComponent player = prefab.GetComponent<PlayerComponent>();
            	if (player != null)
               		_playerPrefabs.Add(prefab);
        	}
        	
    	}
    	
		// -------------------------------------------------------------------------------

	}

}

// =======================================================================================