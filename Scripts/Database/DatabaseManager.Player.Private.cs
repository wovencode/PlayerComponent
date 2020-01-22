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
	   	// CreateDefaultDataPlayer_Player
	   	// -------------------------------------------------------------------------------
	   	[DevExtMethods("CreateDefaultDataPlayer")]
		void CreateDefaultDataPlayer_Player(GameObject player)
		{
			
		}
		
		// -------------------------------------------------------------------------------
		// LoadDataPlayerPriority_Player
		// -------------------------------------------------------------------------------
		[DevExtMethods("LoadDataPlayerPriority")]
		void LoadDataPlayerPriority_Player(GameObject player)
		{
			
		}
		
	   	// -------------------------------------------------------------------------------
	   	// LoadDataPlayer_Player
	   	// -------------------------------------------------------------------------------
		[DevExtMethods("LoadDataPlayer")]
		void LoadDataPlayer_Player(GameObject player)
		{
	   		
		}
		
	   	// -------------------------------------------------------------------------------
	   	// SaveDataPlayer_Player
	   	// -------------------------------------------------------------------------------
		[DevExtMethods("SaveDataPlayer")]
		void SaveDataPlayer_Player(GameObject player, bool isOnline)
		{
	   		Execute("UPDATE "+nameof(TablePlayer)+" SET lastsaved=? WHERE name=?", DateTime.UtcNow, player.name);
		}
		
		// -------------------------------------------------------------------------------
	   	// LoginPlayer_Player
	   	// -------------------------------------------------------------------------------
	   	[DevExtMethods("LoginPlayer")]
	   	void LoginPlayer_Player(string name)
	   	{
	   		PlayerSetOnline(name, 1);
	   	}
		
		// -------------------------------------------------------------------------------
	   	// LogoutPlayer_Player
	   	// -------------------------------------------------------------------------------
	   	[DevExtMethods("LogoutPlayer")]
	   	void LogoutPlayer_Player(string name)
	   	{
	   		PlayerSetOnline(name, 0);
	   	}
		
		// -------------------------------------------------------------------------------
	   	// DeleteDataPlayer_Player
	   	// -------------------------------------------------------------------------------
	   	[DevExtMethods("DeleteDataPlayer")]
	   	void DeleteDataPlayer_Player(string name)
	   	{
	   		Execute("DELETE FROM "+nameof(TablePlayer)+" WHERE name=?", name);
	   	}
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================