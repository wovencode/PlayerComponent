// =======================================================================================
// Wovencore
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using Wovencode;
using Wovencode.Database;
using UnityEngine;
using System;
using System.Collections.Generic;
using SQLite;

namespace Wovencode.Database
{

	// ===================================================================================
	// DatabaseManager
	// ===================================================================================
	public partial class DatabaseManager
	{
		
		// ============================ PROTECTED METHODS ================================
		
		// -------------------------------------------------------------------------------
		// PlayerSetOnline
		// Sets the player online (1) or offline (0) and updates last login time
		// -------------------------------------------------------------------------------
		protected void PlayerSetOnline(string _name, int action=1)
		{
			Execute("UPDATE "+nameof(TablePlayer)+" SET online=?, lastlogin=? WHERE name=?", action, DateTime.UtcNow, _name);
		}
		
		// -------------------------------------------------------------------------------
		// PlayerSetDeleted
		// Sets the player to deleted (1) or undeletes it (0)
		// -------------------------------------------------------------------------------
		protected void PlayerSetDeleted(string _name, int action=1)
		{
			Execute("UPDATE "+nameof(TablePlayer)+" SET deleted=? WHERE name=?", action, _name);
		}
		
		// -------------------------------------------------------------------------------
		// PlayerSetBanned
		// Bans (1) or unbans (0) the user
		// -------------------------------------------------------------------------------
		protected void PlayerSetBanned(string _name, int action=1)
		{
			Execute("UPDATE "+nameof(TablePlayer)+" SET banned=? WHERE name=?", action, _name);
		}
		
		// -------------------------------------------------------------------------------
		// DeleteDataPlayer
		// Permanently deletes the player and all of its data (hard delete)
		// -------------------------------------------------------------------------------
		protected void DeleteDataPlayer(string _name)
		{			
			this.InvokeInstanceDevExtMethods(nameof(DeleteDataPlayer), _name);
		}
		
		// -------------------------------------------------------------------------------
		// 
		// -------------------------------------------------------------------------------
		public void PlayerRegister(string name, string username)
		{
			Insert(new TablePlayer{ name=name, username=username, created=DateTime.UtcNow, lastlogin=DateTime.Now, banned=false});
		}
		
		// -------------------------------------------------------------------------------
		// 
		// -------------------------------------------------------------------------------
		public bool PlayerValid(string name, string username)
		{
			return FindWithQuery<TablePlayer>("SELECT * FROM "+nameof(TablePlayer)+" WHERE name=? AND username=? AND banned=0 AND deleted=0", name, username) != null;
		}
		
		// -------------------------------------------------------------------------------
		// 
		// -------------------------------------------------------------------------------
		public bool PlayerExists(string name, string username)
		{
			return FindWithQuery<TablePlayer>("SELECT * FROM "+nameof(TablePlayer)+" WHERE name=? AND username=?", name, username) != null;
		}
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================