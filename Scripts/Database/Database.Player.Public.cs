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
		public override bool TryLogin(string _name, string _password)
		{
			
			if (!base.TryLogin(_name, _password))
				return false;
			
			if (PlayerValid(_name, _password))
			{
				PlayerSetOnline(_name);
				return true;
			}
			
			return false;
		}
		
		// -------------------------------------------------------------------------------
		public override bool TryRegister(string _name, string _password)
		{
		
			if (!base.TryLogin(_name, _password))
				return false;
				
			if (PlayerExists(_name))
				return false;

			PlayerCreate(_name, _password);
			return true;
				
		}
		
		// -------------------------------------------------------------------------------
		public override bool TrySoftDelete(string _name, string _password, int _action=1)
		{
		
			if (!base.TryLogin(_name, _password))
				return false;
				
			if (PlayerValid(_name, _password))
			{
				PlayerSetDeleted(_name, _action);
				return true;	
			}
			
			return false;
		
		}
		
		// -------------------------------------------------------------------------------
		public override bool TryBan(string _name, string _password, int _action=1)
		{
			
			if (!base.TryLogin(_name, _password))
				return false;
				
			if (PlayerValid(_name, _password))
			{
				PlayerSetBanned(_name, _action);
				return true;	
			}
			
			return false;
		
		}
		
		// -------------------------------------------------------------------------------
		public override bool TryConfirm(string _name, string _password, int _action=1)
		{
		
			if (!base.TryLogin(_name, _password))
				return false;
				
			if (PlayerValid(_name, _password))
			{
				PlayerSetConfirmed(_name, _action);
				return true;	
			}
			
			return false;
		
		}
		
		// -------------------------------------------------------------------------------
		public void PlayerCreate(string _name, string _password)
		{
			Insert(new TablePlayer{ name=_name, password=_password, created=DateTime.UtcNow, lastlogin=DateTime.Now, banned=false});
		}
		
		// -------------------------------------------------------------------------------
		public bool PlayerValid(string _name, string _password)
		{
			return FindWithQuery<TablePlayer>("SELECT * FROM TablePlayer WHERE name=? AND password=? AND banned=0 AND deleted=0", _name, _password) != null;
		}
		
		// -------------------------------------------------------------------------------
		public bool PlayerExists(string _name)
		{
			return FindWithQuery<TablePlayer>("SELECT * FROM TablePlayer WHERE name=?", _name) != null;
		}
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================