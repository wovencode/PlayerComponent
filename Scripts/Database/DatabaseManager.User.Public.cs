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
		// 
		// -------------------------------------------------------------------------------
		public override bool TryUserLogin(string name, string password)
		{
		
			if (!base.TryUserLogin(name, password) || !UserValid(name, password))
				return false;
			
			LoginUser(name);
			return true;
			
		}
		
		// -------------------------------------------------------------------------------
		// 
		// -------------------------------------------------------------------------------
		public override bool TryUserRegister(string name, string password)
		{
		
			if (!base.TryUserRegister(name, password) || UserExists(name))
				return false;
			
			UserRegister(name, password);
			return true;
			
		}
		
		// -------------------------------------------------------------------------------
		// 
		// -------------------------------------------------------------------------------
		public override bool TryUserDelete(string name, string password, int _action=1)
		{
		
			if (!base.TryUserDelete(name, password) || !UserValid(name, password))
				return false;
				
			UserSetDeleted(name, _action);
			return true;	
			
		}
		
		// -------------------------------------------------------------------------------
		// 
		// -------------------------------------------------------------------------------
		public override bool TryUserChangePassword(string name, string oldpassword, string newpassword)
		{
		
			if (!base.TryUserChangePassword(name, oldpassword, newpassword) || !UserValid(name, oldpassword))
				return false;
			
			UserChangePassword(name, oldpassword, newpassword);
			return true;	
			
		}
		
		// -------------------------------------------------------------------------------
		// 
		// -------------------------------------------------------------------------------
		public override bool TryUserBan(string name, string password, int _action=1)
		{
			
			if (!base.TryUserBan(name, password) || !UserValid(name, password))
				return false;
				
			UserSetBanned(name, _action);
			return true;	
			
		}
		
		// -------------------------------------------------------------------------------
		// 
		// -------------------------------------------------------------------------------
		public override bool TryUserConfirm(string name, string password, int _action=1)
		{
		
			if (!base.TryUserConfirm(name, password) || !UserValid(name, password))
				return false;
				
			UserSetConfirmed(name, _action);
			return true;	
			
		}
		
		// -------------------------------------------------------------------------------
		// 
		// -------------------------------------------------------------------------------
		public override bool  TryUserGetValid(string name, string password)
		{
			if (!base.TryUserGetValid(name, password))
				return false;
		
			return UserValid(name, password);
			
		}
		
		// -------------------------------------------------------------------------------
		// 
		// -------------------------------------------------------------------------------
		public override bool  TryUserGetExists(string name)
		{
			if (!base.TryUserGetExists(name))
				return false;
			
			return UserExists(name);
			
		}
		
		// -------------------------------------------------------------------------------
		// 
		// -------------------------------------------------------------------------------
		public override int TryUserGetPlayerCount(string name)
		{
			if (!Tools.IsAllowedName(name))
				return 0;
			
			return GetPlayerCount(name);
		}
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================