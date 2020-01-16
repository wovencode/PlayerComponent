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
		protected void UserRegister(string name, string password)
		{
			Insert(new TableUser{ name=name, password=password, created=DateTime.UtcNow, lastlogin=DateTime.Now, banned=false});
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
		// GetPlayerCount
		// -------------------------------------------------------------------------------
		protected int GetPlayerCount(string username)
		{
			return Query<TablePlayer>("SELECT * FROM TablePlayer WHERE username=? AND deleted=0", username).Count;
		}
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================