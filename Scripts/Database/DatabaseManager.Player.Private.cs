// =======================================================================================
// Wovencore
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using Wovencode;
using Wovencode.Database;
using UnityEngine;
using System;
//using System.IO;
using System.Collections.Generic;
using SQLite;
//using UnityEngine.AI;

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
	   	// DeleteData_Player
	   	// -------------------------------------------------------------------------------
	   	[DevExtMethods("DeleteData")]
	   	void DeleteData_Player(string name)
	   	{
	   		Execute("DELETE FROM TablePlayer WHERE name=?", name);
	   	}
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================