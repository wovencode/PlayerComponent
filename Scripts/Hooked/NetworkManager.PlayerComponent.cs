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