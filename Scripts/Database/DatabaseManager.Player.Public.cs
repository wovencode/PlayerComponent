// =======================================================================================
// Wovencore
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using wovencode;
using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;

namespace wovencode
{

	// ===================================================================================
	// DatabaseManager
	// ===================================================================================
	public partial class DatabaseManager
	{
				
		// ============================== PUBLIC METHODS =================================
		
		// -------------------------------------------------------------------------------
		// TryLoginPlayer
		// -------------------------------------------------------------------------------
		public override bool TryLoginPlayer(string name, string username)
		{
			
			if (!base.TryLoginPlayer(name, username) || !UserValid(name, username))
				return false;
			
			PlayerSetOnline(name);
			return true;
			
		}
		
		// -------------------------------------------------------------------------------
		// TryRegisterPlayer
		// -------------------------------------------------------------------------------
		public override bool TryRegisterPlayer(string name, string username)
		{
		
			if (!base.TryRegisterPlayer(name, username) || UserExists(name))
				return false;
			
			// -- check if maximum amount of characters per account reached
#if wNETWORK
			if (GetPlayerCount(username) >= GameRulesTemplate.singleton.maxPlayersPerUser)
				return false;
#endif

			PlayerCreate(name, username);
			return true;
			
		}
		
		// -------------------------------------------------------------------------------
		// TrySoftDeletePlayer
		// -------------------------------------------------------------------------------
		public override bool TrySoftDeletePlayer(string name, string username, int _action=1)
		{
		
			if (!base.TrySoftDeletePlayer(name, username) || !UserValid(name, username))
				return false;
				
			PlayerSetDeleted(name, _action);
			return true;	
			
		}
		
		// -------------------------------------------------------------------------------
		// TryBanPlayer
		// -------------------------------------------------------------------------------
		public override bool TryBanPlayer(string name, string username, int _action=1)
		{
			
			if (!base.TryBanUser(name, username) || !UserValid(name, username))
				return false;
				
			PlayerSetBanned(name, _action);
			return true;	
			
		}
		
		// -------------------------------------------------------------------------------
		// GetPlayerCount
		// -------------------------------------------------------------------------------
		public int GetPlayerCount(string username)
		{
			return Query<TablePlayer>("SELECT * FROM TablePlayer WHERE username=? AND deleted=0", username).Count;
		}
		
		// -------------------------------------------------------------------------------
		// PlayerCreate
		// -------------------------------------------------------------------------------
		public void PlayerCreate(string name, string username)
		{
			Insert(new TablePlayer{ name=name, username=username, created=DateTime.UtcNow, lastlogin=DateTime.Now, banned=false});
		}
		
		// -------------------------------------------------------------------------------
		// PlayerValid
		// -------------------------------------------------------------------------------
		public bool PlayerValid(string name, string username)
		{
			return FindWithQuery<TablePlayer>("SELECT * FROM TablePlayer WHERE name=? AND username=? AND banned=0 AND deleted=0", name, username) != null;
		}
		
		// -------------------------------------------------------------------------------
		// PlayerExists
		// -------------------------------------------------------------------------------
		public bool PlayerExists(string name)
		{
			return FindWithQuery<TablePlayer>("SELECT * FROM TablePlayer WHERE name=?", name) != null;
		}
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================