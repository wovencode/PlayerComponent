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
using SQLite;
using UnityEngine.AI;

namespace wovencode
{

	// ===================================================================================
	// DatabaseManager
	// ===================================================================================
	public partial class DatabaseManager
	{
		
		// ============================= PRIVATE METHODS =================================
		
		// -------------------------------------------------------------------------------
		// Init_Player
		// -------------------------------------------------------------------------------
		[DevExtMethods("Init")]
		void Init_Player()
		{
	   		CreateTable<TablePlayer>();
		}
		
	   	// -------------------------------------------------------------------------------
	   	// CreateDefaultData_Player
	   	// -------------------------------------------------------------------------------
	   	[DevExtMethods("CreateDefaultData")]
		void CreateDefaultData_Player(GameObject player)
		{
			
		}
		
		// -------------------------------------------------------------------------------
		// LoadDataWithPriority_Player
		// -------------------------------------------------------------------------------
		[DevExtMethods("LoadDataWithPriority")]
		void LoadDataWithPriority_Player(GameObject player)
		{
			
		}
		
	   	// -------------------------------------------------------------------------------
	   	// LoadData_Player
	   	// -------------------------------------------------------------------------------
		[DevExtMethods("LoadData")]
		void LoadData_Player(GameObject player)
		{
	   		
		}
		
	   	// -------------------------------------------------------------------------------
	   	// SaveData_Player
	   	// -------------------------------------------------------------------------------
		[DevExtMethods("SaveData")]
		void SaveData_Player(GameObject player)
		{
	   		Execute("UPDATE TablePlayer SET lastsaved=? WHERE name=?", DateTime.UtcNow, player.name);
		}
		
		// -------------------------------------------------------------------------------
	   	// DeleteData_Player
	   	// -------------------------------------------------------------------------------
	   	[DevExtMethods("DeleteData")]
	   	void DeleteData_Player(string name)
	   	{
	   		Execute("DELETE FROM TablePlayer WHERE name=?", name);
	   	}
		
		// ============================ PROTECTED METHODS ================================
		
		// -------------------------------------------------------------------------------
		// TryHardDeletePlayer
		// Permanently deletes the player and all of its data
		// -------------------------------------------------------------------------------
		protected bool TryHardDeletePlayer(string _name, string _password)
		{
		
			if (!Tools.IsAllowedName(_name) || !Tools.IsAllowedPassword(_password) || !PlayerExists(_name))
				return false;
			
			PlayerDelete(_name);
			return true;	
				
		}
		
		// -------------------------------------------------------------------------------
		// PlayerSetOnline
		// Sets the player online (1) or offline (0) and updates last login time
		// -------------------------------------------------------------------------------
		protected void PlayerSetOnline(string _name, int _action=1)
		{
			Execute("UPDATE TablePlayer SET online=?, lastlogin=? WHERE name=?", _action, DateTime.UtcNow, _name);
		}
		
		// -------------------------------------------------------------------------------
		// PlayerSetDeleted
		// Sets the player to deleted (1) or undeletes it (0)
		// -------------------------------------------------------------------------------
		protected void PlayerSetDeleted(string _name, int _action=1)
		{
			Execute("UPDATE TablePlayer SET deleted=? WHERE name=?", _action, _name);
		}
		
		// -------------------------------------------------------------------------------
		// PlayerSetBanned
		// Bans (1) or unbans (0) the user
		// -------------------------------------------------------------------------------
		protected void PlayerSetBanned(string _name, int _action=1)
		{
			Execute("UPDATE TablePlayer SET banned=? WHERE name=?", _action, _name);
		}
		
		// -------------------------------------------------------------------------------
		// PlayerDelete
		// Permanently deletes the player and all of its data (hard delete)
		// -------------------------------------------------------------------------------
		protected void PlayerDelete(string _name)
		{			
			this.InvokeInstanceDevExtMethods("DeleteData", _name);
		}
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================