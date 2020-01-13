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
using wovencode;

namespace wovencode {
	
	// ===================================================================================
	// EntityComponent
	// ===================================================================================
	[System.Serializable]
	public abstract partial class EntityComponent : UpgradableComponent
	{
	
		// -------------------------------------------------------------------------------
		// 
		// -------------------------------------------------------------------------------
		protected override void Start()
    	{
        	base.Start();
		}
		
		// -------------------------------------------------------------------------------
		// UpdateServer
		// -------------------------------------------------------------------------------
		[Server]
		protected override void UpdateServer()
		{
			this.InvokeInstanceDevExtMethods(nameof(UpdateServer));
		}
		
		// -------------------------------------------------------------------------------
		// UpdateClient
		// -------------------------------------------------------------------------------
		[Client]
		protected override void UpdateClient()
		{
			this.InvokeInstanceDevExtMethods(nameof(UpdateClient));
		}
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================