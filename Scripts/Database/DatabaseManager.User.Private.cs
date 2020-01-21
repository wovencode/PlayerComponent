// =======================================================================================
// Wovencore
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using Wovencode;
using Wovencode.Database;
using UnityEngine;
using System;
using System.IO;
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
	   	// SaveDataUser_User
	   	// -------------------------------------------------------------------------------
		[DevExtMethods("SaveDataUser")]
		void SaveDataUser_User(string username, bool isOnline)
		{
	   		Execute("UPDATE TableUser SET lastsaved=?, online=? WHERE name=?", DateTime.UtcNow, (isOnline) ? 1 : 0, username);
		}
		
		// -------------------------------------------------------------------------------
	   	// LoginUser_User
	   	// -------------------------------------------------------------------------------
	   	[DevExtMethods("LoginUser")]
	   	void LoginUser_User(string username)
	   	{
	   		UserSetOnline(username, 1);
	   	}
		
		// -------------------------------------------------------------------------------
	   	// LogoutUser_User
	   	// -------------------------------------------------------------------------------
	   	[DevExtMethods("LogoutUser")]
	   	void LogoutUser_User(string username)
	   	{
	   		UserSetOnline(username, 0);
	   	}
		
		// -------------------------------------------------------------------------------
	   	// UserDelete_User
	   	// Note: This one is not called "DeleteData" because its the user, not a player
	   	// -------------------------------------------------------------------------------
	   	[DevExtMethods("UserDelete")]
	   	void UserDelete_User(string name)
	   	{
	   		Execute("DELETE FROM TableUser WHERE name=?", name);
	   	}
	   	
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================