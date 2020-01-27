// =======================================================================================
// Wovencore
// by Weaver (Fhiz)
// MIT licensed
//
// =======================================================================================

using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Wovencode;
using Wovencode.Database;

namespace Wovencode {
	
	// ===================================================================================
	// PlayerComponent
	// ===================================================================================
	[DisallowMultipleComponent]
	[System.Serializable]
	public partial class PlayerComponent : EntityComponent
	{
	
		// holds exact replica of table data as in database
		// no need to sync, can be done individually if required
		public TablePlayer tablePlayer = new TablePlayer();
		
		Camera mainCamera;
		
		// -------------------------------------------------------------------------------
		// 
		// -------------------------------------------------------------------------------
		protected override void Start()
    	{
        	base.Start();
		}
		
		// -------------------------------------------------------------------------------
		// 
		// -------------------------------------------------------------------------------
		public override void OnStartLocalPlayer()
    	{
        	mainCamera = Camera.main;
        	mainCamera.GetComponent<FollowCameraControls>().target = this.transform;
        	mainCamera.GetComponent<FollowCameraControls>().enabled = true;
		}
		
		// -------------------------------------------------------------------------------
		// 
		// -------------------------------------------------------------------------------
		void OnDestroy()
    	{
    	
        }
		
		// -------------------------------------------------------------------------------
		// UpdateServer
		// -------------------------------------------------------------------------------
		[Server]
		protected override void UpdateServer()
		{
			base.UpdateServer();
			this.InvokeInstanceDevExtMethods(nameof(UpdateServer));
		}
		
		// -------------------------------------------------------------------------------
		// UpdateClient
		// -------------------------------------------------------------------------------
		[Client]
		protected override void UpdateClient()
		{
			base.UpdateClient();
			this.InvokeInstanceDevExtMethods(nameof(UpdateClient));
		}
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================