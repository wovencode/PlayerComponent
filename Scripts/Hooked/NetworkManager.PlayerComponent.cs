// =======================================================================================
// Wovencore
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using Wovencode;
using Wovencode.Network;
using Wovencode.Database;
using Wovencode.UI;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
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