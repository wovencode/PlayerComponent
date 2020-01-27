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
	   	// we simply fetch the table that is present on the local player object instead
	   	// of copy-pasting all the individual properties, update it and forward it to the db
	   	// -------------------------------------------------------------------------------
		[DevExtMethods("LoadDataPlayer")]
		void LoadDataPlayer_Player(GameObject player)
		{
	   		TablePlayer tablePlayer = FindWithQuery<TablePlayer>("SELECT * FROM "+nameof(TablePlayer)+" WHERE name=? AND deleted=0", player.name);
	   		player.GetComponent<PlayerComponent>().tablePlayer = tablePlayer;
		}
		
	   	// -------------------------------------------------------------------------------
	   	// SaveDataPlayer_Player
	   	// we simply fetch the table that is present on the local player object instead
	   	// of copy-pasting all the individual properties, update it and forward it to the db
	   	// -------------------------------------------------------------------------------
		[DevExtMethods("SaveDataPlayer")]
		void SaveDataPlayer_Player(GameObject player, bool isOnline)
		{
			// you should delete all data of this player first, to prevent duplicates
	   		DeleteDataPlayer_Player(player.name);
	   		
			player.GetComponent<PlayerComponent>().tablePlayer.Update(player, isOnline);
			InsertOrReplace(player.GetComponent<PlayerComponent>().tablePlayer);
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