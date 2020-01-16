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
		// 
		// -------------------------------------------------------------------------------
		public override bool TryPlayerLogin(string name, string username)
		{
			
			if (!base.TryPlayerLogin(name, username) || !UserValid(name, username))
				return false;
			
			LoginPlayer(name);
			return true;
			
		}
		
		// -------------------------------------------------------------------------------
		// 
		// -------------------------------------------------------------------------------
		public override bool TryPlayerRegister(string name, string username)
		{
		
			if (!base.TryPlayerRegister(name, username) || UserExists(name))
				return false;
			
			// -- check if maximum amount of characters per account reached
#if wNETWORK
			if (GetPlayerCount(username) >= GameRulesTemplate.singleton.maxPlayersPerUser)
				return false;
#endif

			PlayerRegister(name, username);
			return true;
			
		}
		
		// -------------------------------------------------------------------------------
		// 
		// -------------------------------------------------------------------------------
		public override bool TryPlayerDeleteSoft(string name, string username, int _action=1)
		{
		
			if (!base.TryPlayerDeleteSoft(name, username) || !UserValid(name, username))
				return false;
				
			PlayerSetDeleted(name, _action);
			return true;	
			
		}
		
		// -------------------------------------------------------------------------------
		// 
		// Permanently deletes the player and all of its data
		// -------------------------------------------------------------------------------
		public override bool TryPlayerDeleteHard(string _name)
		{
		
			if (!base.TryPlayerDeleteHard(_name) || !PlayerExists(_name))
				return false;
			
			PlayerDelete(_name);
			return true;	
				
		}
		
		// -------------------------------------------------------------------------------
		// 
		// -------------------------------------------------------------------------------
		public override bool TryPlayerBan(string name, string username, int _action=1)
		{
			
			if (!base.TryPlayerBan(name, username) || !UserValid(name, username))
				return false;
				
			PlayerSetBanned(name, _action);
			return true;	
			
		}
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================