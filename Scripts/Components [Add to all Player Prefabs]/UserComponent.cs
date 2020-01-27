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
	// UserComponent
	// ===================================================================================
	[DisallowMultipleComponent]
	[System.Serializable]
	public partial class UserComponent : SyncableComponent
	{
		
		// holds exact replica of table data as in database
		// no need to sync, can be done individually if required
    	public TableUser tableUser = new TableUser();
    	
		// -------------------------------------------------------------------------------
		// 
		// -------------------------------------------------------------------------------
		protected override void Start()
    	{
        	
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
			
		}
		
		// -------------------------------------------------------------------------------
		// UpdateClient
		// -------------------------------------------------------------------------------
		[Client]
		protected override void UpdateClient()
		{
			
		}
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================