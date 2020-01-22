// =======================================================================================
// Wovencore
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using Wovencode;
using Wovencode.Database;
#if wNETWORK
using Wovencode.Network;
#endif
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Wovencode.Database
{

	// ===================================================================================
	// DatabaseManager
	// ===================================================================================
	public partial class DatabaseManager
	{
				
		// ============================== PUBLIC METHODS =================================
		
		// -------------------------------------------------------------------------------
		// TryPlayerLogin
		// -------------------------------------------------------------------------------
		public override bool TryPlayerLogin(string name, string username)
		{
			
			if (!base.TryPlayerLogin(name, username) || !PlayerValid(name, username))
				return false;
			
			LoginPlayer(name);
			return true;
			
		}
		
		// -------------------------------------------------------------------------------
		// TryPlayerRegister
		// -------------------------------------------------------------------------------
		public override bool TryPlayerRegister(string name, string username)
		{
		
			if (!base.TryPlayerRegister(name, username) || PlayerExists(name, username))
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
		// TryPlayerDeleteSoft
		// -------------------------------------------------------------------------------
		public override bool TryPlayerDeleteSoft(string name, string username, int _action=1)
		{
		
			if (!base.TryPlayerDeleteSoft(name, username) || !PlayerValid(name, username))
				return false;
				
			PlayerSetDeleted(name, _action);
			return true;	
			
		}
		
		// -------------------------------------------------------------------------------
		// TryPlayerDeleteHard
		// Permanently deletes the player and all of its data
		// -------------------------------------------------------------------------------
		public override bool TryPlayerDeleteHard(string name, string username)
		{
		
			if (!base.TryPlayerDeleteHard(name, username) || !PlayerExists(name, username))
				return false;
			
			DeleteDataPlayer(name);
			return true;	
				
		}
		
		// -------------------------------------------------------------------------------
		// TryPlayerBan
		// -------------------------------------------------------------------------------
		public override bool TryPlayerBan(string name, string username, int _action=1)
		{
			
			if (!base.TryPlayerBan(name, username) || !PlayerValid(name, username))
				return false;
				
			PlayerSetBanned(name, _action);
			return true;	
			
		}
		
		// ===============================================================================
		
		// -------------------------------------------------------------------------------
		// GetPlayers
		// -------------------------------------------------------------------------------
		public List<PlayerPreview> GetPlayers(string username)
		{
			List<TablePlayer> results = Query<TablePlayer>("SELECT * FROM "+nameof(TablePlayer)+" WHERE username=? AND deleted=0 AND banned=0", username);
			
			List<PlayerPreview> players = new List<PlayerPreview>();
			
			foreach (TablePlayer result in results)
				players.Add(new PlayerPreview { name = result.name} );
			
			return players;
		}
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================