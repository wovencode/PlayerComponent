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
using UnityEngine.AI;

namespace Wovencode.Database
{

	// ===================================================================================
	// DatabaseManager
	// ===================================================================================
	public partial class DatabaseManager
	{
		
		// ============================ PROTECTED METHODS ================================
		
		// -------------------------------------------------------------------------------
		// UserValid
		// -------------------------------------------------------------------------------
		protected bool UserValid(string name, string password)
		{
			return FindWithQuery<TableUser>("SELECT * FROM TableUser WHERE name=? AND password=? AND banned=0 AND deleted=0", name, password) != null;
		}
		
		// -------------------------------------------------------------------------------
		// UserExists
		// -------------------------------------------------------------------------------
		protected bool UserExists(string name)
		{
			return FindWithQuery<TableUser>("SELECT * FROM TableUser WHERE name=?", name) != null;
		}
		
		// -------------------------------------------------------------------------------
		// UserRegister
		// -------------------------------------------------------------------------------
		protected void UserRegister(string name, string password, string email, string deviceid)
		{
			Insert(new TableUser{ name=name, password=password, email=email, deviceid=deviceid, created=DateTime.UtcNow, lastlogin=DateTime.Now, banned=false});
		}
		
		// -------------------------------------------------------------------------------
		// UserChangePassword
		// -------------------------------------------------------------------------------
		protected void UserChangePassword(string name, string oldpassword, string newpassword)
		{
			Execute("UPDATE TableUser SET password=? WHERE name=? AND password=?", newpassword, name, oldpassword);
		}
		
		// -------------------------------------------------------------------------------
		// UserSetOnline
		// Sets the user online (1) or offline (0) and updates last login time
		// -------------------------------------------------------------------------------
		protected void UserSetOnline(string name, int action=1)
		{
			Execute("UPDATE TableUser SET online=?, lastlogin=? WHERE name=?", action, DateTime.UtcNow, name);
		}
		
		// -------------------------------------------------------------------------------
		// UserSetDeleted
		// Sets the user to deleted (1) or undeletes it (0)
		// -------------------------------------------------------------------------------
		protected void UserSetDeleted(string name, int action=1)
		{
			Execute("UPDATE TableUser SET deleted=? WHERE name=?", action, name);
		}
		
		// -------------------------------------------------------------------------------
		// UserSetBanned
		// Bans (1) or unbans (0) the user
		// -------------------------------------------------------------------------------
		protected void UserSetBanned(string name, int action=1)
		{
			Execute("UPDATE TableUser SET banned=? WHERE name=?", action, name);
		}
		
		// -------------------------------------------------------------------------------
		// UserDelete
		// Permanently deletes the user and all of its data (hard delete)
		// -------------------------------------------------------------------------------
		protected void UserDelete(string name)
		{			
			this.InvokeInstanceDevExtMethods("DeleteData", name);
			this.InvokeInstanceDevExtMethods(nameof(UserDelete), name);
		}
		
		// -------------------------------------------------------------------------------
		// UserSetConfirmed
		// Sets the user to confirmed (1) or unconfirms it (0)
		// -------------------------------------------------------------------------------
		protected void UserSetConfirmed(string name, int action=1)
		{
			Execute("UPDATE TableUser SET confirmed=? WHERE name=?", action, name);
		}
		
		// -------------------------------------------------------------------------------
		// GetPlayerCount
		// -------------------------------------------------------------------------------
		protected int GetPlayerCount(string username)
		{
			List<TablePlayer> result =  Query<TablePlayer>("SELECT * FROM TablePlayer WHERE username=? AND deleted=0", username);
			
			if (result == null)
				return 0;
			else
				return result.Count;
		}
		
		// -------------------------------------------------------------------------------
		// GetUserCount
		// -------------------------------------------------------------------------------
		protected int GetUserCount(string deviceid, string email)
		{

			List<TableUser> result = Query<TableUser>("SELECT * FROM TableUser WHERE deviceid=? AND email=? AND deleted=0", deviceid, email);
			
			if (result == null)
				return 0;
			else
				return result.Count;

		}
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================