﻿
using Wovencode;
using Wovencode.Database;
using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using SQLite;

namespace Wovencode.Database
{
	
	// ===================================================================================
	// Database
	// ===================================================================================
	public partial class DatabaseManager
	{
		
		// -------------------------------------------------------------------------------
		// DeleteUsers_PlayerComponent
		// -------------------------------------------------------------------------------
		[DevExtMethods("DeleteUsers")]
		void DeleteUsers_PlayerComponent()
		{

			List<TableUser> users = Query<TableUser>("SELECT * FROM "+nameof(TableUser)+" WHERE deleted=1");

			foreach (TableUser user in users)
				this.InvokeInstanceDevExtMethods("DeleteDataUser", user.name);
			
			if (users.Count > 0)
				debug.Log("[DatabaseManager] Pruned " + users.Count + " inactive user(s)");

		}
		
		// -------------------------------------------------------------------------------

	}

}

// =======================================================================================