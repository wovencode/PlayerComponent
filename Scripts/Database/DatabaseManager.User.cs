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
		// Init_User
		// -------------------------------------------------------------------------------
		[DevExtMethods("Init")]
		void Init_User()
		{
	   		CreateTable<TableUser>();
		}
		
	   	// -------------------------------------------------------------------------------
	   	// CreateDefaultData_User
	   	// -------------------------------------------------------------------------------
	   	[DevExtMethods("CreateDefaultData")]
		void CreateDefaultData_User(GameObject player)
		{
			/*
				users have no default data, feel free to add your own
				
				instead, user data is saved/loaded as part of the register/login process
			*/
		}
		
		// -------------------------------------------------------------------------------
		// LoadDataWithPriority_User
		// -------------------------------------------------------------------------------
		[DevExtMethods("LoadDataWithPriority")]
		void LoadDataWithPriority_User(GameObject player)
		{
			/*
				users do not load priority data, feel free to add your own
				
				instead, user data is saved/loaded as part of the register/login process
			*/
		}
		
	   	// -------------------------------------------------------------------------------
	   	// LoadData_User
	   	// -------------------------------------------------------------------------------
		[DevExtMethods("LoadData")]
		void LoadData_User(GameObject player)
		{
	   		/*
				users do not load any data, feel free to add your own
				
				instead, user data is saved/loaded as part of the register/login process
			*/
		}
		
	   	// -------------------------------------------------------------------------------
	   	// SaveData_User
	   	// -------------------------------------------------------------------------------
		[DevExtMethods("SaveData")]
		void SaveData_User(GameObject player)
		{
			PlayerComponent playerComponent = player.GetComponent<PlayerComponent>();
	   		Execute("UPDATE TableUser SET lastsaved=? WHERE name=?", DateTime.UtcNow, playerComponent.username);
		}
		
		// -------------------------------------------------------------------------------
	   	// UserDelete_User
	   	// Note: This one is not called "DeleteData" because its the user, not a player
	   	// -------------------------------------------------------------------------------
	   	[DevExtMethods("UserDelete")]
	   	void UserDelete_User(string _name)
	   	{
	   		Execute("DELETE FROM TableUser WHERE name=?", _name);
	   	}
		
		// ============================ PROTECTED METHODS ================================
		
		// -------------------------------------------------------------------------------
		// TryHardDeleteUser
		// Permanently deletes the user and all of its data (including players)
		// -------------------------------------------------------------------------------
		protected bool TryHardDeleteUser(string _name, string _password)
		{
		
			if (!Tools.IsAllowedName(_name) || !Tools.IsAllowedPassword(_password) || !UserExists(_name))
				return false;
			
			UserDelete(_name);
			return true;	
				
		}
		
		// -------------------------------------------------------------------------------
		// UserSetOnline
		// Sets the user online (1) or offline (0) and updates last login time
		// -------------------------------------------------------------------------------
		protected void UserSetOnline(string _name, int _action=1)
		{
			Execute("UPDATE TableUser SET online=?, lastlogin=? WHERE name=?", _action, DateTime.UtcNow, _name);
		}
		
		// -------------------------------------------------------------------------------
		// UserSetDeleted
		// Sets the user to deleted (1) or undeletes it (0)
		// -------------------------------------------------------------------------------
		protected void UserSetDeleted(string _name, int _action=1)
		{
			Execute("UPDATE TableUser SET deleted=? WHERE name=?", _action, _name);
		}
		
		// -------------------------------------------------------------------------------
		// UserSetBanned
		// Bans (1) or unbans (0) the user
		// -------------------------------------------------------------------------------
		protected void UserSetBanned(string _name, int _action=1)
		{
			Execute("UPDATE TableUser SET banned=? WHERE name=?", _action, _name);
		}
		
		// -------------------------------------------------------------------------------
		// UserDelete
		// Permanently deletes the user and all of its data (hard delete)
		// -------------------------------------------------------------------------------
		protected void UserDelete(string _name)
		{			
			this.InvokeInstanceDevExtMethods("DeleteData", _name);
			this.InvokeInstanceDevExtMethods(nameof(UserDelete), _name);
		}
		
		// -------------------------------------------------------------------------------
		// UserSetConfirmed
		// Sets the user to confirmed (1) or unconfirms it (0)
		// -------------------------------------------------------------------------------
		protected void UserSetConfirmed(string _name, int _action=1)
		{
			Execute("UPDATE TableUser SET confirmed=? WHERE name=?", _action, _name);
		}
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================