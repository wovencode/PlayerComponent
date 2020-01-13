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

namespace wovencode
{

	// ===================================================================================
	// DatabaseManager
	// ===================================================================================
	public partial class DatabaseManager
	{
				
		// ============================== PUBLIC METHODS =================================
		
		// -------------------------------------------------------------------------------
		// TryLoginUser
		// -------------------------------------------------------------------------------
		public override bool TryLoginUser(string name, string password)
		{
		
			if (!base.TryLoginUser(name, password) || !UserValid(name, password))
				return false;
			
			UserSetOnline(name);
			return true;
			
		}
		
		// -------------------------------------------------------------------------------
		// TryRegisterUser
		// -------------------------------------------------------------------------------
		public override bool TryRegisterUser(string name, string password)
		{
		
			if (!base.TryRegisterUser(name, password) || UserExists(name))
				return false;
			
			UserCreate(name, password);
			return true;
			
		}
		
		// -------------------------------------------------------------------------------
		// TrySoftDeleteUser
		// -------------------------------------------------------------------------------
		public override bool TrySoftDeleteUser(string name, string password, int _action=1)
		{
		
			if (!base.TrySoftDeleteUser(name, password) || !UserValid(name, password))
				return false;
				
			UserSetDeleted(name, _action);
			return true;	
			
		}
		
		// -------------------------------------------------------------------------------
		// TryChangePasswordUser
		// -------------------------------------------------------------------------------
		public override bool TryChangePasswordUser(string name, string oldpassword, string newpassword)
		{
		
			if (!base.TryChangePasswordUser(name, oldpassword, newpassword) || !UserValid(name, oldpassword))
				return false;
			
			UserChangePassword(name, oldpassword, newpassword);
			return true;	
			
		}
		
		// -------------------------------------------------------------------------------
		// TryBanUser
		// -------------------------------------------------------------------------------
		public override bool TryBanUser(string name, string password, int _action=1)
		{
			
			if (!base.TryBanUser(name, password) || !UserValid(name, password))
				return false;
				
			UserSetBanned(name, _action);
			return true;	
			
		}
		
		// -------------------------------------------------------------------------------
		// TryConfirmUser
		// -------------------------------------------------------------------------------
		public override bool TryConfirmUser(string name, string password, int _action=1)
		{
		
			if (!base.TryConfirmUser(name, password) || !UserValid(name, password))
				return false;
				
			UserSetConfirmed(name, _action);
			return true;	
			
		}
		
		// -------------------------------------------------------------------------------
		// UserCreate
		// -------------------------------------------------------------------------------
		public void UserCreate(string name, string password)
		{
			Insert(new TableUser{ name=name, password=password, created=DateTime.UtcNow, lastlogin=DateTime.Now, banned=false});
		}
		
		// -------------------------------------------------------------------------------
		// UserChangePassword
		// -------------------------------------------------------------------------------
		public void UserChangePassword(string name, string oldpassword, string newpassword)
		{
			Execute("UPDATE TableUser SET password=? WHERE name=? AND password=?", newpassword, name, oldpassword);
		}
		
		// -------------------------------------------------------------------------------
		// UserValid
		// -------------------------------------------------------------------------------
		public bool UserValid(string name, string password)
		{
			return FindWithQuery<TableUser>("SELECT * FROM TableUser WHERE name=? AND password=? AND banned=0 AND deleted=0", name, password) != null;
		}
		
		// -------------------------------------------------------------------------------
		// UserExists
		// -------------------------------------------------------------------------------
		public bool UserExists(string name)
		{
			return FindWithQuery<TableUser>("SELECT * FROM TableUser WHERE name=?", name) != null;
		}
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================